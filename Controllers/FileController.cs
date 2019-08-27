using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using streamDownload.Models;

namespace streamDownload.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            Response.ContentType = "text/plain";
            Response.Headers.Add("Content-Disposition", new string[]
            {
                $"attachment;filename=test.txt"
            });
            int counter = 0;
            while (true)
            {
                if (counter>100)
                {
                    break;
                }
                await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(counter.ToString()));
                await Response.Body.FlushAsync();
                counter++;
            }
            return new EmptyResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
