
using System;

namespace NovoRumoProjeto.Utilities.LogManager
{    
    public class LogModel
    {
        public LogModel()
        { 
            Date = DateTime.Now;
        }   
        
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    public enum Category
    {
        Info,
        Warn,
        Error        
    }
}
