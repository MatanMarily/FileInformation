using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FileInformation.HelpMethods
{
    public static class Use
    {
        public static List<string> ParseCSV(string data)
        {
            var tmp = Regex.Replace(data, "\r\n", "\n");
            return (Regex.Split(tmp, "\n").ToList());
        }
    }
}