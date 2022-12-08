using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class RoleTableEntity
    {
        public RoleTableEntity()
        {
            this.UserTables = new HashSet<UserTableEntity>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserTableEntity> UserTables { get; set; }
    }
}