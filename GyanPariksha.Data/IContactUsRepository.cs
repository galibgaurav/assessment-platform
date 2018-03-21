using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GyanPariksha.Model;

namespace GyanPariksha.Data
{
    public interface IContactUsRepository
    {
        Task<bool> DeleteContactUs(Guid id);
        void Dispose();
        IEnumerable<ContactUs> GetContactUs();
        Task<ContactUs> GetContactUs(Guid id);
        Task<ContactUs> PostContactUs(ContactUs contactUs);
        Task<ContactUs> PutContactUs(Guid id, ContactUs contactUs);
    }
}