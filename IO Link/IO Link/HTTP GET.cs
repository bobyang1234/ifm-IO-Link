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
            response = await request.GetRequest(txtbox_url.Text);
            txtbox_response.Text = JsonConvert.SerializeObject(response);
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
            catch(Exception ex)
            {
                txtbox_response.Text = ex.Message;
            }
        }
    }
}
