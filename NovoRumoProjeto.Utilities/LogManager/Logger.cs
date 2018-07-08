using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace NovoRumoProjeto.Utilities.LogManager {

    public class Logger
    {
        //******* LOGS *******//
        public const string LOGS_FILE_PATH = "Logs";
        public const string LOG_FILE = "log.json";
        public const string LOG_FILE_SEPARATED = "log_{0}.json";

        private bool validateFile()
        {
            string fileName = LOG_FILE;
            string serverPath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH, fileName);
            bool exists = File.Exists(serverPath);

            if (exists)
            {
                FileInfo fileInfo = new FileInfo(serverPath);
                if (fileInfo.Length > 100000)
                {
                    string newFileName = string.Format(LOG_FILE_SEPARATED, DateTime.Now.ToString("ddMMyyyy_hhmm"));
                    File.Move(serverPath, Path.Combine(HttpRuntime.AppDomainAppPath, newFileName));
                    return false;
                }
            }
            return exists;
        }

        private void createFolder()
        {
            string serverPath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH);
            Directory.CreateDirectory(serverPath);
        }

        private void addContent(LogModel model)
        {
            string fileName = LOG_FILE;
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH, fileName);

            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, model);
            }
        }

        protected void Save(LogModel model)
        {
            if (!validateFile())
                createFolder();
            
            addContent(model);
        }
    }
}
