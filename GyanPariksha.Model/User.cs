//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GyanPariksha.Model
//{
//    public class GyanParikshaUser
//    {
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public Guid Id { get; set; }
//        public int AccessFailedCount { get; set; }
//        public string ConcurrencyStamp { get; set; }
//        public string Email { get; set; }
//        public bool EmailConfirmed { get; set; }
//        public bool LockoutEnabled { get; set; }
//        public DateTime LockoutEnd { get; set; }
//        public string NormalizedEmail { get; set; } 
//        public string NormalizedUserName { get; set; }
//        public string PasswordHash { get; set; }
//        public string PhoneNumber { get; set; }

//        public string PhoneNumberConfirmed { get; set; }
//        public string SecurityStamp { get; set; }
//        public bool TwoFactorEnabled { get; set; }
//        public string UserName { get; set; }
//        public DateTime CreatedDateTime { get; set; }
//        public DateTime ModifiedDateTime { get; set; }
//        public Role Role { get; set; }
//    }
//}
