using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.models;
using API.Services.Repositories;
using API.Services.Entities;
namespace API.Services
{
    public class CoursesServiceProvider
    {
        private readonly AppDataContext _db;

        public CoursesServiceProvider()
        {
            _db = new AppDataContext();
        }
        public List<CourseDTO> GetCoursesBySemester(string semester = null)
        {
            if(string.IsNullOrEmpty(semester))
            {

                semester = "20153";
            }

            var result = (from c in _db.Courses
                          join ct in _db.CourseTemplates on c.TemplateID equals ct.TemplateID
                          where c.Semester == semester
                          select new CourseDTO
                          {
                              ID = c.ID,
                              StartDate = c.StartDate,
                              EndDate = c.EndDate,
                              Name = ct.Name,
                              StudentCount = 0 //TODO
                              

                          }).ToList();

            return result;

       
        }

        public StudentDTO AddStudentToCourse(int id, AddStudentViewModel model)
        {
            var course = (from x in _db.Courses
                          where x.ID == id
                          select x).SingleOrDefault();
            if(course == null)
            {
                throw new AppObjectNotFoundException();
            }

            var person = (from x in _db.Persons
                          where x.SSN == model.SSN
                          select x).SingleOrDefault();

            if(person == null)
            {
                throw new AppObjectNotFoundException();
            }

            var courseStudent = new CourseStudents
            {
                PersonID = person.ID,
                CourseID = course.ID

            };

            _db.CourseStudents.Add(courseStudent);
            _db.SaveChanges();

            var returnValue = new StudentDTO
            {
                Name = person.Name,
                SSN = person.SSN
            };

            return returnValue;
        }

        public CourseDTO UpdateCourse(int id, CourseUpdateViewModel model)
        {
            //1.Validate
            //2.Update

            var courseEntity = (from x in _db.Courses
                                where x.ID == id
                                select x).SingleOrDefault();
            if(courseEntity == null)
            {
                throw new AppObjectNotFoundException();
            }

            courseEntity.StartDate = model.StartDate;
            courseEntity.EndDate = model.EndDate;

            _db.SaveChanges();

            var courseTemplate = (from x in _db.CourseTemplates 
                                 where x.TemplateID == courseEntity.TemplateID
                                 select x).SingleOrDefault();
            if(courseTemplate == null)
            {
                throw new ApplicationException("Ooooops");
            }

            var count = (from x in _db.CourseStudents
                         where x.CourseID == courseEntity.ID
                         select x).Count();

            var result = new CourseDTO
            {
                ID = courseEntity.ID,
                Name = courseTemplate.Name,
                StartDate = courseEntity.StartDate,
                EndDate = courseEntity.EndDate,
                StudentCount = count

            };

            return result;
        }
    }
}
