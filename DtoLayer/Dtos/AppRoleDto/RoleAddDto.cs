using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AppRoleDto
{
    public class RoleAddDto
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
