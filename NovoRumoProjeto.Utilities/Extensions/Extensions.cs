using System.Configuration;

namespace NovoRumoProjeto.Utilities.Extensions
{
    public static class Extensions
    {
        public static string GetImagePath(this string imageName, string folder)
        {
            return string.Concat(ConfigurationManager.AppSettings[folder], @"\", imageName);
        }

        public static string FormatLastName(this string lastName)
        {
            string resolvedLastName = lastName;

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                string[] names = lastName.Split(' ');

                if (names.Length > 2)
                {
                    resolvedLastName = names[0];
                }
            }
            return resolvedLastName;
        }
    }
}
