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
    public partial class HTTP_POST : Form
    {
        private ifmAPIRequest request;
        private IOLinkResponse post_reply;
            
        public HTTP_POST()
        {
            InitializeComponent();
            request = new ifmAPIRequest();
        }
        
        private void btn_prettyjsonbody_Click(object sender, EventArgs e)
        {
            txtbox_exception.Clear();
            try
            {
                txtbox_body.Text = JToken.Parse(txtbox_body.Text).ToString();
                lbl_exception.Visible = false;
                txtbox_exception.Visible = false;
            }
            catch (JsonReaderException)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.AppendText("Body textbox does not contain valid JSON" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.Message;
            }
        }

        private void btn_prettyjsonresponse_Click(object sender, EventArgs e)
        {
            txtbox_exception.Clear();
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
                txtbox_exception.AppendText("Response textbox does not contain valid JSON" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                lbl_exception.Visible = true;
                txtbox_exception.Visible = true;
                txtbox_exception.Text = ex.Message;
            }
        }

        private async void btn_sendcmd_Click(object sender, EventArgs e)
        {
            try
            {
                post_reply = await request.PostRequest(txtbox_url.Text, txtbox_body.Text);
                txtbox_response.Text = JsonConvert.SerializeObject(post_reply);
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
    }
}
