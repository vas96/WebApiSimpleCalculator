using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            StatusCode(200);
           // return Ok();
            return Redirect("~/Index.html");
        }

        [HttpPost("/add")]
        public async Task AddTask([FromBody] Values values)
        {            
            try
            {
                //var val1 = double.Parse(Request.Form["val1"]);
                //var val2 = double.Parse(Request.Form["val2"]);

                var val1 = double.Parse(values.Val1);
                var val2 = double.Parse(values.Val2);
                
                double result = Math.Round((val1 + val2), 4);

                var response = new
                {
                    res = result,
                };
                Response.StatusCode = 200;
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
               // return result;
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Some ting wong." + e.ToString());
                return;
            }
        }

        [HttpPost("/subtraction")]
        public async Task SubtractionTask([FromBody] Values values)
        {
            try
            {
                var val1 = double.Parse(values.Val1);
                var val2 = double.Parse(values.Val2);

                double result = Math.Round((val1 - val2), 4);


                var response = new
                {
                    res = result,
                };
                
                Response.ContentType = "application/json";
                Response.StatusCode = 200;
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
                
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Some ting wong.");
                return;
            }
        }

        [HttpPost("/division")]
        public async Task DivisionTask([FromBody] Values values)
        {
            try
            {
                var val1 = double.Parse(values.Val1);
                var val2 = double.Parse(values.Val2);

                double result = 0;
                if (val2 == 0)
                {
                    result = 0;
                }
                else
                {
                    result = Math.Round((val1 / val2), 4);
                }
                 
                var response = new
                {
                    res = result,
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Some ting wong.");
                return;
            }
        }

        [HttpPost("/multiplication")]
        public async Task MultiplicationTask([FromBody] Values values)
        {
            try
            {
                var val1 = double.Parse(values.Val1);
                var val2 = double.Parse(values.Val2);

                double result = Math.Round((val1 * val2 ), 4);


                var response = new
                {
                    res = result,
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Some ting wong.");
                return;
            }
        }

        [HttpPost("/percent")]
        public async Task PercentTask([FromBody] Values values)
        {
            try
            {
                var val1 = double.Parse(values.Val1);
                var val2 = double.Parse(values.Val2);

                string eror = "eee boi";
                double result = 0;
                
                if (val2 > 100 || val2 < 0)
                {
                    var response = new
                    {
                        res = eror
                    };

                    Response.ContentType = "application/json";
                    await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
                }
                else
                {
                   result = Math.Round((val1 * val2 / 100), 4);
                    var response = new
                    {
                        res = result
                    };

                    Response.ContentType = "application/json";
                    await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

                }              
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Some ting wong.");
                return;
            }
        }
    }
}
