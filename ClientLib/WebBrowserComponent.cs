using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ClientLib
{
    public class WebBrowserComponent : Form
    {
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public UnSecuredWebBrowser WebBrowserInterface;

        public WebBrowserComponent()
        {
            this.WebBrowserInterface = new UnSecuredWebBrowser
            {
                Anchor =
                    ((System.Windows.Forms.AnchorStyles)
                        ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                           | System.Windows.Forms.AnchorStyles.Left)
                          | System.Windows.Forms.AnchorStyles.Right))),
                Location = new System.Drawing.Point(17, 110),
                MinimumSize = new System.Drawing.Size(20, 20),
                Name = "webBrowser1",
                ScriptErrorsSuppressed = true,
                Size = new System.Drawing.Size(312, 445),
                TabIndex = 0
            };

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        }
    }
}