
namespace NovoRumoProjeto.Utilities.LogManager
{    
    public class LogModel
    {
        public LogModel()
        {
            
        }   
        
        public Category Category { get; set; }
    }

    public enum Category
    {
        Info,
        Warn,
        Error        
    }
}
