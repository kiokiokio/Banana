using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banana.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Banana.Controllers
{
    public class TestController : Controller
    {
        private readonly IOptions<AppSecrets> _options;

        public TestController(IOptions<AppSecrets> optionsAccessor)
        {
            _options = optionsAccessor;
        }

        public void Index()
        {
            var etsy = new EtsyAPI(_options.Value.AppKey, _options.Value.SharedSecret);

            var callback = "http://localhost:55437/Test/Callback";
            
            string token = string.Empty;
            string secret = string.Empty;

            var loginUrl = etsy.GetConfirmUrl(out token, out secret, callback);

            Response.Cookies.Append("temp_secret", secret);

            Response.Redirect(loginUrl);

        }

        public string Callback()
        {
            // so get the stuff off of the query string:
            var oauthTempToken = Request.Query["oauth_token"];
            var oauthTempVerifier = Request.Query["oauth_verifier"];
            var temp_secret = Request.Cookies["temp_secret"];

            var etsy = new EtsyAPI(_options.Value.AppKey, _options.Value.SharedSecret);
            string token = string.Empty;
            string secret = string.Empty;
            etsy.ObtainTokenCredentials(oauthTempToken, temp_secret, oauthTempVerifier, out token, out secret);
            return "Not Yet";
        }
    }
}