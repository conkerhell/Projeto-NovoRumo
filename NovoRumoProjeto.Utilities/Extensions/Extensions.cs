using System.Configuration;

namespace NovoRumoProjeto.Utilities.Extensions
{
    public static class Extensions
    {
        private const string IMAGE_PATH = "ImagePath";

        public static string GetImagePath(this string imageName)
        {
            return string.Concat(ConfigurationManager.AppSettings[IMAGE_PATH], @"\", imageName);
        }
    }
}
