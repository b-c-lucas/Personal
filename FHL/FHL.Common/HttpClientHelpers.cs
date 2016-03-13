using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;

namespace FHL.Common
{
    public static class HttpClientHelpers
    {
        public static HttpClient GetHttpClientWithCaching()
        {
            return new HttpClient(
                new WebRequestHandler
                {
                    CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default)
                });
        }


        public static async Task<TOut> DeserializeResponseAsync<TOut>(HttpClient httpClient, string url, JsonSerializer jsonSerializer)
        {
            using (var s = await httpClient.GetStreamAsync(url))
            {
                return DeserializeResponse<TOut>(s, jsonSerializer);
            }
        }


        public static async Task<TOut> DeserializeResponseAsync<TOut>(HttpClient httpClient, Uri uri, JsonSerializer jsonSerializer)
        {
            using (var s = await httpClient.GetStreamAsync(uri))
            {
                return DeserializeResponse<TOut>(s, jsonSerializer);
            }
        }

        public static async Task<TOut> DeserializeResponseAsync<TOut>(HttpResponseMessage responseMessage, JsonSerializer jsonSerializer)
        {
            using (var s = await responseMessage.Content.ReadAsStreamAsync())
            {
                return DeserializeResponse<TOut>(s, jsonSerializer);
            }
        }

        private static TOut DeserializeResponse<TOut>(Stream stream, JsonSerializer jsonSerializer)
        {
            using (var sr = new StreamReader(stream))
            using (var reader = new JsonTextReader(sr))
            {
                return jsonSerializer.Deserialize<TOut>(reader);
            }
        }
    }
}