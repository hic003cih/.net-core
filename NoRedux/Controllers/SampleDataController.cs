using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NoRedux.Controllers
{
    //路由規則 / api/SampleData/WeatherForecasts

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")] //設置路由使用方式為get
        public IEnumerable<WeatherForecast> WeatherForecasts() // api/SampleData/WeatherForecasts
        {
            var rng = new Random();
            //回傳object,client端用json拆開
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")] //設置路由使用方式為get
        public string Temp()  // api/SampleData/Temp
        {
            return "Hello";
        }

        //[HttpGet]
        //[Route("api/Employee/Details/{id}")]
        //public TblEmployee Details(int id)
        //{
        //    return objemployee.GetEmployeeData(id);
        //}
        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
