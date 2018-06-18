
using NovoRumoProjeto.DAL.Daily;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using System.Collections.Generic;

namespace NovoRumoProjeto.Models
{
    public class DailyViewModel
    {
        private string IMAGE_PATH = Consts.DAILY_IMAGE_PATH;
        public string displayFileName { get; set; }

        public List<DailyViewModel> Get()
        {
            var list = new List<DailyViewModel>();
            DailyDAL dailyDAL = new DailyDAL();

            var entity = dailyDAL.Get();

            foreach (var item in entity)
            {
                list.Add(new DailyViewModel()
                {
                    displayFileName = item.fileName.GetImagePath(IMAGE_PATH)
                });
            }

            return list;
        }
    }
}