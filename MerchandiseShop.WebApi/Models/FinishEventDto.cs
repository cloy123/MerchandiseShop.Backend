namespace MerchandiseShop.WebApi.Models
{
    public class FinishEventDto
    {
        public Guid EventId { get; set; }
        public List<EventParticipantDto> Participants { get; set; }
    }
}
