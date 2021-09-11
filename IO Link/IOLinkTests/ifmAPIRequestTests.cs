using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IO_Link;
using Newtonsoft.Json;


namespace IOLinkTests
{
    public class ifmAPIRequestTests
    {
        [Theory]
        [InlineData("http://192.168.0.10/iolinkmaster/port[2]/iolinkdevice/productname/getdata")]
        [InlineData("http://192.168.0.10/gettree")]
        [InlineData("http://192.168.0.10/iolinkmaster/port[1]/iolinkdevice/productname/getdata")]        
        [InlineData("http://192.168.0.10/iolinkmaster/port[1]/iolinkdevice/pdin/getdata")]
        [InlineData("http://192.168.0.10/iolinkmaster/port[2]/iolinkdevice/pdout/getdata")]        
        [InlineData("http://192.168.0.10/processdatamaster/temperature/getdata")]
        public async void GetRequestShouldWork(string url)
        {
            ifmApiClient.InitializeClient();
            ifmAPIRequest request = new ifmAPIRequest();
            IOLinkResponse reply = await request.GetRequest(url);
            Assert.True(reply.code==200);
            ifmApiClient.client.Dispose();
        }

        public static IEnumerable<object[]> TestPostRequestWorking =>
        new List<object[]>
        {
            new object[] {"http://192.168.0.10", new IOLinkPDOut {code = "request", cid = 1,
                adr = "/iolinkmaster/port[2]/iolinkdevice/productname/getdata", data = null }},
            new object[] {"http://192.168.0.10", new IOLinkPDOut {code = "request", cid = 1,
                adr = "/iolinkmaster/port[1]/iolinkdevice/productname/getdata", data = null }},
            new object[] {"http://192.168.0.10", new IOLinkPDOut {code = "request", cid = 1,
                adr = "/iolinkmaster/port[1]/iolinkdevice/pdin/getdata", data = null }},
            new object[] {"http://192.168.0.10", new IOLinkPDOut {code = "request", cid = 1,
                adr = "/processdatamaster/temperature/getdata", data = null }},
        };

        [Theory]
        [MemberData(nameof(TestPostRequestWorking))]
        public async void PostRequestShouldWork(string url, IOLinkPDOut data)
        {
            ifmApiClient.InitializeClient();
            ifmAPIRequest request = new ifmAPIRequest();
            IOLinkResponse reply = await request.PostRequest(url, JsonConvert.SerializeObject(data));
            Assert.True(reply.code == 200);
            ifmApiClient.client.Dispose();
        }
    }
}
