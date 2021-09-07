﻿using Newtonsoft.Json;
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
        public HTTP_GET()
        {
            InitializeComponent();            
        }        
        private async void http_get_request(string url)
        {
            txtbox_response.Clear();            
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            txtbox_response.Text = response;  
            client.Dispose();
        }
        private void btn_sendcmd_Click(object sender, EventArgs e)
        {
            http_get_request(txtbox_url.Text);
        }

        private void btn_prettyjson_Click(object sender, EventArgs e)
        {
            txtbox_response.Text = JToken.Parse(txtbox_response.Text).ToString();
        }
    }
}
