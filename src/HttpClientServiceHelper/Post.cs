﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    public partial class HttpClientHelper
    {
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns>An HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PostAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Token"></param>
        /// <returns>An HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PostAsync(string Route, object Model, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns>a string response of the HTTP Response Message</returns> 
        public static async Task<string> PostAndGetResponseAsStringAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Token"></param>
        /// <returns>a string response of the HTTP Response Message</returns> 
        public static async Task<string> PostAndGetResponseAsStringAsync(string Route, object Model, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
