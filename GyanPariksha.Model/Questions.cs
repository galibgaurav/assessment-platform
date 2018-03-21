using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Model
{
    [Serializable] 
    public class QuestionEntity
    {
        
        public string ID { get; set; }
        public string question { get; set; }
        public IDictionary<string,string> choices { get; set; }
        public string keyChoice { get; set; }
        public string hint { get; set; }
    }
    
}
