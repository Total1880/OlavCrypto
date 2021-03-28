using System.Threading.Tasks;

namespace OlavCrypto.Repositories
{
    public interface ICoinMarketCapRepository
    {
        Task GetCurrentPrice(string shortname);
    }
}
