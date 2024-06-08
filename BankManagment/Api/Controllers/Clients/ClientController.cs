using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace Api.Controllers.Clients
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
