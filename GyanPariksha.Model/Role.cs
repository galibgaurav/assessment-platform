using GyanPariksha.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Model
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public RoleType roleType { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        //public ICollection<GyanParikshaUser> gyanParikshaUser { get; set; }

    }
}
