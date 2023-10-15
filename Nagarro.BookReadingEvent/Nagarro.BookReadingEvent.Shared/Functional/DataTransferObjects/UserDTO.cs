namespace Nagarro.BookReadingEvent.Shared
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase
    {
        public UserDTO()
        {
            Id = -1;
            Type = "normal";
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Username")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]
        public string Type { get; set; }
    }
}
