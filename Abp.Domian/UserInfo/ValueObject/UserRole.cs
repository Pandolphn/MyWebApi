using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Abp.Domian.UserInfo
{
    public class UserRole :ValueObject 
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserRole(int UserId,int RoleId)
        {
            this.UserId = UserId;
            this.RoleId = RoleId;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserId;
            yield return RoleId;
        }
    }
}
