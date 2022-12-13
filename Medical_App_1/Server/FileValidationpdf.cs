using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Medical_App_1.Server
{
    public class FileValidationpdf
    {
        public FileValidationpdf()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.IntPtr pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.IntPtr ppwzMimeOut,
            System.UInt32 dwReserverd
        );
        public static bool IsValidFileType(byte[] fileByteContent)
        {
            bool isValid = false;
            string mimetypeOfFile = string.Empty;

            byte[] buffer = new byte[256];
            using (MemoryStream fs = new MemoryStream(fileByteContent))
            {
                if (fs.Length >= 256)
                    fs.Read(buffer, 0, 256);
                else
                    fs.Read(buffer, 0, (int)fs.Length);
            }
            try
            {
                System.IntPtr mimetype;
                FindMimeFromData(IntPtr.Zero, null, buffer, 256, null, 0, out mimetype, 0);
                //System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                //mimetypeOfFile = Marshal.PtrToStringUni(mimeTypePtr);
                mimetypeOfFile = Marshal.PtrToStringUni(mimetype);
                //Marshal.FreeCoTaskMem(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimetype);
            }
            catch (Exception e)
            {

            }

            if (!string.IsNullOrEmpty(mimetypeOfFile))
            {
                switch (mimetypeOfFile.ToLower())
                {
                    case "application/pdf": // for .pdf  estension
                        isValid = true;
                        break;
                    //case "application/vnd.openxmlformats-officedocument.wordprocessingml.document": // for .docx  estension
                    //    isValid = true;
                    //    break;
                    case "application/vnd.ms-excel": // for .xls  estension
                        isValid = true;
                        break;
                    case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet": // for  .xlsx estension
                        isValid = true;
                        break;
                        //case "application/vnd.ms-powerpoint":// for .ppt estension
                        //    isValid = true;
                        //    break;
                        //case "application/vnd.openxmlformats-officedocument.presentationml.presentation":// for .pptx estension
                        //    isValid = true;
                        //    break;
                        //case "image/jpeg"://jpeg and jpg both
                        //    isValid = true;
                        //    break;
                        //case "image/pjpeg"://jpeg and jpg both
                        //    isValid = true;
                        //    break;
                        //case "image/png":// for .png estension
                        //    isValid = true;
                        //    break;
                        //case "image/x-png":// for .png estension
                        //    isValid = true;
                        //    break;
                        //case "image/gif":// for .gif estension
                        //    isValid = true;
                        //    break;
                }
            }

            return isValid;

        }
    }
}
