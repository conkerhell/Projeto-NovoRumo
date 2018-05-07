using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NovoRumoProjeto.Utilities.Validation
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public FileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            return maxSize > (value as HttpPostedFileBase).ContentLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(name, maxSize);
        }
    }
}
