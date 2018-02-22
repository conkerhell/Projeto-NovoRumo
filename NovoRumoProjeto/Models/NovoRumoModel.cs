using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoRumoProjeto.Models
{
    public class NovoRumoModel
    {
        [Required]
        [Display(Name = "Nome (Obrigatório)")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "E-mail (Obrigatório)")]
        public string email { get; set; }
        public string assunto { get; set; }
        [Required]
        [Display(Name = "Mensagem (Obrigatório)")]
        public string mensagem { get; set; }
    }
}