using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace CabBook
{
    public class LoginService
    {
        public LoginService()
        {
        }

        /// <summary>
        /// Login - User Login (This is a dummy post call which returns a json we pass as a request json, to simulate login in demo project)
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="LoginData1">Login data1.</param>
        public static async Task<LoginModel> Login(LoginModel LoginData1)
        {
            LoginModel UDI = new LoginModel();
            try
            {
                var client = new System.Net.Http.HttpClient();

                LoginObject Loginobj = new LoginObject();
                Loginobj.LoginData = LoginData1;

                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var jData = JsonConvert.SerializeObject(Loginobj);
                var content1 = new StringContent(jData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/post", content1);

                var result = response.Content.ReadAsStringAsync().Result;

                var resultobject = JsonConvert.DeserializeObject<LoginModel>(result);

                UDI = resultobject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }



        public static async Task<Token> LoginToken(LoginModel LoginData1)
        {
            Token UDI = new Token();
            try
            {

              
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();

                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Build up the data to POST.
                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", LoginData1.Email));
                postData.Add(new KeyValuePair<string, string>("password", LoginData1.Password));

                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                // Post to the Server and parse the response.
                HttpResponseMessage response = await client.PostAsync("Token", content);
                string jsonString = await response.Content.ReadAsStringAsync();
                object responseData = JsonConvert.DeserializeObject(jsonString);

                UDI.AccessToken = ((dynamic)responseData).access_token;
                UDI.UserId = ((dynamic)responseData).userId;
                UDI.UserRole = ((dynamic)responseData).roleName;
                // return the Access Token.
                return UDI;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }

    }
}