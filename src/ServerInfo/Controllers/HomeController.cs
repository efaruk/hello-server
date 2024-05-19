using System.Diagnostics;
using ServerInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net;
using ServerInfo.Services;

namespace ServerInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServerInformationService _serverInformationService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IServerInformationService serverInformationService)
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

        public IActionResult Index()
        {
            var model = _serverInformationService.GetServerInformation(Context);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
