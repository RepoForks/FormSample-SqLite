using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace FormSample
{
    public class DataService
    {
		private string url = "https://dataservice.churchill-knight.co.uk/Agents";

        private string postDataUrl = "http://134.213.136.240:1081/api/agents";

        private string localUrl = "http://192.168.170.32:8099/api/customer";

        public List<Agent> filteredCustomerList { get; set; }

        public DataService()
        {
            filteredCustomerList = new List<Agent>();
        }

        public async Task<bool> IsValidUser(string userName,string password)
        {
            User user = new User { Email = userName, Password = password };

            var requestJson = JsonConvert.SerializeObject(user, Formatting.Indented);

            HttpClient client = new HttpClient();
            var result = await client.PostAsync(postDataUrl, new StringContent(requestJson, Encoding.UTF8, "application/json"));
            var json = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<bool>(json);
            return response;
        }

        public async Task<List<Agent>> GetCustomers()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(localUrl);
            var json = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<Agent>>(json);
            return response;
        }

        public async Task<Agent> AddAgent(Agent cust)
        {
            var requestJson = JsonConvert.SerializeObject(cust, Formatting.Indented);

            HttpClient client = new HttpClient();
            var result = await client.PostAsync(postDataUrl,new StringContent(requestJson, Encoding.UTF8, "application/json"));
            var json = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Agent>(json);
            return response;
        }

        public async Task<ResponseBase> UpdateAgent(Agent agent)
        {
            var requestJson = JsonConvert.SerializeObject(agent, Formatting.Indented);

            HttpClient client = new HttpClient();
            var result = await client.PostAsync(postDataUrl, new StringContent(requestJson, Encoding.UTF8, "application/json"));
            var json = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseBase>(json);
            return response;
        }

        public async Task<Agent> DeleteCustomer(int id)
        {
            // var requestJson = JsonConvert.SerializeObject(agent, Formatting.Indented);

            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync(this.localUrl + "/" + id);
            var json = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Agent>(json);
            return response;
        }
    }
}

