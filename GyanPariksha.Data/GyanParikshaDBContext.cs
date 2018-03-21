using GyanPariksha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
namespace GyanPariksha.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    //public class GyanParikshaDBContext:DbContext
    public class GyanParikshaDBContext : IdentityDbContext<ApplicationUser>
    {
        public GyanParikshaDBContext() : base("Data Source=IN-L20042\\SQLSERVER2014;Database=GyanParikshaDB;Integrated Security=False;User ID=sa;Password=Password1;MultipleActiveResultSets=true;")
        {
             
        }
        public static GyanParikshaDBContext Create()
        {
            return new GyanParikshaDBContext();
        }
        public DbSet<Role> role{ get; set; }
       // public DbSet<GyanParikshaUser> gyanParikshaUser { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<TestCategory> testCategory { get; set; }
        public DbSet<TestSubject> testSubject { get; set; }
        public DbSet<Test> test { get; set; }
        public DbSet<TestTaken> testTaken { get; set; }
        public DbSet<TestResult> testResult { get; set; }
        public DbSet<ComplexityLevel> complexityLevel { get; set; }
        public DbSet<ComplexityMap> complexityMap { get; set; }
        public DbSet<QuestionPaper> questionPaper { get; set; }
        public DbSet<Answers> answers { get; set; }

    }
}
