using AspNetCore.Hashids.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Abp.Applictaion.User.Dto
{
    public class CustomerDto
    {
        [JsonConverter(typeof(HashidsJsonConverter))]
        public int Id { get; set; }
        [JsonConverter(typeof(NullableHashidsJsonConverter))]
        public int? NullableId { get; set; }
        public int NonHashid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
