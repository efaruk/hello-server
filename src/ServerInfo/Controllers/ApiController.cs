using Microsoft.AspNetCore.Mvc;
using ServerInfo.Models;
using ServerInfo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerInfo.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServerInformationService _serverInformationService;

        public ApiController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor, IServerInformationService serverInformationService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _serverInformationService = serverInformationService;
        }

        private HttpContext Context
        {
            get
            {
                var context = _httpContextAccessor.HttpContext ?? HttpContext;
                return context;
            }
        }

        // GET: api
        [HttpGet]
        public ServerInformationModel Get()
        {
            var model = _serverInformationService.GetServerInformation(Context);
            return model;
        }

    }
}
