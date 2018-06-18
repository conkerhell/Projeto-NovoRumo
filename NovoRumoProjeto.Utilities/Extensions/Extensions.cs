using System.Configuration;

namespace NovoRumoProjeto.Utilities.Extensions
{
    public static class Extensions
    {
        public static string GetImagePath(this string imageName, string folder)
        {
            return string.Concat(ConfigurationManager.AppSettings[folder], @"\", imageName);
        }
    }
}
