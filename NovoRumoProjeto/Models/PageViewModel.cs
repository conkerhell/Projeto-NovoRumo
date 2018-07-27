using NovoRumoProjeto.DAL.Politics;
using NovoRumoProjeto.DAL.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoRumoProjeto.Models
{
    public class PartialView
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void GetTerms()
        {
            ITermsDAL termsDAL = new TermsDAL();
            var entity = termsDAL.GetTerms();
            Title = entity.Title;
            Description = entity.Description;
        }

        public void GetPolicies()
        {
            IPolicyDAL policyDAL = new PolicyDAL();
            var entity = policyDAL.GetPolicy();
            Title = entity.Title;
            Description = entity.Description;
        }
    }
}