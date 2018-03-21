using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Model
{
    public class Answers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Test Id is Needed.")]
        public Test TestId { get; set; }
        //[Required(ErrorMessage = "UserId is Needed.")]
        //public GyanParikshaUser UserId { get; set; }
        [Required(ErrorMessage = "UserId is Needed.")]
        public string UserId { get; set; }
        [Required(AllowEmptyStrings =true,ErrorMessage = "Answer is Needed.")]
        public string ExamineeAnswer { get; set; }
        [Required(ErrorMessage = "CreatedDateTime is Needed.")]
        public DateTime CreatedDateTime { get; set; }
    }
}
