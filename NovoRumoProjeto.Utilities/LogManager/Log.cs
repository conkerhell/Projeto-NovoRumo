 
 namespace NovoRumoProjeto.Utilities.LogManager {
  
  ///
  /// Singletons aren't great but that's what we have for now
  ///
  public sealed class Log : Logger
  {
    private static Log instance = null;
    private static readonly object padlock = new object();

    Log()
    {
    }

    public static Log Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Log();
                }
                return instance;
            }
        }
    }
   
    public void Info()
    {
        Save();
        return;
    }
   
    public void Error()
    {
        Save();
        return;
    }
  }
}
