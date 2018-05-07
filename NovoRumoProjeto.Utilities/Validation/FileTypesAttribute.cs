using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoRumoProjeto.Utilities.Validation
{
    public class FileTypesAttribute : ValidationAttribute
    {
        private readonly string[] types;

        public FileTypesAttribute(params string[] types)
        {
            this.types = types;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var fileExt = System.IO
                                .Path
                                .GetExtension((value as
                                         HttpPostedFileBase).FileName).Substring(1);
            return types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(name, String.Join(", ", types.ToString()));
        }
    }
}
