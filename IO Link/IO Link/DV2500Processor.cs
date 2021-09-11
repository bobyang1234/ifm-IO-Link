using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Link
{
    public class DV2500Processor
    {       
        public string Hexstring(int value, int segment, bool on)
        {
            if (on)
            {
                value |= 1 << (segment - 1);
            }
            else
            {
                value &= ~(1 << (segment - 1));
            }
            if (value > 15)
            {
                return "0000000000" + value.ToString("X");
            }
            else
            {
                return "00000000000" + value.ToString("X");
            }
        }
        public string HexstringFirstCall(int segment, bool on)
        {
            if (!on)
            {
                return "000000000000";
            }
            else
            {
                switch (segment)
                {
                    case 1:
                        return "000000000001";
                    case 2:
                        return "000000000002";
                    case 3:
                        return "000000000004";
                    case 4:
                        return "000000000008";
                    case 5:
                        return "000000000010";
                    default:
                        return "000000000000";
                }
            }
        }
        public IOLinkPDOut InitialiseObject(int port_number, int segment, int prev_status, bool on)
        {
            IOLinkPDOut output = new IOLinkPDOut();
            output.data = new IOLinkPDOutData();
            output.adr = $"/iolinkmaster/port[{ port_number}]/iolinkdevice/pdout/setdata";
            output.code = "request";
            output.cid = 1;

            if (segment == 0)
            {
                output.data.newvalue = "000000000000";
            }
            else if (segment == 6)
            {
                output.data.newvalue = "00000000001F";
            }
            else if (prev_status == 100)
            {
                output.data.newvalue = HexstringFirstCall(segment, on);
            }
            else
            {
                output.data.newvalue = Hexstring(prev_status, segment, on);
            }
            return output;
        }

        public async Task<bool> CheckIfDV2500IsConnected(string url)
        {
            ifmAPIRequest request = new ifmAPIRequest();
            IOLinkResponse reply = await request.GetRequest(url);
            if(reply.data == null)
            {
                return false;
            }
            else if (reply.data.value == "DV2500")
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

    }
}
