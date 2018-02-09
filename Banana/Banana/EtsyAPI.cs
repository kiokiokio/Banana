using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Specialized;

namespace Banana
{
    public class EtsyAPI
    {

        Uri BASE_URL = new Uri("https://openapi.etsy.com/v2");

        // Is this where I put this stuff?? Originally were just defined not set to any specific values...
        string appKey;
        string sharedSecret;
        RestClient restClient;

        private string[] _permissions_array;
        public string Permissions
        {
            get { return string.Join(" ", _permissions_array); }    
        }

        public EtsyAPI() {
            restClient = new RestClient(BASE_URL);
        }

        public EtsyAPI(string appkey_, string sharedSecret_)
        {
            appKey = appkey_;
            sharedSecret = sharedSecret_;

            restClient = new RestClient(BASE_URL);

            // dev suggested to move permissions to Web.config
            // pretty sure i need to update these permissions - looking for receipts not listings
            _permissions_array = new string[] { "listings_r", "listings_w", "listings_d", "shops_rw" };
        }

        public string GetListings()
        {
            RestRequest restRequest = new RestRequest("/listings/active?api_key=" + appKey, Method.GET);

            IRestResponse response = restClient.Execute(restRequest);

            /*   if (response.StatusCode != System.Net.HttpStatusCode.OK)
               {
                   oauth_token = null;
                   oauth_token_secret = null;
                   return null;
               }
            */

            return response.Content;
        }

        /*
         * 
        public string GetConfirmUrl(out string oauth_token, out string oauth_token_secret, string callbackUrl_ = null)
        {
            restClient.Authenticator = OAuth1Authenticator.ForRequestToken(appKey, sharedSecret, callbackUrl_ ?? "oob");

            RestRequest restRequest = new RestRequest("oauth/request_token", Method.POST);
            restRequest.AddParameter("scope", Permissions);

            IRestResponse response = restClient.Execute(restRequest);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                oauth_token = null;
                oauth_token_secret = null;
                return null;
            }

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(response.Content);

            oauth_token = queryString["oauth_token"];
            oauth_token_secret = queryString["oauth_token_secret"];

            return queryString["login_url"];
        }

        public void ObtainTokenCredentials(string oauth_token_temp_, string oauth_token_secret_temp_, string oauth_verifier_, out string permanent_oauth_token_, out string permanent_oauth_token_secret_)
        {
            // consumerKey is the appKey you got when you registered your app same for sharedSecret
            restClient.Authenticator = OAuth1Authenticator.ForAccessToken(appKey, sharedSecret, oauth_token_temp_, oauth_token_secret_temp_, oauth_verifier_);

            RestRequest restRequest = new RestRequest("oauth/access_token", Method.GET);
            IRestResponse irestResponse = restClient.Execute(restRequest);

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(irestResponse.Content);

            permanent_oauth_token_ = queryString["oauth_token"];
            permanent_oauth_token_secret_ = queryString["oauth_token_secret"];

        }

        public string GetScopes(string accessToken_, string accessTokenSecret_)

        {
            restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(appKey, sharedSecret, accessToken_, accessTokenSecret_);
            RestRequest restRequest = new RestRequest("oauth/scopes", Method.GET);

            IRestResponse irestResponse = restClient.Execute(restRequest);

            return irestResponse.Content;
        }

        */
    }
}
