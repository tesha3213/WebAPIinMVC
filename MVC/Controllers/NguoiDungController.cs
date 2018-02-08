using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            IEnumerable<mvcNguoiDungModel> persList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Person").Result;
            persList = response.Content.ReadAsAsync<IEnumerable<mvcNguoiDungModel>>().Result;
            
            return View(persList);
        }
    }
}