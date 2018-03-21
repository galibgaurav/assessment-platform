using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyanPariksha.helper;
using GyanPariksha.Model;

namespace GyanPriksha.BL
{
    public class QuestionPaperBL : IQuestionPaperBL
    {
        IFileHelper fileHelper;
        static string fileStoragePath {get;set;}
        public QuestionPaperBL(IFileHelper _fileHelper)
        {
            fileHelper = _fileHelper;
        }
        public bool WriteQuestionPaper (IList<QuestionEntity> Questions,string testID)
        {
            try {
              return  fileHelper.WriteFile(Questions, testID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public string ReadQuestionPaper(string QuestionPaperID, string testID)
        {
            return null;
        }
    }
}
