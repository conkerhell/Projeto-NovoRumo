using System;

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

        public void GetNewestAbout()
        {

            IAboutDAL aboutDAL = new AboutDAL();
            var entity = aboutDAL.GetNewestAbout();
            foreach (var item in entity)
            {
                Title = item.Title;
                Description = item.Description;
                displayFilename = item.fileName;
                Data = item.Data;
            }
           

        }
    }
}