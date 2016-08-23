using ClientLib;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OneClient
{
    public partial class Form2 : WebBrowserComponent
    {
        public Form2()
        {
            InitializeComponent();
        }

      //  private readonly string _communicationPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\oneclient";
        public string Url { set; get; }
        public string PersonName { get; set; }
        private StepRunner Runner { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            Runner = new StepRunner(this, null);
          
            fileSystemWatcher1.Path = Runner.CommPath;
            fileSystemWatcher1.EnableRaisingEvents = true;

            this.Controls.Add(this.WebBrowserInterface);
            this.WebBrowserInterface.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowserInterface.Navigate(textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Text = e.Url.ToString();
            textBox1.Text = e.Url.ToString();
        }

        public static bool raised = true;

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (raised)
            {
                try
                {
                    Runner.ExecuteStep();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                raised = true;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}