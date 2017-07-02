using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieMVC
{
    /// <summary>
    /// Summary description for GetFileHandler
    /// </summary>
    public class GetFileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.QueryString["file"];
            string pathPDF = "C:\\Users\\User\\Source\\Repos\\MovieMVC\\pdf\\";
            if (!string.IsNullOrEmpty(file) && File.Exists(pathPDF + file))
            {
                //string fileName = "BUSProjectCard.pdf";
                //string filePath = context.Server.MapPath("~/");
                
                context.Response.Clear();
                context.Response.ContentType = "application/pdf";
                //I have set the ContentType to "application/octet-stream" which cover any type of file
                context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(file));
                context.Response.WriteFile(pathPDF+'/'+file);
                //context.Response.TransmitFile(pathPDF + '/' + file);
                //here you can do some statistic or tracking
                //you can also implement other business request such as delete the file after download
                context.Response.End();
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("File not found!");
            }




            //string filePath = HttpContext.Current.Server.MapPath(urlRequested);

            //string fileName = System.IO.Path.GetFileName(filePath);

            //context.Response.ClearContent();

            //context.Response.ClearHeaders();

            //FileInfo pdfInfo = new FileInfo(filePath);

            //context.Response.AddHeader("Content-Length", pdfInfo.Length.ToString());

            ////assuming that the file is pdf, needs to be changed appropriately
            ////context.Response.ContentType = "application/zip";
            //context.Response.ContentType = "application/pdf";

            //context.Response.TransmitFile(filePath);

            //context.Response.End();



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

