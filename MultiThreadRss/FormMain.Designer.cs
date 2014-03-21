namespace MultiThreadRss
{
    partial class FormMain
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
            this.bt_send = new System.Windows.Forms.Button();
            this.dgv_rssSources = new System.Windows.Forms.DataGridView();
            this.cl_rssSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_emails = new System.Windows.Forms.DataGridView();
            this.clm_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_keyWords = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rssSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keyWords)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(288, 201);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(150, 35);
            this.bt_send.TabIndex = 0;
            this.bt_send.Text = "button1";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // dgv_rssSources
            // 
            this.dgv_rssSources.AllowUserToDeleteRows = false;
            this.dgv_rssSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rssSources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_rssSource});
            this.dgv_rssSources.Location = new System.Drawing.Point(12, 27);
            this.dgv_rssSources.Name = "dgv_rssSources";
            this.dgv_rssSources.Size = new System.Drawing.Size(213, 150);
            this.dgv_rssSources.TabIndex = 1;
            // 
            // cl_rssSource
            // 
            this.cl_rssSource.HeaderText = "Rss Source";
            this.cl_rssSource.Name = "cl_rssSource";
            this.cl_rssSource.Width = 170;
            // 
            // dgv_emails
            // 
            this.dgv_emails.AllowUserToDeleteRows = false;
            this.dgv_emails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_emails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_email});
            this.dgv_emails.Location = new System.Drawing.Point(267, 27);
            this.dgv_emails.Name = "dgv_emails";
            this.dgv_emails.Size = new System.Drawing.Size(202, 150);
            this.dgv_emails.TabIndex = 2;
            // 
            // clm_email
            // 
            this.clm_email.HeaderText = "Email";
            this.clm_email.Name = "clm_email";
            this.clm_email.Width = 150;
            // 
            // dgv_keyWords
            // 
            this.dgv_keyWords.AllowUserToDeleteRows = false;
            this.dgv_keyWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_keyWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgv_keyWords.Location = new System.Drawing.Point(512, 27);
            this.dgv_keyWords.Name = "dgv_keyWords";
            this.dgv_keyWords.Size = new System.Drawing.Size(202, 150);
            this.dgv_keyWords.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Key word";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 269);
            this.Controls.Add(this.dgv_keyWords);
            this.Controls.Add(this.dgv_emails);
            this.Controls.Add(this.dgv_rssSources);
            this.Controls.Add(this.bt_send);
            this.Name = "FormMain";
            this.Text = "MultiThreadRssReader";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rssSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keyWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.DataGridView dgv_rssSources;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_rssSource;
        private System.Windows.Forms.DataGridView dgv_emails;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_email;
        private System.Windows.Forms.DataGridView dgv_keyWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}

