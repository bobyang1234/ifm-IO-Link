
namespace IO_Link
{
    partial class HTTP_GET
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_sendcmd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbox_response = new System.Windows.Forms.TextBox();
            this.btn_prettyjson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbox_url
            // 
            this.txtbox_url.Location = new System.Drawing.Point(221, 53);
            this.txtbox_url.Name = "txtbox_url";
            this.txtbox_url.Size = new System.Drawing.Size(497, 20);
            this.txtbox_url.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // btn_sendcmd
            // 
            this.btn_sendcmd.Location = new System.Drawing.Point(160, 98);
            this.btn_sendcmd.Name = "btn_sendcmd";
            this.btn_sendcmd.Size = new System.Drawing.Size(87, 38);
            this.btn_sendcmd.TabIndex = 2;
            this.btn_sendcmd.Text = "Send Command";
            this.btn_sendcmd.UseVisualStyleBackColor = true;
            this.btn_sendcmd.Click += new System.EventHandler(this.btn_sendcmd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Response";
            // 
            // txtbox_response
            // 
            this.txtbox_response.Location = new System.Drawing.Point(221, 158);
            this.txtbox_response.Multiline = true;
            this.txtbox_response.Name = "txtbox_response";
            this.txtbox_response.ReadOnly = true;
            this.txtbox_response.Size = new System.Drawing.Size(497, 183);
            this.txtbox_response.TabIndex = 4;
            // 
            // btn_prettyjson
            // 
            this.btn_prettyjson.Location = new System.Drawing.Point(271, 98);
            this.btn_prettyjson.Name = "btn_prettyjson";
            this.btn_prettyjson.Size = new System.Drawing.Size(87, 38);
            this.btn_prettyjson.TabIndex = 5;
            this.btn_prettyjson.Text = "Pretty JSON";
            this.btn_prettyjson.UseVisualStyleBackColor = true;
            this.btn_prettyjson.Click += new System.EventHandler(this.btn_prettyjson_Click);
            // 
            // HTTP_GET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_prettyjson);
            this.Controls.Add(this.txtbox_response);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_sendcmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_url);
            this.Name = "HTTP_GET";
            this.Text = "HTTP_GET";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_sendcmd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox_response;
        private System.Windows.Forms.Button btn_prettyjson;
    }
}