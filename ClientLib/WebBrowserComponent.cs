using System.Windows.Forms;

namespace ClientLib
{
    public class WebBrowserComponent : Form
    {
        public System.Windows.Forms.WebBrowser WebBrowserInterface;

        public WebBrowserComponent()
        {
            this.WebBrowserInterface = new System.Windows.Forms.WebBrowser
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
        }
    }
}