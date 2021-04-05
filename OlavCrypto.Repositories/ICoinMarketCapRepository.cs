using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public interface ICoinMarketCapRepository
    {
        Task<double> GetCurrentPrice(string shortname);
    }
}
