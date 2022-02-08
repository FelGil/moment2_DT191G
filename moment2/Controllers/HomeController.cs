using Microsoft.AspNetCore.Mvc;
using moment2.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace moment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //homepage
        public IActionResult Index()
        {
            ViewData["Message"] = "Välkommen att upptäcka och dela med dig olika skivor";
            // Add record of the month
            ViewBag.text = "Hot Space";
            return View();
        }
         //Record page
        [HttpGet("/skivor")]
        public IActionResult Records()
        {
            ViewData["Message"] = "Här är några skivor som anses vara bra";
            //read data
            var JsonStr = System.IO.File.ReadAllText("records.json");
            var JsonObj = JsonConvert.DeserializeObject<List<RecordModel>>(JsonStr);
            return View(JsonObj);
        }
        //form page
        [HttpGet("/lagg_till_skiva")]
        public IActionResult Form()
        {
            ViewData["Message"] = "Lägg gärna till en bra skiva";
            return View();
        }


        [HttpPost("/lagg_till_skiva")]
        public IActionResult Form(RecordModel model)
        {
            ViewData["Message"] = "Lägg gärna till en bra skiva";


            if (ModelState.IsValid)
            {
                //Read data
                var JsonStr = System.IO.File.ReadAllText("records.json");
                var JsonObj = JsonConvert.DeserializeObject<List<RecordModel>>(JsonStr);

                //Add to
                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                }

                //Convert to Json and save
                System.IO.File.WriteAllText("records.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));
            
                ModelState.Clear();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}