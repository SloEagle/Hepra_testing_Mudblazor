using Domain.Entities;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Group Group { get; set; } = new Group();
    }
}
