using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileInformation.HelpMethods;
using System.Drawing;
using FileInformation.Models;

namespace FileInformation.Controllers
{
    public class ConvertingController : Controller
    {
        public ActionResult Index()
        {           
            return View();
        }
      
        [HttpPost]
        public void SubmitImageTo()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                #region Convert image to List<string>
                //var image = Image.FromStream(file.InputStream, true, true);
                //AutoOcr OCR = new AutoOcr() { ReadBarCodes = false };
                //var Results = OCR.Read(image);
                //List<string> data = Use.ParseCSV(Results.Text);
                #endregion
            }
        }

        [HttpPost]
        public void SubmitTextTo()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var image = Image.FromStream(file.InputStream, true, true);
                #region Convert image to string
                AutoOcr OCR = new AutoOcr() { ReadBarCodes = false };
                var Results = OCR.Read(image);

                //var Results = OCR.Read(@"D:\tmp\testH.jpg");
                List<string> data = Use.ParseCSV(Results.Text);
            }
            #endregion
        }      
    }
}