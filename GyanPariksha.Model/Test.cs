using GyanPariksha.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Model
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }       
        [Required]
        public string TestTitle { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public SetType SetType { get; set; }
        [Required]
        public string PositiveMark { get; set; }
        [Required]
        public string NegativeMark { get; set; }
        [Required]
        public bool IsAllAnswerCompulsory { get; set; }
        [Required]
        public int TotalQuestions { get; set; }
        [Required]
        public bool IsMultipleChoice { get; set; }
        [Required]
        public bool IsSubjectiveType { get; set; }
        [Required]
        public string TestInstructions { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }
        [Required]
        public string TestSubjectId { get; set; }
    }
}
