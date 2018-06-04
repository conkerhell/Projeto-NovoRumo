using System;
using System.Collections.Generic;
using NovoRumoProjeto.DAL.About;

namespace NovoRumoProjeto.Models
{
    public class AboutViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string displayFilename { get; set; }

        public DateTime? Data { get; set; }

        public List<AboutViewModel> GetNewestAbout()
        {

            IAboutDAL aboutDAL = new  AboutDAL();
            var model = new List<AboutViewModel>();
            var entity =  aboutDAL.GetNewestAbout();
            foreach (var item in entity)
            {

                var About = new AboutViewModel();
              
                About.Title = item.Title;
                About.Description = item.Description;
                About.displayFilename = item.fileName;
                About.Data = item.Data;

                model.Add(About);
            }

            return (model);
           
        }
    }
}