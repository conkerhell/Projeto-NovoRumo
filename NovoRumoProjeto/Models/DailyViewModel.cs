using NovoRumoProjeto.DAL.Daily;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace NovoRumoProjeto.Models
{
    public class DailyViewModel
    {
        private string IMAGE_PATH = Consts.DAILY_IMAGE_PATH;
        public string displayFileName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Data { get; set; }
        public int DailyID { get; set; }

        public List<DailyViewModel> Get()
        {
            IDailyDAL dailyDAL = new DailyDAL();
            var entity = dailyDAL.Get();

            var list = new List<DailyViewModel>();
            foreach (var item in entity)
            {
                list.Add(new DailyViewModel()
                {
                    DailyID = item.DailyID,
                    displayFileName = item.fileName.GetImagePath(IMAGE_PATH),
                    Title = item.Title,
                    Description = item.Description,
                    Data = item.Data
                });
            }
            return list;
        }
    }
}