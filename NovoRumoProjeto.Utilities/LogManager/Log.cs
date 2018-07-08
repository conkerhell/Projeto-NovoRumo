
using System;
using System.Text;

namespace NovoRumoProjeto.Utilities.LogManager
{

    ///
    /// Singletons aren't great but that's what we have for now
    ///
    public sealed class Log : Logger
    {
        private static Log instance = null;
        private static readonly object padlock = new object();

        Log() { }

        public static Log Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new Log();
                    return instance;
                }
            }
        }

        public void Info(string title, string message)
        {
            LogModel model = new LogModel();

            model.Category = Category.Info;
            model.Title = title;
            model.Message = message;

            Save(model);
        }

        public void Error(string title, string message)
        {
            LogModel model = new LogModel();

            model.Category = Category.Error;
            model.Title = title;
            model.Message = message;

            Save(model);
        }

        public void Error(Exception exception)
        {
            var indent = " ";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, exception.GetType().FullName);
            sb.AppendFormat("\n{0}Message: {1}", indent, exception.Message);
            sb.AppendFormat("\n{0}Source: {1}", indent, exception.Source);
            sb.AppendFormat("\n{0}Stacktrace: {1}", indent, exception.StackTrace);

            if (exception.InnerException != null)
            {
                sb.Append("\n");
                sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, exception.InnerException.GetType().FullName);
                sb.AppendFormat("\n{0}Message: {1}", indent, exception.InnerException.Message);
                sb.AppendFormat("\n{0}Source: {1}", indent, exception.InnerException.Source);
                sb.AppendFormat("\n{0}Stacktrace: {1}", indent, exception.InnerException.StackTrace);
            }

            LogModel model = new LogModel();
            model.Category = Category.Error;
            model.Message = sb.ToString();
            model.Title = exception.GetType().Name;

            Save(model);
        }
    }
}
