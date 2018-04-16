using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace MiniFacebook.Models
{
    public class WeatherViewModel
    {
        public Object GetWeatherForecast()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Zagreb&APPID=5434232852cda768290f76209d814b83&units=metric";
            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Object>(content);
            return jsonContent;
        }
    }
}