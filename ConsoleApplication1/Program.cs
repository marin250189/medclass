using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static  string input = "99"; 
        static  void Main(string[] args)
        {
            while (true)
            {
                Task t = new Task(ProcessRepositories);
                t.Start();

                 input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                    
                }

            }
           
           
        }
         static async void ProcessRepositories()
        {
            string msg = "";
           
            try
            {
               
                var byteArray = Encoding.ASCII.GetBytes("Compas:123Compas");
               // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("API_KEY", "f2lpF8mxLSbtk/Tg6mMu8g==");
             //   client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                string tt = JsonConvert.SerializeObject(new { Id = "14",FirstName = "Victor", LastName = "Marin" });
                StringContent queryString = new StringContent(tt, Encoding.UTF8, "application/json");



                HttpResponseMessage response = await client.PostAsync("http://localhost:49323/api/adduser", queryString);
                
            //   HttpResponseMessage response = await client.PostAsync("http://localhost:49323/api/deleteuser", queryString);
                //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response.EnsureSuccessStatusCode();
                 msg = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            
            Console.Write(msg);
        }

        static async void ProccessGet()
        {
            string msg = "";
           
            try
            {
                var byteArray = Encoding.ASCII.GetBytes("Compas:password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                
              
                var response =  client.GetAsync("http://localhost:49323/api/compas");
                 msg = await response.Result.Content.ReadAsStringAsync();

              
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            
            Console.Write(msg);
        }
    }
}
