using Volo.Abp.Application.Dtos;

namespace Abp.Applictaion.User.Dto
{
    public class UserDto:EntityDto
    {
        public string? UserNo { get; set; }
        public string? UserName { get; set; }
        public int RoleId { get; set; }
        public string? Password { get; set; }
    }
}
