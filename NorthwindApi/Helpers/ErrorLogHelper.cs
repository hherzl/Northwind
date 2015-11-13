using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using NorthwindApi.Models;

namespace NorthwindApi.Helpers
{
    public class ErrorLogHelper
    {
        public static List<ErrorLog> GetData(String path)
        {
            var data = TextFileHelper.Read(path, FileMode.Open, FileAccess.Read, Encoding.UTF8);

            return JsonConvert.DeserializeObject<List<ErrorLog>>(data) ?? new List<ErrorLog>();
        }

        public static void SaveData(List<ErrorLog> list, String path)
        {
            if (list == null)
            {
                list = new List<ErrorLog>();
            }

            var json = JsonConvert.SerializeObject(list);

            TextFileHelper.Create(path, json, Encoding.UTF8);
        }
    }
}
