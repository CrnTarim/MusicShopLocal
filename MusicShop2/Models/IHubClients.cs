using System.Threading.Tasks;

namespace MusicShop2.Models
{
    public interface IHubClients
    {
        Task BroadcastMessage();
    }
}
