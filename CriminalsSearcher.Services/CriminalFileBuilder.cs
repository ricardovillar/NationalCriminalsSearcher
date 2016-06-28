
using System.IO;
using CriminalsSearcher.Model.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CriminalsSearcher.Services {
    public class CriminalFileBuilder {        

        public static MemoryStream Build(Criminal criminal) {
            var memoryStreamResult = new MemoryStream();
            var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            var writer = PdfWriter.GetInstance(doc, memoryStreamResult);
            doc.Open();

            var title = new Paragraph();
            title.Alignment = Element.ALIGN_CENTER;
            title.Font = new Font(Font.NORMAL, 18, (int) System.Drawing.FontStyle.Bold);
            title.Add("National Criminals Search");
            doc.Add(title);
            
            var profileParagraph = new Paragraph("", new Font(Font.NORMAL, 14));
            var profile = $"Name: {criminal.Name}" + System.Environment.NewLine +
                          $"Birth Date: {criminal.BirthDate:MM/dd/yyyy}" + System.Environment.NewLine +
                          $"Gender: {ResolveGender(criminal.Gender)}" + System.Environment.NewLine +
                          $"Height: {criminal.Height}" + System.Environment.NewLine +
                          $"Weight: {criminal.Weight}" + System.Environment.NewLine +
                          $"Nationality: {criminal.Nationality}" + System.Environment.NewLine +
                          $"Father's Name: {criminal.FatherName}" + System.Environment.NewLine +
                          $"Mother's Name: {criminal.MotherName}" + System.Environment.NewLine +
                          $"Passport Number: {criminal.PassportNumber}" + System.Environment.NewLine +
                          $"Driver License Number: {criminal.DriverLicenseNumber}";
            profileParagraph.Add(profile);            
            doc.Add(profileParagraph);

            writer.CloseStream = false;
            doc.Close();            
            return memoryStreamResult;
        }

        private static string ResolveGender(string gender) {
            switch (gender) {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                default:
                    return string.Empty;
            }
        }
    }
}