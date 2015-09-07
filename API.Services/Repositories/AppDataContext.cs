using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Services.Entities;

namespace API.Services.Repositories
{
    class AppDataContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTemplates> CourseTemplates { get; set; }

        public DbSet<Persons> Persons { get; set; }

        public DbSet<CourseStudents> CourseStudents { get; set; }
    }
}
