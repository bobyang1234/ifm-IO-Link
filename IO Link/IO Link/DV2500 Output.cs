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
        private ifmAPIRequest request;
        private DV2500Processor dv2500_processor;
        private bool first_call;
        private int prev_stacklight_status = 0;
        public DV2500_Output(string ip_address)
        {
            InitializeComponent();
            url = $"http://{ip_address}";
            pdout = new IOLinkPDOut();
            pdout.data = new IOLinkPDOutData();
            request = new ifmAPIRequest();
            first_call = true;
            dv2500_processor = new DV2500Processor();
        }                                   

        private async Task SendCommand(string port, bool on, int segment)
        {            
            if (first_call)
            {
                prev_stacklight_status = 100;
                pdout = dv2500_processor.InitialiseObject(int.Parse(txt_portnumber.Text), segment, prev_stacklight_status, on);
                response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
                if (response.code == 200)
                {
                    first_call = false;
                }
            }
            else
            {
                prev_pdout = await request.GetRequest($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/pdout/getdata");
                prev_stacklight_status = int.Parse(prev_pdout.data.value, System.Globalization.NumberStyles.HexNumber);
                pdout = dv2500_processor.InitialiseObject(int.Parse(txt_portnumber.Text), segment, prev_stacklight_status, on);
                response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
            }                        
        }

        private async void btn_seg1on_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, true, 1);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }                      
        }

        private async void btn_seg1off_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, false, 1);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg2on_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, true, 2);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg2off_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, false, 2);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg3on_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, true, 3);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }
        }

        private async void btn_seg3off_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, false, 3);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg4on_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, true, 4);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }
        }

        private async void btn_seg4off_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, false, 4);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg5on_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, true, 5);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_seg5off_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        await SendCommand(txt_portnumber.Text, false, 5);
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }
        }

        private async void btn_allon_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        pdout = dv2500_processor.InitialiseObject(int.Parse(txt_portnumber.Text), 6, prev_stacklight_status, true);
                        response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }

        private async void btn_alloff_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgx.IsMatch(txt_portnumber.Text))
                {
                    if (await dv2500_processor.CheckIfDV2500IsConnected($"{url}/iolinkmaster/port[{txt_portnumber.Text}]/iolinkdevice/productname/getdata"))
                    {
                        pdout = dv2500_processor.InitialiseObject(int.Parse(txt_portnumber.Text), 0, prev_stacklight_status, true);
                        response = await request.PostRequest(url, JsonConvert.SerializeObject(pdout));
                        lbl_exception.Visible = false;
                        txtbox_exception.Visible = false;
                    }
                    else
                    {
                        txt_portnumber.Text = "There is no DV2500 connected on this port";
                    }
                }
                else
                {
                    txt_portnumber.Text = "Please enter a valid port between 1-8";
                }
            }
            catch (Exception ex)
            {
                txt_portnumber.Text = "Please enter a valid port between 1-8";
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.ToString();
            }            
        }
    }
}
