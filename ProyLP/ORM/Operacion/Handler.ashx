<%@ WebHandler Language="C#" Class="Telerik.Web.Examples.FileExplorer.FilterAndDownloadFiles.Handler" %>  
 
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using Telerik.Web.UI;

namespace Telerik.Web.Examples.FileExplorer.FilterAndDownloadFiles
{
    [RadCompressionSettings(HttpCompression = CompressionType.None)] // Disable RadCompression for this page ;  
    public class Handler : IHttpHandler
    {
        #region IHttpHandler Members

        private HttpContext _context;
        private HttpContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }


        public void ProcessRequest(HttpContext context)
        {
            Context = context;
            string filePath = context.Request.QueryString["path"];
            string correctFileName = filePath.Substring(28);
            //filePath = context.Server.MapPath(correctFileName);
            filePath = @"C:\" + correctFileName;

            if (filePath == null)
            {
                return;
            }

            System.IO.StreamReader streamReader = new System.IO.StreamReader(filePath);
            System.IO.BinaryReader br = new System.IO.BinaryReader(streamReader.BaseStream);

            byte[] bytes = new byte[streamReader.BaseStream.Length];

            br.Read(bytes, 0, (int)streamReader.BaseStream.Length);

            if (bytes == null)
            {
                return;
            }

            streamReader.Close();
            br.Close();
            string extension = System.IO.Path.GetExtension(filePath);
            string fileName = System.IO.Path.GetFileName(filePath);

            if (extension == ".jpg")
            { // Handle *.jpg and  
                WriteFile(bytes, fileName, "image/jpeg jpeg jpg jpe png", context.Response);
            }
            else if (extension == ".docx")
            {// Handle .docx files ;

                WriteFile(bytes, fileName, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Context.Response);
            }
            else if (extension == ".gif")
            {// Handle *.gif  
                WriteFile(bytes, fileName, "image/gif gif", context.Response);
            }
            else if (extension == ".pdf")
            {// Handle *.pdf  
                WriteFile(bytes, fileName, "application/pdf", context.Response);
            }


        }

        /// <summary>  
        /// Sends a byte array to the client  
        /// </summary>  
        /// <param name="content">binary file content</param>  
        /// <param name="fileName">the filename to be sent to the client</param>  
        /// <param name="contentType">the file content type</param>  
        private void WriteFile(byte[] content, string fileName, string contentType, HttpResponse response)
        {
            response.Buffer = true;
            response.Clear();
            response.ContentType = contentType;

            response.AddHeader("content-disposition", "attachment; filename=" + fileName);

            response.BinaryWrite(content);
            response.Flush();
            response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}