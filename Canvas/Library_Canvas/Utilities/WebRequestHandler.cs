﻿//using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Library_Canvas.DTO;
using static System.Net.WebRequestMethods;

namespace Library_Canvas.Utilities
{
    public class WebRequestHandler
    {
        private string host = "localhost";
        private string port = "5149";
        private HttpClient Client { get; }
        public WebRequestHandler()
        {
            Client = new HttpClient();
        }
        public async Task<string> Get(string url)
        {
            var fullUrl = $"https://{host}:{port}{url}";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(fullUrl).ConfigureAwait(false);
                    return response;
                }
            } catch(Exception e)
            {

            }


            return null;
        }

        public async Task<string> Delete(string url)
        {
            var fullUrl = $"https://{host}:{port}{url}";
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, fullUrl))
                    {
                        using (var response = await client
                                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


            return null;
        }

        public async Task<string> Post(string url, object obj)
        {
            var fullUrl = $"https://{host}:{port}{url}";
            using (var client = new HttpClient())
            {
                using(var request = new HttpRequestMessage(HttpMethod.Post, fullUrl))
                {
                    var json = JsonSerializer.Serialize(obj);
                    using(var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using(var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if(response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
        }
    }
}
