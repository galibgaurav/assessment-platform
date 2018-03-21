using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace GyanPariksha.helper
{
    public class FileHelper : IFileHelper
    {
        public bool WriteFile<T>(IList<T> lst,string refPath=null)
        {
            try { 
            string path = ConfigurationManager.AppSettings["FilePath"].ToString();
            path = path + "\\" + refPath + ".json";
            var content = JsonConvert.SerializeObject(lst);
            File.WriteAllText(path, content);
            return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IList<T> ReadFile<T>(string path, string refPath = null)
        {
            return null;
        }
        public bool FileExist<T>(string path)
        {
            return true;
        }

      
    }
}
