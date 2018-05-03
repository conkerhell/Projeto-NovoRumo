
using Resources;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Web;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class DailyViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string displayFileName { get; set; }
        public HttpPostedFileBase file { get; set; }
        public int ID { get; set; }

        /// <summary>
        /// Valida se o arquivo existe e se o conteudo esta valido
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string ValidateUpload(string path, string filename = "")
        {
            if (file != null && file.ContentLength > 0)
            {
                filename = string.IsNullOrWhiteSpace(filename) ? Path.GetFileName(file.FileName) : filename;
                return Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[path]), filename);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}