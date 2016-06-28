using System.Collections.Generic;
using CriminalsSearcher.Model.DTO;
using CriminalsSearcher.Model.Entities;

namespace CriminalsSearcher.Model.Repositories {
    public interface ICriminalRepository {
        List<Criminal> Search(CriminalSearchParameters searchParameters, int? maxResults = null);        
    }
}
