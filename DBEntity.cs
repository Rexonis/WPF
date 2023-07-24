using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Registration
{
    internal class Role
    {
        [Required, Key]
        public Int32 Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<User> Users { get; set; }
    }
    internal class User
    {
        [Required, Key]
        public Int32 Id { get; set; }
        public int RoleId { get; set; }
        [Required]
        public String Login { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public Role Role { get; set; }
    }
    internal class DBEntity
    {
    }
}
