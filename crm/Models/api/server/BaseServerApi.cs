using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using crm.Models.user;
using crm.Models.api.server.valuesconverter;

namespace crm.Models.api.server
{
    public abstract class BaseServerApi
    {
        #region vars
        protected string url;
        IConverter converter;
        #endregion

        public BaseServerApi(string url)
        {
            this.url = url;
            converter = new Converter();
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
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new ServerResponseException(response.StatusCode);
                    JObject json = JObject.Parse(response.Content);
                    res = json["success"].ToObject<bool>();
                    if (res == null)
                        throw new NoDataReceivedException();
                    if (!res)                    
                        throw new ApiException("Невалидный токен или его срок действия истек");                                        
                });

            }  catch (Exception ex)
            {
                throw new ApiException(ex.Message); 
            }  
            return res;
        }

        public virtual async Task<bool> RegisterUser(string token, BaseUser user)
        {
            bool res = false;

            await Task.Run(() => { 
                var client = new RestClient($"{url}/v1/users");
                var request = new RestRequest(Method.POST);
                request.AddHeader($"Authorization", $"Bearer {token}");
                dynamic p = new JObject();
                p.email = user.Email;
                p.password = user.Password;
                p.userfullname = user.FullName;
                p.birthday = converter.date(user.BirthDate, Direction.user_server);
                p.phone = converter.phone(user.PhoneNumber, Direction.user_server);
                p.telegram = converter.telegram(user.Telegram, Direction.user_server);
                p.usdtaccount = user.Wallet;
                //p.devices = new JArray();
                //foreach (var device in user.Devices) 
                //    p.devices.Add(device);
                p.device = user.Devices[0];
                request.AddParameter("application/json", p.ToString(), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

            });

            return res;
        }
        
        #endregion

    }
}
