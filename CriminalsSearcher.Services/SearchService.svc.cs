using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CriminalsSearcher.Model.DTO;
using CriminalsSearcher.Model.Repositories;

namespace CriminalsSearcher.Services {

    public class SearchService : ISearchService {
        private readonly ICriminalRepository _criminalRepository;
        private const int FilesPerEmail = 10;
        private string SmtpHost;
        private int SmtpPort;
        private bool SmtpEnalbeSsl;
        private string SmtpUserName;
        private string SmtpPassword;

        public SearchService(ICriminalRepository criminalRepository) {
            _criminalRepository = criminalRepository;
            SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            SmtpEnalbeSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpEnalbeSsl"]);
            SmtpUserName = ConfigurationManager.AppSettings["SmtpUserName"];
            SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        }

        public bool Search(SearchParameters searchParameters, string mailTo, int maxResults) {
            if (!string.IsNullOrEmpty(mailTo) && maxResults > 0 && ValidateSearchParameters(searchParameters)) {
                Task.Run(() => DoSearch(searchParameters, mailTo, maxResults));
                return true;
            }
            return false;
        }

        private void DoSearch(SearchParameters searchParameters, string mailTo, int maxResults) {
            var criminals = _criminalRepository.Search(ParseToCriminalSearchParameters(searchParameters), maxResults);
            var criminalFiles = criminals.Select(criminal => CriminalFileBuilder.Build(criminal)).ToList();
            var skip = 0;
            var take = FilesPerEmail;
            while (skip < criminalFiles.Count) {
                SendCriminalFiles(criminalFiles.Skip(skip).Take(take), mailTo);
                skip += take;
            }
        }

        private void SendCriminalFiles(IEnumerable<MemoryStream> criminalFiles, string mailTo) {
            var message = new MailMessage(SmtpUserName, mailTo) {
                Subject = "National Criminals Searcher",
                IsBodyHtml = true,
                Body = "Here's your search results"
            };

            for (int i = 0; i < criminalFiles.Count(); i++) {
                var file = criminalFiles.ElementAt(i);
                file.Position = 0;
                message.Attachments.Add(new Attachment(file, $"CriminalProfile{i + 1}.pdf"));
            }

            var smtp = GetSmtpClient();

            smtp.Send(message);
        }

        private bool ValidateSearchParameters(SearchParameters searchParameters) {
            return !string.IsNullOrEmpty(searchParameters.Name) ||
                   searchParameters.MinimumAge.HasValue ||
                   searchParameters.MaximumAge.HasValue ||
                   !string.IsNullOrEmpty(searchParameters.Gender) ||
                   searchParameters.MinimumHeight.HasValue ||
                   searchParameters.MaximumHeight.HasValue ||
                   searchParameters.MinimumWeight.HasValue ||
                   searchParameters.MaximumWeight.HasValue ||
                   !string.IsNullOrEmpty(searchParameters.Nationality) ||
                   !string.IsNullOrEmpty(searchParameters.FatherName) ||
                   !string.IsNullOrEmpty(searchParameters.MotherName) ||
                   !string.IsNullOrEmpty(searchParameters.PassportNumber) ||
                   !string.IsNullOrEmpty(searchParameters.DriverLicenseNumber);
        }

        private CriminalSearchParameters ParseToCriminalSearchParameters(SearchParameters searchParameters) {
            return new CriminalSearchParameters {
                Name = searchParameters.Name,
                MinimumBirthDate = searchParameters.MaximumAge.HasValue ? DateTime.Today.AddYears(searchParameters.MaximumAge.Value * -1) : (DateTime?) null,
                MaximumBirthDate = searchParameters.MinimumAge.HasValue ? DateTime.Today.AddYears(searchParameters.MinimumAge.Value * -1) : (DateTime?) null,
                Gender = searchParameters.Gender,
                MinimumHeight = searchParameters.MinimumHeight,
                MaximumHeight = searchParameters.MaximumHeight,
                MinimumWeight = searchParameters.MinimumWeight,
                MaximumWeight = searchParameters.MaximumWeight,
                Nationality = searchParameters.Nationality,
                FatherName = searchParameters.FatherName,
                MotherName = searchParameters.MotherName,
                PassportNumber = searchParameters.PassportNumber,
                DriverLicenseNumber = searchParameters.DriverLicenseNumber
            };
        }

        private SmtpClient GetSmtpClient() {
            return new SmtpClient {
                Host = SmtpHost,
                Port = SmtpPort,
                EnableSsl = SmtpEnalbeSsl,
                Credentials = new NetworkCredential(SmtpUserName, SmtpPassword)
            };
        }
    }
}
