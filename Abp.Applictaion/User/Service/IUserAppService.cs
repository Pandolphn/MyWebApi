using Abp.Applictaion.User.Dto;
using Abp.Domian.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.Applictaion.User
{
    public interface IUserAppService:IApplicationService
    {
            Task<UserDto> Get(string userNo, string password);
        UserDto Get1( );
    }
}
