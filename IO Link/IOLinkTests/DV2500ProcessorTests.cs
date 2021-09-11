using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO_Link;
using Xunit;
using Newtonsoft.Json;

namespace IOLinkTests
{
    public class DV2500ProcessorTests
    {
        [Theory]
        [InlineData(0, 1, true, "000000000001")]
        [InlineData(31, 2, false, "00000000001D")]
        [InlineData(5, 3, true, "000000000005")]
        [InlineData(6, 4, false, "000000000006")]
        [InlineData(7, 5, true, "000000000017")]
        [InlineData(23, 1, false, "000000000016")]
        [InlineData(2, 2, true, "000000000002")]
        [InlineData(4, 3, false, "000000000000")]
        [InlineData(15, 4, true, "00000000000F")]
        [InlineData(18, 5, false, "000000000002")]
        [InlineData(26, 1, true, "00000000001B")]
        public void HexstringShouldPass(int value, int segment, bool on, string expected)
        {
            DV2500Processor test = new DV2500Processor();
            Assert.Equal(expected, test.Hexstring(value, segment, on));
        }

        [Theory]
        [InlineData(1, true, "000000000001")]
        [InlineData(2, true, "000000000002")]
        [InlineData(3, true, "000000000004")]
        [InlineData(4, true, "000000000008")]
        [InlineData(5, true, "000000000010")]
        [InlineData(1, false, "000000000000")]
        [InlineData(2, false, "000000000000")]
        [InlineData(3, false, "000000000000")]
        [InlineData(4, false, "000000000000")]
        [InlineData(5, false, "000000000000")]
        [InlineData(23425, false, "000000000000")]
        [InlineData(-23425, false, "000000000000")]
        [InlineData(23425, true, "000000000000")]
        [InlineData(-23425, true, "000000000000")]
        public void HexstringFirstCallShouldPass(int segment, bool on, string expected)
        {
            DV2500Processor test = new DV2500Processor();
            Assert.Equal(expected, test.HexstringFirstCall(segment, on));
        }

        public static IEnumerable<object[]> TestInitialiseObjectWorking =>
        new List<object[]>
        {
            new object[] {1, 31, 2, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[1]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "00000000001D" } }},
            new object[] {2, 0, 1, true, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[2]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000001" } }},
            new object[] {3, 23, 2, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[3]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000015" } }},
            new object[] {4, 11, 3, true, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[4]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "00000000000F" } }},
            new object[] {5, 16, 4, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[5]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000010" } }},
            new object[] {6, 3, 5, true, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[6]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000013" } }},
            new object[] {7, 5, 4, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[7]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000005" } }},
            new object[] {8, 26, 3, true, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[8]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "00000000001E" } }},
            new object[] {6, 18, 2, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[6]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000010" } }},
            new object[] {3, 9, 1, true, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[3]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "000000000009" } }},
            new object[] {4, 30, 3, false, new IOLinkPDOut {code = "request", cid = 1, 
                adr = "/iolinkmaster/port[4]/iolinkdevice/pdout/setdata", data = new IOLinkPDOutData { newvalue = "00000000001A" } }},
        };        

        [Theory]
        [MemberData(nameof(TestInitialiseObjectWorking))]
        public void InitialiseObjectlShouldPass(int port_number, int prev_status, int segment, bool on, IOLinkPDOut expected)
        {
            DV2500Processor test = new DV2500Processor();
            IOLinkPDOut returned = test.InitialiseObject(port_number, segment, prev_status, on);
            Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(returned));            
        }


        //Test with DV2500 pluged into port 2
        [Theory]
        [InlineData("http://192.168.0.10/iolinkmaster/port[2]/iolinkdevice/productname/getdata", true)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[1]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[3]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[4]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[5]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[6]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[7]/iolinkdevice/productname/getdata", false)]
        [InlineData("http://192.168.0.10/iolinkmaster/port[8]/iolinkdevice/productname/getdata", false)]
        public async void CheckIfDV2500IsConnectedShouldWork(string url, bool expected)
        {
            ifmApiClient.InitializeClient();
            DV2500Processor test = new DV2500Processor();
            bool result = await test.CheckIfDV2500IsConnected(url);
            ifmApiClient.client.Dispose();
            Assert.Equal(expected, result);
        }

        //Invalid Operation Exception
        [Theory]
        [InlineData("2343aq")]
        [InlineData("2342343aq")]
        [InlineData("as5kl")]
        public async void CheckIfDV2500IsConnectedShoulThrowInvalidOperationException(string url)
        {
            ifmApiClient.InitializeClient();
            DV2500Processor test = new DV2500Processor();  
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await test.CheckIfDV2500IsConnected(url));
            ifmApiClient.client.Dispose();
        }

        //Uri Format Exception
        [Theory]
        [InlineData("http://23 3423/gettree")]
        [InlineData("http://a d234/gettree")]
        [InlineData("http://ewea ga2323 3423")]
        public async void CheckIfDV2500IsConnectedShoulThrowException(string url)
        {
            ifmApiClient.InitializeClient();
            DV2500Processor test = new DV2500Processor();
            await Assert.ThrowsAsync<UriFormatException>(async () => await test.CheckIfDV2500IsConnected(url));
            ifmApiClient.client.Dispose();
        }


    }
}
