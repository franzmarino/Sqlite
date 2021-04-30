using Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sqlite.Controllers
{
    public class PruebaController : ApiController
    {
        [Route("api/client/index")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json(new {message="ON" });
        }
        
        [Route("api/client/register")]
        [HttpPost]
        public IHttpActionResult Register(Cliente cliente)
        {
            new Ln().RegisterClient(cliente);


            return Json(new { message = "success" });
        }
        [Route("api/client/find/{ruc}")]
        [HttpGet]
        public IHttpActionResult FindClient(string ruc)
        {

            return Json(new Ln().FindClient(ruc));
        }




        [Route("api/cpe")]
        [HttpPost]
        public IHttpActionResult Cpe()
        {
            return Json(new { message = "success" });
        }
    }
}
