
using System;
using System.ComponentModel.DataAnnotations;


namespace Nagarro.BookReadingEvent.Shared
{
    [EntityMapping("Event", MappingType.TotalExplicit)]
    public class EventDTO : DTOBase
    {
        public EventDTO()
        {
            Type = "public";
            Id = -1;
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [Required]
        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }


        public AddressDTO Address { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "AddressId")]
        public int AddressId { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]
        public string Type { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime Date { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "StartTime")]
        [DataType(DataType.Time)]
        [Required]
        public TimeSpan StartTime { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "Duration")]
        [Range(0, 4)]
        public int Duration { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        [MaxLength(50)]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "OtherDetails")]
        [MaxLength(500)]
        public string OtherDetails { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Creator")]
        public string Creator { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Invitations")]
        [MaxLength(5000)]
        public string Invitations { get; set; }



    }
}
