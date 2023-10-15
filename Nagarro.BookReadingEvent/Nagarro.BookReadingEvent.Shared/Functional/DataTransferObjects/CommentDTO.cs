using System;

using System.ComponentModel.DataAnnotations;
namespace Nagarro.BookReadingEvent.Shared
{
    [EntityMapping("Comment", MappingType.TotalExplicit)]
    public class CommentDTO : DTOBase
    {
        public CommentDTO()
        {
            Id = -1;
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comment1")]
        [Required]
        public string Comment1 { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DatePosted")]
        public DateTime? DatePosted { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Username")]
        public string Username { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int? EventId { get; set; }

        public EventDTO Event { get; set; }

    }
}
