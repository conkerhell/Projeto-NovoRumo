using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Validation;
using Resources;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class AboutViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string displayFileName { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "FileRequired")]
        [FileTypes("jpg", "jpeg", "png", ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "FileFormatInvalid")]
        public HttpPostedFileBase file { get; set; }

        [Display(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// Responsável por salvar o arquivo no servidor
        /// </summary>
        /// <returns>Status do salvamento do arquivo</returns>
        public bool SaveFile()
        {
            var status = false;
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[Consts.ABOUT_IMAGE_PATH]), fileName);

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                file.SaveAs(filePath);
                displayFileName = file.FileName;
                status = true;
            }
            return status;
        }
    }
}