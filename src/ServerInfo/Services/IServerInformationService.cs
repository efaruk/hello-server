using ServerInfo.Models;

namespace ServerInfo.Services
{
    public interface IServerInformationService
    {
        ServerInformationModel GetServerInformation(HttpContext httpContext);
    }
}
