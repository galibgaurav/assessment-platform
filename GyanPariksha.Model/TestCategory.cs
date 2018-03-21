using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyanPariksha.Constants;
using System.ComponentModel.DataAnnotations;

namespace GyanPariksha.Model
{
    public class TestCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public TestCategoryType CategoryType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }
    }
}
