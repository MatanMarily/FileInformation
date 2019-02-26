using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileInformation.Models
{
    public class ReportViewModel
    {
        public string FileName { get; set; }
        public int ByteFileCount { get; set; }
        public string Type { get; set; }
        public bool Filter { get; set; } = false;
        public IEnumerable<string> DataFile { get; set; }
        public IEnumerable<string> DataFileAfterFiltering { get; set; }
        public HttpPostedFileBase File { get; set; }
        public int MaxByteFileCount { get; set; } = 2000000; //2MB
        public string Error { get; set; } = string.Empty;
        public string PathDownloads { get; set; } = @"C:\MyDownloads\FileFilltering.txt";
    }
}