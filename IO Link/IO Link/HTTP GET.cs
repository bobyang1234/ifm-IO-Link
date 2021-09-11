using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace IO_Link
{
    public partial class HTTP_GET : Form
    {
        private ifmAPIRequest request;
        private IOLinkResponse response;
        public HTTP_GET()
        {
            InitializeComponent();
            request = new ifmAPIRequest();
        }        
        private async void btn_sendcmd_Click(object sender, EventArgs e)
        {
            try
            {
                response = await request.GetRequest(txtbox_url.Text);
                txtbox_response.Text = JsonConvert.SerializeObject(response);
                lbl_exception.Visible = false;
                txtbox_exception.Visible = false;
            }
            catch (Exception ex)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.Message;
            }
        }

        private void btn_prettyjson_Click(object sender, EventArgs e)
        {
            try
            {
                txtbox_response.Text = JToken.Parse(txtbox_response.Text).ToString();
                lbl_exception.Visible = false;
                txtbox_exception.Visible = false;
            }
            catch (JsonReaderException)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = "Response does not contain valid JSON";
            }
            catch(Exception ex)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.Message;
            }
        }
    }
}
