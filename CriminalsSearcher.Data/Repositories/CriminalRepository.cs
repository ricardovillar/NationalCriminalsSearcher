using System.Linq;
using System.Collections.Generic;
using CriminalsSearcher.Model.DTO;
using CriminalsSearcher.Model.Entities;
using CriminalsSearcher.Model.Repositories;
using System;

namespace CriminalsSearcher.Data.Repositories {
    public class CriminalRepository : BaseRepository<Criminal>, ICriminalRepository {
        
        public List<Criminal> Search(CriminalSearchParameters searchParameters, int? maxResults = int.MaxValue) {

            var query = from criminal in GetTable()
                        select criminal;

            if (!string.IsNullOrEmpty(searchParameters.Name)) {
                query = query.Where(c => c.Name.Contains(searchParameters.Name));
            }
            if (searchParameters.MinimumBirthDate.HasValue) {
                query = query.Where(c => c.BirthDate >= searchParameters.MinimumBirthDate.Value);
            }
            if (searchParameters.MaximumBirthDate.HasValue) {
                query = query.Where(c => c.BirthDate <= searchParameters.MaximumBirthDate.Value);
            }
            if (!string.IsNullOrEmpty(searchParameters.Gender)) {
                query = query.Where(c => c.Gender.Equals(searchParameters.Gender));
            }
            if (searchParameters.MinimumHeight.HasValue) {
                query = query.Where(c => c.Height >= searchParameters.MinimumHeight.Value);
            }
            if (searchParameters.MaximumHeight.HasValue) {
                query = query.Where(c => c.Height <= searchParameters.MaximumHeight.Value);
            }
            if (searchParameters.MinimumWeight.HasValue) {
                query = query.Where(c => c.Weight >= searchParameters.MinimumWeight.Value);
            }
            if (searchParameters.MaximumWeight.HasValue) {
                query = query.Where(c => c.Weight <= searchParameters.MaximumWeight.Value);
            }
            if (!string.IsNullOrEmpty(searchParameters.Nationality)) {
                query = query.Where(c => c.Nationality.Contains(searchParameters.Nationality));
            }
            if (!string.IsNullOrEmpty(searchParameters.FatherName)) {
                query = query.Where(c => c.FatherName.Contains(searchParameters.FatherName));
            }
            if (!string.IsNullOrEmpty(searchParameters.MotherName)) {
                query = query.Where(c => c.MotherName.Contains(searchParameters.MotherName));
            }
            if (!string.IsNullOrEmpty(searchParameters.PassportNumber)) {
                query = query.Where(c => c.PassportNumber.Contains(searchParameters.PassportNumber));
            }
            if (!string.IsNullOrEmpty(searchParameters.DriverLicenseNumber)) {
                query = query.Where(c => c.DriverLicenseNumber.Contains(searchParameters.DriverLicenseNumber));
            }

            return query.Take(maxResults.Value).ToList();
        }        
        
    }
}
