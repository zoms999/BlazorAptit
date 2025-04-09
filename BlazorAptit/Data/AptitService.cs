using BlazorAptit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAptit.Data
{
    public class AptitService
    {
        string baseUrl = "https://localhost:44373/";
        public async Task<List<AptitQuestion>> GetOrdersAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Default");
            return JsonConvert.DeserializeObject<List<AptitQuestion>>(json);
        }      
        public async Task<HttpResponseMessage> InsertOrderAsync(Order value)
        {
            var client = new HttpClient();
            return await client.PostAsync($"{baseUrl}api/Default", getStringContentFromObject(value));
        }
        public async Task<HttpResponseMessage> UpdateOrderAsync(string id,  Order value)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Default/{id}", getStringContentFromObject(value));            
        }

        public async Task<HttpResponseMessage> DeleteOrderAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}api/Default/{id}");            
        }
        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }

        public async Task<HttpResponseMessage> EditAsync(string id, Order value)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}api/Aptits/{id}", getStringContentFromObject(value));
        }

    }
}
