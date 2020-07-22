using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCaptcha;

namespace TestMessageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICaptcha _captcha;

        public HomeController(ICaptcha captcha)
        {
            _captcha = captcha;
        }

        public IActionResult Captcha(string id)
        {
            var info = _captcha.Generate(id);
        }
    }
}
