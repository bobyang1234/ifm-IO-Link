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
        private void btn_prettyjson_Click(object sender, EventArgs e)
        {
            try
            {
                txtbox_response.Text = JToken.Parse(txtbox_response.Text).ToString();
            }
            catch (JsonReaderException jex)
            {
                txtbox_response.Text = jex.Message;
            }
            catch (Exception ex)
            {
                txtbox_response.Text = ex.Message;
            }
            try
            {
                txtbox_body.Text = JToken.Parse(txtbox_body.Text).ToString();
            }
            catch (JsonReaderException jex)
            {
                txtbox_body.Text = jex.Message;
            }
            catch (Exception ex)
            {
                txtbox_body.Text = ex.Message;
            }                                 
        }

        private async void btn_sendcmd_Click(object sender, EventArgs e)
        {
            post_reply = await request.PostRequest(txtbox_url.Text, txtbox_body.Text);
            txtbox_response.Text = JsonConvert.SerializeObject(post_reply);
        }

        
    }
}
