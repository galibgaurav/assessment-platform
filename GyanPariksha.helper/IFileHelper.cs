using System.Collections.Generic;

namespace GyanPariksha.helper
{
    public interface IFileHelper
    {
        bool FileExist<T>(string path);
        IList<T> ReadFile<T>(string path, string refPath);
        bool WriteFile<T>(IList<T> lst, string refPath);
    }
}