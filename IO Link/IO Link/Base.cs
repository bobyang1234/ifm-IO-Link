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
        private ifmAPIRequest request;
        private IOLinkResponse part_number;
        private IOLinkResponse process_data;        
        public Base()
        {
            InitializeComponent();
            ifmApiClient.InitializeClient();
            request = new ifmAPIRequest();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtbox_ipaddress.Text = "192.168.0.10";
        }

        private void ClearAllTextbox()
        {
            txtbox_processdata.Clear();
            txtbox_part_number.Clear();
        }

        private void DisplayValues(IOLinkResponse part_num, IOLinkResponse data)
        {
            if (part_num.code == 200)
            {
                txtbox_part_number.Text = part_num.data.value;
                if (part_num.data.value == "OGD592")
                {
                    int distance = int.Parse(data.data.value.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
                    int reflectivity = int.Parse(data.data.value.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    txtbox_processdata.AppendText($"Distance {distance}");
                    txtbox_processdata.AppendText(Environment.NewLine);
                    txtbox_processdata.AppendText($"Reflectivity  {reflectivity}");
                }
            }
            else
            {
                txtbox_part_number.Text = "No sensor connected";
                txtbox_processdata.Clear();
                txtbox_processdata.Text = "Invalid data";
            }
        }
        private async void btn_port1_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[1]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[1]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port2_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[2]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[2]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }
        private async void btn_port3_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[3]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[3]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port4_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[4]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[4]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port5_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[5]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[5]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port6_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[6]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[6]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port7_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[7]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[7]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
        }

        private async void btn_port8_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            part_number = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[8]/iolinkdevice/productname/getdata");
            process_data = await request.GetRequest($"http://{txtbox_ipaddress.Text}/iolinkmaster/port[8]/iolinkdevice/pdin/getdata");
            DisplayValues(part_number, process_data);
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
