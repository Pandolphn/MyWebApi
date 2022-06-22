using Abp.Domian.UserInfo;
using AspNetCore.Hashids.Json;
using HashidsNet; 
using System.Security.Policy;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Abp.Applictaion.User.Dto
{
  
    public class UserDto  
    {
        [JsonConverter(typeof(HashidsJsonConverter))]
        public int Id { get; set; }
        public string? UserNo { get; set; }
        public string? UserName { get; set; } 
        public string? Password { get; set; } 
    } 
}
