using System.IO;
using System.Text;
using System.Web;

namespace NovoRumoProjeto.Utilities.LogManager {

    public class Logger
    {
        //private bool ValidateFile(LogType logType)
        //{
        //    string fileName = string.Format(LOG_FILE, logType);
        //    string serverPath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH, fileName);
        //    bool exists = File.Exists(serverPath);

        //    if (exists)
        //    {
        //        FileInfo fileInfo = new FileInfo(serverPath);
        //        if (fileInfo.Length > 10000000)
        //        {
        //            string newFileName = string.Format(LOG_FILE_SEPARATED, logType, DateTime.Now.ToString("ddMMyyyy_hhmm"));
        //            File.Move(serverPath, Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(LOG_FILE, logType), newFileName));
        //            return false;
        //        }
        //    }
        //    return exists;
        //}

        //private void CreateFile(string message, LogType logType, Criticity criticity)
        //{
        //    string fileName = string.Format(LOG_FILE, logType);
        //    string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, LOGS_FILE_PATH, fileName);

        //    using (StreamWriter writer = new StreamWriter(filePath, true))
        //    {
        //        StringBuilder builder = new StringBuilder();
        //        builder.AppendFormat(string.Format(LOG_MESSAGE_TEMPLATE, DateTime.Now, criticity, message));
        //        writer.WriteLine(builder.ToString());
        //    }
        //}

        public void Save()
        {
               
        }
    }
}
