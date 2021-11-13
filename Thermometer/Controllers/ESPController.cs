using System;
using System.Diagnostics;
using EinfachAlex.Utils.Logging;
using EinfachAlex.Utils.UnixTime;
using EinfachAlex.Utils.WebRequest;
using Microsoft.AspNetCore.Mvc;
using Thermometer.Database;

namespace Thermometer.Controllers
{
    /// <summary>
    /// The ESP8266 posts its data here
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ESPController : ControllerBase
    {
        private const string ENDPOINT = "/ESP";
        private const ERequestTypes ENDPOINT_TYPE = ERequestTypes.POST;
        
        [HttpGet(ENDPOINT)]
        public void PostTemperature([FromQuery] string temperature, [FromQuery] string humidity, [FromQuery] string co2)
        {
            Stopwatch sw = Stopwatch.StartNew();
            LoggerCommonMessages.logEndpointRequest(ENDPOINT, ENDPOINT_TYPE);
         
            Logger.i($"Temp: {temperature} - Humi: {humidity} - CO2: {co2}");
            
            databaseContext databaseContext = new databaseContext();
            
            Log measurement = new Log() {Humi = Convert.ToDouble(humidity), Temp = Convert.ToDouble(temperature), Co2 = Convert.ToDouble(co2), Timestamp = UnixTime.getUnixTimestamp() };
            databaseContext.Add(measurement);

            databaseContext.SaveChanges();
            
            sw.Stop();
            Logger.v($"{sw.ElapsedMilliseconds} ms");
        }
    }
}