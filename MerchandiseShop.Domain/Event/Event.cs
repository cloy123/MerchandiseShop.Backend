using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            AvalibleFor = JsonSerializer.Serialize(avalibleForList);
        }

        public List<string> GetAvalibleFor()
        {
            var result = JsonSerializer.Deserialize<List<string>>(AvalibleFor);
            if (result == null)
            {
                return new List<string>();
            }
            return result;
        }
    }
}
