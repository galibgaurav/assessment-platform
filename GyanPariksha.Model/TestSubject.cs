using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Model
{
    public class TestSubject
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }
        [Required]
        public string TestCategoryId { get; set; }
    }
}
