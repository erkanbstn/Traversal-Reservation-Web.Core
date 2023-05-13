using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AppRoleDto
{
    public class RoleByUserListDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}
