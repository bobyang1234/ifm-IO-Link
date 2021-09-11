
namespace IO_Link
{
    partial class HTTP_POST
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
            this.btn_prettyjsonbody = new System.Windows.Forms.Button();
            this.txtbox_response = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_sendcmd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_url = new System.Windows.Forms.TextBox();
            this.txtbox_body = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_normalbody = new System.Windows.Forms.TextBox();
            this.txtbox_databody = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_exception = new System.Windows.Forms.Label();
            this.txtbox_exception = new System.Windows.Forms.TextBox();
            this.btn_prettyjsonresponse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_prettyjsonbody
            // 
            this.btn_prettyjsonbody.Location = new System.Drawing.Point(252, 69);
            this.btn_prettyjsonbody.Name = "btn_prettyjsonbody";
            this.btn_prettyjsonbody.Size = new System.Drawing.Size(87, 38);
            this.btn_prettyjsonbody.TabIndex = 11;
            this.btn_prettyjsonbody.Text = "Pretty JSON";
            this.btn_prettyjsonbody.UseVisualStyleBackColor = true;
            this.btn_prettyjsonbody.Click += new System.EventHandler(this.btn_prettyjsonbody_Click);
            // 
            // txtbox_response
            // 
            this.txtbox_response.Location = new System.Drawing.Point(459, 129);
            this.txtbox_response.Multiline = true;
            this.txtbox_response.Name = "txtbox_response";
            this.txtbox_response.ReadOnly = true;
            this.txtbox_response.Size = new System.Drawing.Size(240, 183);
            this.txtbox_response.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Response";
            // 
            // btn_sendcmd
            // 
            this.btn_sendcmd.Location = new System.Drawing.Point(141, 69);
            this.btn_sendcmd.Name = "btn_sendcmd";
            this.btn_sendcmd.Size = new System.Drawing.Size(87, 38);
            this.btn_sendcmd.TabIndex = 8;
            this.btn_sendcmd.Text = "Send Command";
            this.btn_sendcmd.UseVisualStyleBackColor = true;
            this.btn_sendcmd.Click += new System.EventHandler(this.btn_sendcmd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "URL";
            // 
            // txtbox_url
            // 
            this.txtbox_url.Location = new System.Drawing.Point(202, 24);
            this.txtbox_url.Name = "txtbox_url";
            this.txtbox_url.Size = new System.Drawing.Size(497, 20);
            this.txtbox_url.TabIndex = 6;
            // 
            // txtbox_body
            // 
            this.txtbox_body.Location = new System.Drawing.Point(131, 128);
            this.txtbox_body.Multiline = true;
            this.txtbox_body.Name = "txtbox_body";
            this.txtbox_body.Size = new System.Drawing.Size(240, 183);
            this.txtbox_body.TabIndex = 13;
            this.txtbox_body.Text = "Enter your JSON object here to send";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Body";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Sample Body";
            // 
            // txtbox_normalbody
            // 
            this.txtbox_normalbody.Location = new System.Drawing.Point(21, 422);
            this.txtbox_normalbody.Multiline = true;
            this.txtbox_normalbody.Name = "txtbox_normalbody";
            this.txtbox_normalbody.ReadOnly = true;
            this.txtbox_normalbody.Size = new System.Drawing.Size(263, 131);
            this.txtbox_normalbody.TabIndex = 16;
            this.txtbox_normalbody.Text = "{\r\n\"code\":\"request\",\r\n\"cid\":4711,\r\n\"adr\":\"rest of the URL goes here\"\r\n}";
            // 
            // txtbox_databody
            // 
            this.txtbox_databody.Location = new System.Drawing.Point(286, 422);
            this.txtbox_databody.Multiline = true;
            this.txtbox_databody.Name = "txtbox_databody";
            this.txtbox_databody.ReadOnly = true;
            this.txtbox_databody.Size = new System.Drawing.Size(263, 131);
            this.txtbox_databody.TabIndex = 17;
            this.txtbox_databody.Text = "{\r\n\"code\":\"request\",\r\n\"cid\":10,\r\n\"adr\":\"rest of the URL goes here\",\r\n\"data\":{\"new" +
    "value\":\"enter value as a HEX string\"}\r\n}";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(555, 422);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(252, 131);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "{\r\n\"code\":\"request\",\r\n\"cid\":4711,\r\n\"adr\":\"rest of the URL goes here\",\r\n\"data\":{\"i" +
    "ndex\":%d,\"subindex\":%d,\"value\":\"hex string\"}\r\n}\r\n\r\nRemove value when doing acycl" +
    "ic read";
            // 
            // lbl_exception
            // 
            this.lbl_exception.AutoSize = true;
            this.lbl_exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exception.Location = new System.Drawing.Point(123, 327);
            this.lbl_exception.Name = "lbl_exception";
            this.lbl_exception.Size = new System.Drawing.Size(73, 18);
            this.lbl_exception.TabIndex = 23;
            this.lbl_exception.Text = "Exception";
            this.lbl_exception.Visible = false;
            // 
            // txtbox_exception
            // 
            this.txtbox_exception.Location = new System.Drawing.Point(202, 327);
            this.txtbox_exception.Multiline = true;
            this.txtbox_exception.Name = "txtbox_exception";
            this.txtbox_exception.ReadOnly = true;
            this.txtbox_exception.Size = new System.Drawing.Size(497, 52);
            this.txtbox_exception.TabIndex = 22;
            this.txtbox_exception.Visible = false;
            // 
            // btn_prettyjsonresponse
            // 
            this.btn_prettyjsonresponse.Location = new System.Drawing.Point(612, 69);
            this.btn_prettyjsonresponse.Name = "btn_prettyjsonresponse";
            this.btn_prettyjsonresponse.Size = new System.Drawing.Size(87, 38);
            this.btn_prettyjsonresponse.TabIndex = 24;
            this.btn_prettyjsonresponse.Text = "Pretty JSON";
            this.btn_prettyjsonresponse.UseVisualStyleBackColor = true;
            this.btn_prettyjsonresponse.Click += new System.EventHandler(this.btn_prettyjsonresponse_Click);
            // 
            // HTTP_POST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 578);
            this.Controls.Add(this.btn_prettyjsonresponse);
            this.Controls.Add(this.lbl_exception);
            this.Controls.Add(this.txtbox_exception);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtbox_databody);
            this.Controls.Add(this.txtbox_normalbody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbox_body);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_prettyjsonbody);
            this.Controls.Add(this.txtbox_response);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_sendcmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_url);
            this.Name = "HTTP_POST";
            this.Text = "HTTP_POST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_prettyjsonbody;
        private System.Windows.Forms.TextBox txtbox_response;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_sendcmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_url;
        private System.Windows.Forms.TextBox txtbox_body;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox_normalbody;
        private System.Windows.Forms.TextBox txtbox_databody;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_exception;
        private System.Windows.Forms.TextBox txtbox_exception;
        private System.Windows.Forms.Button btn_prettyjsonresponse;
    }
}