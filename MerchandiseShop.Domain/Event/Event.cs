using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Domain.Event
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string AvalibleFor { get; private set; }

        public void SetAvalibleFor(List<string> avalibleForList)//JsonSerializer
        {
            var avalibleFor = "";
            foreach (var item in avalibleForList)
            {
                avalibleFor += item + ",";
            }
            AvalibleFor = avalibleFor;
        }

        public List<string> GetAvalibleFor()
        {
            return AvalibleFor.Split(",").ToList();
        }
    }
}
