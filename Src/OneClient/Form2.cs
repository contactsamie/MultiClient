using ClientLib;
using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            label1.Text = $@"Started @ {DateTime.Now}";
            label2.Visible = false;

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
                    label1.Text = $@"{e.ChangeType} @ {DateTime.Now}";
                }
                catch (Exception exception)
                {

                }
                try
                {

                    Runner.ExecuteStep();
                    try
                    {
                        label2.Text = "";
                        label2.Visible = false;
                    }
                    catch (Exception exception)
                    {

                    }
                }
                catch (Exception ex)
                {

                    try
                    {
                        label2.Visible = true;
                        label2.Text = $@"Error {WriteExceptionDetails(ex)} {e} @ {DateTime.Now}";
                    }
                    catch (Exception exception)
                    {

                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string WriteExceptionDetails(Exception exception, StringBuilder builderToFill = null, int level = 0)
        {
            builderToFill = builderToFill ?? new StringBuilder();
            var indent = new string(' ', level);

            if (level > 0)
            {
                builderToFill.AppendLine(indent + "=== INNER EXCEPTION ===");
            }

            Action<string> append = (prop) =>
            {
                var propInfo = exception.GetType().GetProperty(prop);
                var val = propInfo.GetValue(exception);

                if (val != null)
                {
                    builderToFill.AppendFormat("{0}{1}: {2}{3}", indent, prop, val.ToString(), Environment.NewLine);
                }
            };

            append("Message");
            append("HResult");
            append("HelpLink");
            append("Source");
            append("StackTrace");
            append("TargetSite");

            foreach (DictionaryEntry de in exception.Data)
            {
                builderToFill.AppendFormat("{0} {1} = {2}{3}", indent, de.Key, de.Value, Environment.NewLine);
            }

            if (exception.InnerException != null)
            {
                return WriteExceptionDetails(exception.InnerException, builderToFill, ++level);
            }
            return builderToFill.ToString();
        }
    }
}