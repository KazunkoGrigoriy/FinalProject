using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Website.Interfaces;
using Website.Models;

namespace Website.Data
{
    public class DataRequests : IRequestsData
    {
        HttpClient httpClient = new HttpClient();

        public void AddRequest(Request request)
        {
            string url = @"https://localhost:44373/webapi";

            try
            {
                var p = httpClient.PostAsync(
                                    requestUri: url,
                                    content: new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                                    mediaType: "application/json")
                                    ).Result;
            } catch
            {

            }
        }

        public void DeleteRequest(int id)
        {
            string url = @"https://localhost:48373/DeleteRequests/{id}";
            var del = httpClient.DeleteAsync(
                requestUri: url).Result;
        }

        public IEnumerable<Request> GetRequests()
        {
            string url = @"https://localhost:48373/webapi";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Request>>(json);
        }

        public void UpdateRequest(int id)
        {
            //string url = @"https://localhost:5001/UpdateRequests/{id}";
            //var upd = httpClient.PutAsync(
            //    requestUri: url,
            //    content: new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
            //    mediaType: "application/json")
            //    ).Result;
        }
    }
}
