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
        string io_link_ip;
        Regex rgx = new Regex("^[1-8]$");
        public DV2500_Output(string ip_address)
        {
            InitializeComponent();
            io_link_ip = ip_address;
        }

        public class Data
        {
            public string newvalue { get; set; }
        }

        public class PDOut
        {
            public string code { get; set; }
            public int cid { get; set; }
            public string adr { get; set; }
            public Data data { get; set; }
        }

        public class Databack
        {
            public string value { get; set; }
        }

        public class Response
        {
            public int cid { get; set; }
            public Databack data { get; set; }
            public int code { get; set; }
        }
        public string hexstring(int value, int segment, bool on)
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
        private async void DV2500_pdout(int port_number, int segment, bool on)
        {
            HttpClient client = new HttpClient();
            PDOut pdout = new PDOut();
            pdout.adr = "iolinkmaster/port[" + port_number + "]/iolinkdevice/pdout/setdata";
            pdout.code = "request";
            pdout.cid = 1;
            if (segment == 0)
            {
                pdout.data = new Data();
                pdout.data.newvalue = "000000000000";
            }
            else if (segment == 6)
            {
                pdout.data = new Data();
                pdout.data.newvalue = "00000000001F";
            }
            else
            {
                pdout.data = new Data();
                var getdata = await client.GetStringAsync("http://" + io_link_ip + "/iolinkmaster/port[" + port_number + "]/iolinkdevice/pdout/getdata");
                Response prev_data = JsonConvert.DeserializeObject<Response>(getdata);
                int output = int.Parse(prev_data.data.value, System.Globalization.NumberStyles.HexNumber);
                pdout.data.newvalue = hexstring(output, segment, on);              
            }
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(pdout);
            var reply = await client.PostAsync("http://" + io_link_ip, new StringContent(jsonString, Encoding.UTF8, "application/json"));            
            client.Dispose();
        }                      

        private void btn_seg1on_Click(object sender, EventArgs e)
        {            
            if(rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 1, true);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }            
        }

        private void btn_seg1off_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 1, false);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg2on_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 2, true);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg2off_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 2, false);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg3on_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 3, true);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg3off_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 3, false);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg4on_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 4, true);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg4off_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 4, false);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg5on_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 5, true);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_seg5off_Click(object sender, EventArgs e)
        {
            if (rgx.IsMatch(txt_portnumber.Text))
            {
                DV2500_pdout(int.Parse(txt_portnumber.Text), 5, false);
            }
            else
            {
                txt_portnumber.Text = "Enter a valid port";
            }
        }

        private void btn_allon_Click(object sender, EventArgs e)
        {
            DV2500_pdout(int.Parse(txt_portnumber.Text), 6, true);
        }

        private void btn_alloff_Click(object sender, EventArgs e)
        {
            DV2500_pdout(int.Parse(txt_portnumber.Text), 0, false);
        }
    }
}
