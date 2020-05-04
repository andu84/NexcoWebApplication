using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NexcoWeb.WebUI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<User> usersList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users").Result;
            usersList = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            return View(usersList);
        }
    }
    
}