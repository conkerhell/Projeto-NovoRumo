﻿
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

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "FileRequired")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|jpeg)$",
            ErrorMessageResourceType = typeof(LocalizedMessages), ErrorMessageResourceName = "FileFormatInvalid")]
        public HttpPostedFileBase file { get; set; }

        [Display(Name = "ID")]
        public int ID { get; set; }

        public bool IsFileValid
        {
            get
            {
                return file != null && file.ContentLength > 0;
            }
        }

        public bool SaveFile()
        {
            var status = false;
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImagePath"]), fileName);

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