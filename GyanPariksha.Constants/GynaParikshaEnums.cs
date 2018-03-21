using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyanPariksha.Constants
{
    public enum TestCategoryType
    {
        General,
        CAT,
        MAT,
        GATE,
        CAIIB
    }

    public enum TestStatus
    {
        complete,
        Incomplete
    }
    public enum ResultStatus {
        Fail,
        Pass,
        Qualified,
        Disqualified
    }

    public enum LevelType
    {
        Easy,
        Intermediate,
        Hard,
        EasyAndIntermediate,
        IntermediateAndHard,
        EasyAndHard,
        EasyIntermediateAndHard
    }

    public enum SetType
    {
        A,
        B,
        C
    }
    public enum RoleType
    {
        Admin,
        ExamManager,
        Examinee
    }
}
