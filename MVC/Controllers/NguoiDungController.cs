using MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        
        public ActionResult Login()
        {
            return View();
        }

        // GET: NguoiDung
        public ActionResult Index()
        {
            List<mvcNguoiDungModel> persList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NguoiDung").Result;
            persList = response.Content.ReadAsAsync<List<mvcNguoiDungModel>>().Result;
            

            return View(persList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcNguoiDungModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NguoiDung/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcNguoiDungModel>().Result);
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcNguoiDungModel per)
        {
            if (per.IdNguoiDung == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("NguoiDung", per).Result;
                TempData["SuccessMessage"] = "Hurray, Saved Successfully !!!";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("NguoiDung/"+per.IdNguoiDung, per).Result;
                TempData["SuccessMessage"] = "Hurray, Updated Successfully !!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("NguoiDung/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully !!!";
            return RedirectToAction("Index");
        }
    }
}