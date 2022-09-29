using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BercaCafe_Client.TempController
{
    public class DashboardsController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public DashboardsController()
        {
            client.BaseAddress = new System.Uri("https://localhost:44331/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IActionResult Index()
        {
            var result = client.GetAsync("api/Menus/").Result;
            JObject dataResult = JObject.Parse(result.Content.ReadAsStringAsync().Result);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Data = dataResult["result"];
            }
            else
            {
                ViewBag.Data = null;
            }
            return View();
        }
    }
}
