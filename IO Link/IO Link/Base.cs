using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace IO_Link
{
    public partial class Base : Form
    {
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

        public Base()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtbox_ipaddress.Text = "192.168.0.10";
        }

        private async void read_IO_Link_port(int port_number)
        {
            txtbox_processdata.Clear();
            txtbox_part_number.Clear();
            HttpClient client = new HttpClient();
            try
            {
                string response_name = await client.GetStringAsync("http://" + txtbox_ipaddress.Text + "/iolinkmaster/port[" + port_number + "]/iolinkdevice/productname/getdata");
                Response port_partnumber = JsonConvert.DeserializeObject<Response>(response_name);
                if (port_partnumber.code == 200)
                {
                    txtbox_part_number.Text = port_partnumber.data.value;
                    string response_data = await client.GetStringAsync("http://" + txtbox_ipaddress.Text + "/iolinkmaster/port[" + port_number + "]/iolinkdevice/pdin/getdata");
                    Response port_processdata = JsonConvert.DeserializeObject<Response>(response_data);
                    if (port_partnumber.data.value == "OGD592")
                    {
                        int distance = int.Parse(port_processdata.data.value.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
                        int reflectivity = int.Parse(port_processdata.data.value.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        txtbox_processdata.AppendText("Distance  " + distance);
                        txtbox_processdata.AppendText(Environment.NewLine);
                        txtbox_processdata.AppendText("Reflectivity " + reflectivity);
                    }
                }
                else
                {
                    txtbox_part_number.Text = "No sensor connected";
                    txtbox_processdata.Clear();
                    txtbox_processdata.Text = "Invalid data";
                }
            }
            catch (Exception ex)
            {
                txtbox_ipaddress.Text = "Enter a valid IP address";
            }
            client.Dispose();
        }

        private void btn_port1_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(1);
        }

        private void btn_port2_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(2);
        }
        private void btn_port3_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(3);
        }

        private void btn_port4_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(4);
        }

        private void btn_port5_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(5);
        }

        private void btn_port6_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(6);
        }

        private void btn_port7_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(7);
        }

        private void btn_port8_Click(object sender, EventArgs e)
        {
            read_IO_Link_port(8);
        }

        private void btn_httpget_Click(object sender, EventArgs e)
        {
            HTTP_GET http_get = new HTTP_GET();
            http_get.ShowDialog();
        }

        private void btn_httppost_Click(object sender, EventArgs e)
        {
            HTTP_POST http_post = new HTTP_POST();
            http_post.ShowDialog();
        }

        private void btn_DV2500_Click(object sender, EventArgs e)
        {
            DV2500_Output dv2500 = new DV2500_Output(txtbox_ipaddress.Text);
            dv2500.ShowDialog();
        }
    }
}
