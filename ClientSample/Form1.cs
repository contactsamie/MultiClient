using AutomatorLib;
using ClientLib;
using SampleSteps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClientSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Processes = new List<Process>();
        }


        public List<Process> Processes { get; set; }
        public List<WebBrowserComponent> Browsers { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Browsers = new List<WebBrowserComponent>();
          
        }

        private readonly StepRunner _stepRunner = new StepRunner();

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            //  Native.LoadProcessInControl("OneClient.exe", this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stepRunner.RequestStep<StepDie>();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            //  Steps.StepRefresh();
            _stepRunner.RequestStep<Refresh>();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _stepRunner.RequestStep<StepDie>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _stepRunner.RequestStep<StepNavigate>(new StepCommand() { Arguments = new List<string>() { textBox1.Text } });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _stepRunner.RequestStep<CreateClients>(new StepCommand() { Arguments = new List<string>() { textBox2.Text } });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CreateClients().Execute(null, new StepCommand() { Arguments = new List<string>() { textBox3.Text } });

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}