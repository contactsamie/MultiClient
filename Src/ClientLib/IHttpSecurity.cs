using System;
using System.Runtime.InteropServices;

namespace ClientLib
{
    [ComImport()]
    [ComVisible(true)]
    [Guid("79eac9d7-bafa-11ce-8c82-00aa004ba90b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHttpSecurity
    {
        //derived from IWindowForBindingUI
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow(
            [In] ref Guid rguidReason,
            [In, Out] ref IntPtr phwnd);

        [PreserveSig]
        int OnSecurityProblem(
            [In, MarshalAs(UnmanagedType.U4)] uint dwProblem);
    }
}