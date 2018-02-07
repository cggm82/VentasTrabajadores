﻿using System;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms; 

namespace Utilidades
{
    internal class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string strNombImpresora, IntPtr pBytes, Int32 dwCount,
                                               string strNombArchivo, ref Int32 dwError)
        {
            //Int32 dwError = 0, 
            Int32 dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = strNombArchivo;
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(strNombImpresora.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
                dwError = Marshal.GetLastWin32Error();
            return bSuccess;
        }

        public static bool SendFileToPrinter(string strNombImpresora, string strNombArchivo)
        {
            FileStream fs = new FileStream(strNombArchivo, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;
            Int32 dwError = 0;
            try
            {

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(strNombImpresora, pUnmanagedBytes, nLength, strNombArchivo, ref dwError);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                fs.Close();
                return bSuccess;
            }
            catch (Exception ex)
            {
                if (dwError > 0)
                    throw new ArgumentException("Error Ocurrido en Utilidades al Imprimir. Nro. Error: " + dwError.ToString());
                else
                    throw ex;
            }
        }
        public static bool SendStringToPrinter(string strNombImpresora, string strTexto, string strNombArchivo)
        {
            IntPtr pBytes;
            Int32 nLength;
            Int32 dwError = 0;
            bool bSuccess = false;
            try
            {
                // How many characters are in the string?
                nLength = strTexto.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(strTexto);
                // Send the converted ANSI string to the printer.
                bSuccess = SendBytesToPrinter(strNombImpresora, pBytes, nLength, strNombArchivo, ref dwError);
                Marshal.FreeCoTaskMem(pBytes);
                return bSuccess;


                //////// How many characters are in the string?
                //////dwCount = strTexto.Length;
                //////// Assume that the printer is expecting ANSI text, and then convert
                //////// the string to ANSI text.
                //////pBytes = Marshal.StringToCoTaskMemAnsi(strTexto);
                //////// Send the converted ANSI string to the printer.
                //////bSuccess = SendBytesToPrinter(strNombImpresora, pBytes, dwCount, strNombArchivo, ref dwError);
                //////Marshal.FreeCoTaskMem(pBytes);
                //////return bSuccess;
            }
            catch (Exception ex)
            {
                if (dwError > 0)
                    throw new ArgumentException("Error Ocurrido en Utilidades al Imprimir. Nro. Error: " + dwError.ToString());
                else
                    throw ex;
            }
        }
    }
}
