 
 namespace NovoRumoProjeto.Utilities.LogManager {
  
  public sealed class Log
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
  }
}
