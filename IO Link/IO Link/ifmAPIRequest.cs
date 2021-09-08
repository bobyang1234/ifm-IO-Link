using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IO_Link
{
    public class ifmAPIRequest
    {

        public async Task<IOLinkResponse> GetRequest(string url)
        {
            using (HttpResponseMessage message = await ifmApiClient.client.GetAsync(url))
            {
                if(message.IsSuccessStatusCode)
                {
                    IOLinkResponse data = await message.Content.ReadAsAsync<IOLinkResponse>();
                    return data;
                }
                else
                {
                    throw new Exception(message.ReasonPhrase);
                }
            }
        }

        public async Task<IOLinkResponse> PostRequest(string url, string json)
        {
            using (HttpResponseMessage message = await ifmApiClient.client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")))
            {
                if(message.IsSuccessStatusCode)
                {
                    IOLinkResponse data = await message.Content.ReadAsAsync<IOLinkResponse>();
                    return data;
                }
                else
                {
                    throw new Exception(message.ReasonPhrase);
                }
            }
        }

    }
}
