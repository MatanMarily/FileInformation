using FileInformation.Models;
using FileInformation.Views.HelpMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using FileInformation.HelpMethods;

namespace FileInformation.Controllers
{
    public class HomeController : Controller
    {        
        public static ReportViewModel DataFile;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OpenFile()
        {
            if (Request.Files.Count > 0)
            {                 
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    DataFile = new ReportViewModel();
                    DataFile.File = file;
                    DataFile.FileName = Path.GetFileName(file.FileName);
                    DataFile.ByteFileCount = file.ContentLength;
                    DataFile.Type = Path.GetExtension(file.FileName);

                    if(!Validation())
                        return (View("Index", DataFile));

                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        byte[] binData = br.ReadBytes(file.ContentLength);
                        var dataFileTmp = System.Text.Encoding.UTF8.GetString(binData);
                        DataFile.DataFile = Use.ParseCSV(dataFileTmp);
                    }
                }
            }
            return (View("Index", DataFile));
        }

        public bool Validation()
        {            
            if (DataFile.ByteFileCount > DataFile.MaxByteFileCount)
            {
                int mb = DataFile.MaxByteFileCount / (1000 * 1000);
                DataFile.Error = "Upload file max "+mb+"MB, plese try again.";
                return (false);
            }

            List<string> types = Enum.GetNames(typeof(Enums.Types)).ToList();
            bool typeValid = false;
            foreach (var type in types)
            {
                if (DataFile.Type == "." + type)
                {
                    typeValid = true;
                    break;
                }
            }
            if (!typeValid)
            {
                string combindedString = string.Join(",", types.ToArray());
                DataFile.Error = "Open only "+combindedString+" files, please try again. ";
                return (false);
            }
            return true;
        }

        [HttpPost]
        public string Filtering(string subString)
        {
            DataFile.DataFileAfterFiltering = DataFile.DataFile.Where(s => s.Contains(subString));
            return(string.Join("\n", DataFile.DataFileAfterFiltering));
        }

        [HttpPost]
        public bool DownloadFile()
        {
            if (!Directory.Exists(@"C:\MyDownloads"))
                Directory.CreateDirectory(@"C:\MyDownloads");
            WriteToFile();
            return (true);
        }

        public void WriteToFile()
        {
            using (TextWriter tw = new StreamWriter(DataFile.PathDownloads))
            {
                foreach (string s in DataFile.DataFileAfterFiltering)
                    tw.WriteLine(s);
                tw.Close();
            }          
        }
    }
}