using Abp.Applictaion.User.Dto;
using Abp.Domian.UserInfo;
using MyAbp.EntityFrameworkCore;
using MyAbp.EntityFrameworkCore.AbpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abp.Applictaion.User
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IRepository<Users> _repository;
        public UserAppService(IRepository<Users>  repository)
        {
             this._repository = repository;
        }
        public async Task<UserDto> Get (string userNo, string password){

            var user= await _repository.GetAsync(m=>m.UserNo==userNo &&m.Password==password) ;
             return ObjectMapper.Map<Users,UserDto>(user);
        }
    }
}
