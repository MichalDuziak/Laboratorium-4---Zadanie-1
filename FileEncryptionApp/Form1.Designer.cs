namespace FileEncryptionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtSelectedFiles;
        private System.Windows.Forms.ComboBox cmbEncryptionMethod;
        private System.Windows.Forms.Label lblSelectedFiles;
        private System.Windows.Forms.Label lblEncryptionMethod;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtSelectedFiles = new System.Windows.Forms.TextBox();
            this.cmbEncryptionMethod = new System.Windows.Forms.ComboBox();
            this.lblSelectedFiles = new System.Windows.Forms.Label();
            this.lblEncryptionMethod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(118, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 70);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(118, 70);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 23);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(224, 70);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 23);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtSelectedFiles
            // 
            this.txtSelectedFiles.Location = new System.Drawing.Point(12, 41);
            this.txtSelectedFiles.Name = "txtSelectedFiles";
            this.txtSelectedFiles.Size = new System.Drawing.Size(312, 20);
            this.txtSelectedFiles.TabIndex = 5;
            // 
            // cmbEncryptionMethod
            // 
            this.cmbEncryptionMethod.FormattingEnabled = true;
            this.cmbEncryptionMethod.Items.AddRange(new object[] {
            "AES",
            "DES",
            "RSA"});
            this.cmbEncryptionMethod.Location = new System.Drawing.Point(118, 99);
            this.cmbEncryptionMethod.Name = "cmbEncryptionMethod";
            this.cmbEncryptionMethod.Size = new System.Drawing.Size(206, 21);
            this.cmbEncryptionMethod.TabIndex = 6;
            // 
            // lblSelectedFiles
            // 
            this.lblSelectedFiles.AutoSize = true;
            this.lblSelectedFiles.Location = new System.Drawing.Point(329, 44);
            this.lblSelectedFiles.Name = "lblSelectedFiles";
            this.lblSelectedFiles.Size = new System.Drawing.Size(76, 13);
            this.lblSelectedFiles.TabIndex = 7;
            this.lblSelectedFiles.Text = "Selected Files:";
            // 
            // lblEncryptionMethod
            // 
            this.lblEncryptionMethod.AutoSize = true;
            this.lblEncryptionMethod.Location = new System.Drawing.Point(12, 102);
            this.lblEncryptionMethod.Name = "lblEncryptionMethod";
            this.lblEncryptionMethod.Size = new System.Drawing.Size(99, 13);
            this.lblEncryptionMethod.TabIndex = 8;
            this.lblEncryptionMethod.Text = "Encryption Method:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(417, 146);
            this.Controls.Add(this.lblEncryptionMethod);
            this.Controls.Add(this.lblSelectedFiles);
            this.Controls.Add(this.cmbEncryptionMethod);
            this.Controls.Add(this.txtSelectedFiles);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnSelectFiles);
            this.Name = "Form1";
            this.Text = "File Encryption App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
