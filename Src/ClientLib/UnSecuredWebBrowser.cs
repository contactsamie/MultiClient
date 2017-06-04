using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClientLib
{
    public class UnSecuredWebBrowser : WebBrowser
    {
        public static Guid IID_IHttpSecurity
            = new Guid("79eac9d7-bafa-11ce-8c82-00aa004ba90b");

        public static Guid IID_IWindowForBindingUI
            = new Guid("79eac9d5-bafa-11ce-8c82-00aa004ba90b");

        public const int S_OK = 0;
        public const int S_FALSE = 1;
        public const int E_NOINTERFACE = unchecked((int)0x80004002);
        public const int RPC_E_RETRY = unchecked((int)0x80010109);

        protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
            return new MyWebBrowserSite(this);
        }

        private class MyWebBrowserSite : WebBrowserSite,
            UCOMIServiceProvider,
            IHttpSecurity,
            IWindowForBindingUI
        {
            private UnSecuredWebBrowser myWebBrowser;

            public MyWebBrowserSite(UnSecuredWebBrowser myWebBrowser)
                : base(myWebBrowser)
            {
                this.myWebBrowser = myWebBrowser;
            }

            public int QueryService(ref Guid guidService
                , ref Guid riid
                , out IntPtr ppvObject)
            {
                if (riid == IID_IHttpSecurity)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this
                        , typeof(IHttpSecurity));
                    return S_OK;
                }
                if (riid == IID_IWindowForBindingUI)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this
                        , typeof(IWindowForBindingUI));
                    return S_OK;
                }
                ppvObject = IntPtr.Zero;
                return E_NOINTERFACE;
            }

            public int GetWindow(ref Guid rguidReason
                , ref IntPtr phwnd)
            {
                if (rguidReason == IID_IHttpSecurity
                    || rguidReason == IID_IWindowForBindingUI)
                {
                    phwnd = myWebBrowser.Handle;
                    return S_OK;
                }
                else
                {
                    phwnd = IntPtr.Zero;
                    return S_FALSE;
                }
            }

            public int OnSecurityProblem(uint dwProblem)
            {
                //ignore errors
                //undocumented return code, does not work on IE6
                return S_OK;
            }
        }
    }
}