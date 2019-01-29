using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }=new List<User>();

    }
}
