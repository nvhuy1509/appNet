using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class AppService : IAppService
    {
        private string _baseUrl = "https://stemschool.vn";

        private static string token = "";
        public async Task<string> Login(LoginModel loginModel)
        {
            string returnStr  = string.Empty;
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.Login}";

                var serializedStr = JsonConvert.SerializeObject(loginModel) ;
                try
                {
                    var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        returnStr = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Root>(returnStr);
                        if(data.success == true)
                        {
                            token = data.data.token;
                        }
                    }
                } catch (Exception ex)
                {
                    returnStr = ex.Message;
                }
                
                return returnStr ;
            }
        }
        
        public async Task<List<ListFileModel>> GetFilePublished()
        {
            List<ListFileModel> resultList = new List<ListFileModel>();
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.GetFilePublished}";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync() ;
                    resultList = JsonConvert.DeserializeObject<List<ListFileModel>>(content);
                }
                return resultList;
            }
        }
    }
    public class Data
    {
        public string id { get; set; }
        public string phonenumber { get; set; }
        public object email { get; set; }
        public string token { get; set; }
        public int lifetimetoken { get; set; }
    }

    public class Root
    {
        public object message { get; set; }
        public bool success { get; set; }
        public Data data { get; set; }
    }

}
