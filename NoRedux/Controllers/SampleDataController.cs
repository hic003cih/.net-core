using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NoRedux.Controllers
{
    //���ѳW�h / api/SampleData/WeatherForecasts

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")] //�]�m���ѨϥΤ覡��get
        public IEnumerable<WeatherForecast> WeatherForecasts() // api/SampleData/WeatherForecasts
        {
            var rng = new Random();
            //�^��object,client�ݥ�json��}
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")] //�]�m���ѨϥΤ覡��get
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
