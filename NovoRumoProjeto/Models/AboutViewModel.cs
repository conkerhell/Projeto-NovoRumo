﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovoRumoProjeto.DAL.About;

namespace NovoRumoProjeto.Models
{
    public class AboutViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string displayFilename { get; set; }

        public void GetNextAbout()
        {
            IAboutDAL aboutDAL = new AboutDAL();
            var entity = aboutDAL.GetNextAbout();
            Title = entity.Title;
            Description = entity.Description;
            displayFilename = entity.fileName;

        }
    }
}