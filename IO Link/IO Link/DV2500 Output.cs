using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace IO_Link
{
    public partial class DV2500_Output : Form
    {
        private Regex rgx = new Regex("^[1-8]$");
        private string url;        
        private IOLinkPDOut pdout;
        private IOLinkResponse prev_pdout;
        private IOLinkResponse response;
        ifmAPIRequest request;
        bool first_call;
        int prev_stacklight_status = 0;
        public DV2500_Output(string ip_address)
        {
            InitializeComponent();
            url = $"http://{ip_address}";
            pdout = new IOLinkPDOut();
            pdout.data = new IOLinkPDOutData();
            request = new ifmAPIRequest();
            first_call = true;
        }            
        private string Hexstring(int value, int segment, bool on)
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
        private string HexstringFirstCall(int segment, bool on)
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
        private IOLinkPDOut InitialiseObject(int port_number, int segment, int prev_status, bool on)
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
            first_call = false;
            return output;
        }                      

        private async Task SendCommand(string port, bool on, int segment)
        {            
            if (rgx.IsMatch(port))
            {
                if (first_call)
                {
                    prev_stacklight_status = 100;
                    pdout = InitialiseObject(int.Parse(txt_portnumber.Text), segment, prev_stacklight_status, on);
                    response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
                }
                else
                {
                    prev_pdout = await request.GetRequest($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/pdout/getdata");
                    prev_stacklight_status = int.Parse(prev_pdout.data.value, System.Globalization.NumberStyles.HexNumber);
                    pdout = InitialiseObject(int.Parse(txt_portnumber.Text), segment, prev_stacklight_status, on);
                    response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
                }
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private async void btn_seg1on_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, true, 1);                        
        }

        private async void btn_seg1off_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, false, 1);
        }

        private async void btn_seg2on_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, true, 2);
        }

        private async void btn_seg2off_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, false, 2);
        }

        private async void btn_seg3on_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, true, 3);
        }

        private async void btn_seg3off_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, false, 3);
        }

        private async void btn_seg4on_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, true, 4);
        }

        private async void btn_seg4off_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, false, 4);
        }

        private async void btn_seg5on_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, true, 5);
        }

        private async void btn_seg5off_Click(object sender, EventArgs e)
        {
            await SendCommand(txt_portnumber.Text, false, 5);
        }

        private async void btn_allon_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {                
                pdout = InitialiseObject(int.Parse(txt_portnumber.Text), 6, prev_stacklight_status, true);
                response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private async void btn_alloff_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {                
                pdout = InitialiseObject(int.Parse(txt_portnumber.Text), 0, prev_stacklight_status, true);
                response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }
    }
}
