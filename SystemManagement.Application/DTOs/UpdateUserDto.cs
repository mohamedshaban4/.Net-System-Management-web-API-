using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Application.DTOs
{
    public class UpdateUserDto : BaseUserDto
    {
       
        public int RoleId { get; set; }
    }
}
