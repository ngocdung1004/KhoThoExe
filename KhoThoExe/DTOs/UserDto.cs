namespace KhoThoExe.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; } // 'Customer' hoặc 'Worker'
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
