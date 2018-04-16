using MiniFacebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFacebook.Controllers
{
    [Authorize]
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {

            return View();
        }


        public JsonResult GetWeather()
        {
            WeatherViewModel weather = new WeatherViewModel();
            return Json(weather.GetWeatherForecast(), JsonRequestBehavior.AllowGet);
        }

    }
}