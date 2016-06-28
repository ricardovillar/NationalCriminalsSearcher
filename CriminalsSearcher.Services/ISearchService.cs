using System.ServiceModel;

namespace CriminalsSearcher.Services {
    [ServiceContract]
    public interface ISearchService {
        [OperationContract]
        bool Search(SearchParameters searchParameters, string mailTo, int maxResults);
    }
}