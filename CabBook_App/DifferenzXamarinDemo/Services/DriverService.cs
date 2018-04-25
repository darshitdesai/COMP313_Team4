using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using CabBook.Helpers;
using CabBook.Models;

namespace CabBook
{
    public class DriverService
    {
        public DriverService()
        {
        }
        public static async Task<List<RideInformation>> GetAllRides(string userId)
        {
            List<RideInformation> UDI = new List<RideInformation>();
            try
            {
                var client = new System.Net.Http.HttpClient();

                
                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                var response = await client.GetAsync("/api/Driver/ViewRides/" + userId);

                var result = response.Content.ReadAsStringAsync().Result;

                UDI = JsonConvert.DeserializeObject<List<RideInformation>>(result);

                //UDI = resultobject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }


        public static async Task<CarDetails> GetCarDetails(string userId)
        {
            CarDetails UDI = new CarDetails();
            try
            {
                var client = new System.Net.Http.HttpClient();


                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                var response = await client.GetAsync("/api/Driver/CarDetails/" + userId);

                var result = response.Content.ReadAsStringAsync().Result;

                UDI = JsonConvert.DeserializeObject<CarDetails>(result);

                //UDI = resultobject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }


        public static async Task<string> PostRide(RideInformation rd)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();


                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);


                var jsonString = JsonConvert.SerializeObject(rd);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/Driver/PostRide", content);

                var result = response.Content.ReadAsStringAsync().Result;


                //UDI = resultobject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
                return "Error";

            }
            return "Succsess";
        }

        public static async Task<string> AddCarDetail(CarDetails rd)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();


                client.BaseAddress = new Uri(ServiceHelper.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);


                var jsonString = JsonConvert.SerializeObject(rd);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/Driver/CarDetails", content);

                var result = response.Content.ReadAsStringAsync().Result;


                //UDI = resultobject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //UDI.Errors.Add (Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
                return "Error";

            }
            return "Succsess";
        }

    }
}