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
    public partial class HTTP_POST : Form
    {
        public HTTP_POST()
        {
            InitializeComponent();
        }
        private async void http_post_request(string url, string json)
        {
            txtbox_response.Clear();
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    txtbox_response.Text = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    txtbox_response.Text = response.StatusCode.ToString();
                }    
            }
            catch (Exception ex)
            {
                txtbox_response.Text = ex.Message;
            }            
            client.Dispose();
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

        private void btn_sendcmd_Click(object sender, EventArgs e)
        {
            http_post_request(txtbox_url.Text, txtbox_body.Text);
        }

        
    }
}
