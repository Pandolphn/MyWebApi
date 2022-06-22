using Abp.Applictaion.User.Dto;
using Abp.Domian.UserInfo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Applictaion
{
    public class AbpApplicationAutomapperProfile:Profile
    {
        public AbpApplicationAutomapperProfile()
        {
             CreateMap<Users, UserDto>();
        }
    }
}
