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

        private void addContent(string content)
        {
            string fileName = LOG_FILE;
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(content);
            }
        }

        protected void Save(string content)
        {
            if (!validateFile())
            {
                createFolder();
            }
            addContent(content);
        }
    }
}
