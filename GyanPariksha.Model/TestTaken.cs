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
    public class TestTaken
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Test TestId { get; set; }
        [Required]
        public TestStatus TestStatus { get; set; }
        //[Required]
        //public GyanParikshaUser UserId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TotalQuestionAttempted { get; set; }
        [Required]
        public DateTime TestDateTime { get; set; }
        [Required]
        public string ExamineeRemark { get; set; }
    }
}
