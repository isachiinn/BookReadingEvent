namespace Nagarro.BookReadingEvent.Shared
{

    [EntityMapping("Address", MappingType.TotalExplicit)]
    public class BookingEnrollmentDTO : DTOBase
    {
        public BookingEnrollmentDTO()
        {
            Id = -1;
        }
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Username")]
        public string Username { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "EventsId")]
        public int? EventsId { get; set; }

        public EventDTO Event { get; set; }

    }
}
