using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Abp.Domian.UserInfo
{
    public class Roles:Entity<int>
    {
        public string RoleName { get; set; }

    }
}
