using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileEncryptionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSelectedFiles.Text = string.Join(", ", openFileDialog.FileNames);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSelectedFiles.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var files = txtSelectedFiles.Text.Split(new[] { ", " }, StringSplitOptions.None);
            foreach (var file in files)
            {
                Task.Run(() => EncryptFile(file));
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var files = txtSelectedFiles.Text.Split(new[] { ", " }, StringSplitOptions.None);
            foreach (var file in files)
            {
                Task.Run(() => DecryptFile(file));
            }
        }

        private void EncryptFile(string filePath)
        {
            try
            {
                string encryptedFilePath = filePath.EndsWith(".txt") ? filePath.Substring(0, filePath.Length - 4) + ".enc" : filePath;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Convert.FromBase64String("1Sp7hV2QWcIbtf5N2AiiZ1OfZlnlmzu0r3rwX4o/ABw=");
                    aes.IV = Convert.FromBase64String("PcgsK5UV5zqirB7MxJD+Mw==");
                    //klucze wygenerowałem poprzez osobny projekt
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (FileStream fsEncrypted = new FileStream(encryptedFilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsEncrypted, encryptor, CryptoStreamMode.Write))
                        {
                            using (FileStream fsIn = new FileStream(filePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fsIn.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"File {filePath} encrypted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encrypting file {filePath}: {ex.Message}");
            }
        }

        private void DecryptFile(string filePath)
        {
            try
            {
                string decryptedFilePath = filePath.EndsWith(".enc") ? filePath.Substring(0, filePath.Length - 4) + "-Decrypted.txt" : filePath;


                //aby działało deszyfrowanie trzeba było usunąć plik, który się szyfrowało (konflikt nazw plików)
                //poradziłem sobie w taki sposób, aby usuwać z niego 8 znaków od końca czyli .enc oraz .txt  teraz test.txt.enc będzie miał nazwę testEncrypted.txt

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Convert.FromBase64String("1Sp7hV2QWcIbtf5N2AiiZ1OfZlnlmzu0r3rwX4o/ABw=");
                    aes.IV = Convert.FromBase64String("PcgsK5UV5zqirB7MxJD+Mw==");
                    //klucze wygenerowałem poprzez osobny projekt
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (FileStream fsIn = new FileStream(filePath, FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fsIn, decryptor, CryptoStreamMode.Read))
                        {
                            using (FileStream fsOut = new FileStream(decryptedFilePath, FileMode.Create))
                            {
                                int data;
                                while ((data = cs.ReadByte()) != -1)
                                {
                                    fsOut.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"File {filePath} decrypted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decrypting file {filePath}: {ex.Message}");
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            var files = txtSelectedFiles.Text.Split(new[] { ", " }, StringSplitOptions.None);
            foreach (var file in files)
            {
                await Task.Run(() => UploadFile(file));
            }
        }

        private void UploadFile(string filePath)
        {
            MessageBox.Show($"File {filePath} uploaded successfully.");
        }

        private void SaveConfig(EncryptionConfig config, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, config);
            }
        }

        private EncryptionConfig LoadConfig(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return (EncryptionConfig)formatter.Deserialize(stream);
            }
        }
    }
}
