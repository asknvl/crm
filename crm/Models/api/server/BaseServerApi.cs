using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.api.server
{
    public abstract class BaseServerApi
    {
        #region vars
        protected string url;
        #endregion

        public BaseServerApi(string url)
        {
            this.url = url;
        }

        #region public
        public virtual async Task<bool> ValidateRegToken(string token)
        {
            bool res = false;
            try
            {
                await Task.Run(() => {
                    var client = new RestClient($"{url}/v1/auth/validateRegToken");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader($"Authorization", $"Bearer {token}");
                    IRestResponse response = client.Execute(request);
                    JObject json = JObject.Parse(response.Content);
                    string? msg = json["message"]?.ToObject<string>();
                    if (msg != null)
                        res = msg.ToLower().Equals("ok");                   
                });

            }  catch (Exception ex)
            {

            }
            return res;
        }
        #endregion

    }
}
