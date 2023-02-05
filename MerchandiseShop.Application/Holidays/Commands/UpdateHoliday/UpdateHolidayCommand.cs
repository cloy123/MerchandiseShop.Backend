using MediatR;

namespace MerchandiseShop.Application.Holidays.Commands.UpdateHoliday
{
    public class UpdateHolidayCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsEveryYear { get; set; }
        public int Prize { get; set; }
        public int UserTypeId { get; set; }
        public int GenderId { get; set; }
    }
}
