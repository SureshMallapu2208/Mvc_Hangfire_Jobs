using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Mvc.Repository;
using Mvc.Services;

namespace Mvc.Controllers
{
    public class RequestController : Controller
    {

        private readonly IRepository<Request> _request;
        private readonly IJob _job;
        private readonly IConfiguration _configuration;

        public RequestController(IRepository<Request> request, IJob job, IConfiguration configuration) { _request = request; _job = job; _configuration = configuration; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string RequestType, string RequestMessage)
        {
            var result = _request.AddAsync(new Models.Request() { Name = Name, RequestType = RequestType, RequestMessage = RequestMessage });

            return Json(result.Result);
        }

        [HttpGet]
        public PartialViewResult GetDelay()
        {
            return PartialView("_DelayJobs", CreateDirectory("DelayJob"));
        }

        [HttpGet]
        public PartialViewResult GetRecursive()
        {
            return PartialView("_RecursiveJobs", CreateDirectory("RecurringJob"));
        }

        [HttpGet]
        public PartialViewResult GetFire()
        {
            return PartialView("_FireJobs", CreateDirectory("FireandForgotJob"));
        }

        private IEnumerable<string> CreateDirectory(string key)
        {
            return Directory.GetFiles(_configuration.GetSection(key).Value).ToList();
        }
    }
}
