using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hashrev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 1; i <= numericUpDown1.Value ; i++) {
                webBrowser1.Navigate(textBox1 .Text.ToString().Trim());
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                string name = RandomString(9);
                string email = name.ToString() + "@binka.me".ToLower();
                Random rnd = new Random();
                int number = rnd.Next(10000, 99999);
                string postData = "name=" + name + "&tel=" + number + "&email=" + email + "&password=0835897600Za";
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                byte[] bytes = encoding.GetBytes(postData);
                string url = "https://hashrev.com/member/register";
                webBrowser1.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                webBrowser1.Navigate("https://hashrev.com/member/miner");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
