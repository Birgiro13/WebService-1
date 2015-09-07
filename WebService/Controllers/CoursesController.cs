using System.Web.Http;
using WebService.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Net;
using API.Services;
using API.models;
using System.Web.Http.Description;




namespace WebService.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private readonly CoursesServiceProvider _service;

        public CoursesController()
        {
            _service = new CoursesServiceProvider();
        }

        [HttpPut]
        [Route("{id}")]
        public CourseDTO UpdateCourse(int id, CourseUpdateViewModel model)
        {
        
                try
                {
                     return _service.UpdateCourse(id, model);

                }
                catch (AppObjectNotFoundException)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }


        }

        [HttpGet]
        [Route("")]

        public List<CourseDTO> GetCoursesBySemester(string semester = null)
        {

            return _service.GetCoursesBySemester(semester);
        }



        [HttpGet]
        [Route("{id}/students")]
        public List<StudentDTO> GetStudentsInCourse(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("{id}/students")]
        [ResponseType(typeof(StudentDTO)) ]
        public IHttpActionResult AddStudentToCourse(int id, AddStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    var result = _service.AddStudentToCourse(id, model);

                    return Content(HttpStatusCode.Created, result);

                }
                catch(AppObjectNotFoundException)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
                
                

            }
            else
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
        }
        /// <summary>
        /// Removes selected course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [HttpDelete]
        [Route("{id}")]
        public void DeleteCourse(int id, CourseUpdateViewModel model)
        {
            try
            {
                _service.DeleteCourse(id, model);
            }
            catch (AppObjectNotFoundException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        
        /*
        //Lists that contain the courses and students 
        private static List<Courses> courses;
        private static List<Students> students;
        public CoursesController()
        {
            //The courses we chose to add to the list are created here below.
            if(courses == null)
            {
                courses = new List<Courses>
            {

                new Courses()
                {
                ID = 1, 
                CourseID = "T-514-VEFT", 
                Name =   "Vefþjónustur",
                StartDate = new DateTime(2015, 8, 17),
                EndDate =  new DateTime(2015, 12, 5)

                },
                new Courses()
                {
                ID = 2, 
                CourseID = "T-301-REIR", 
                Name =   "Reiknirit",
                StartDate = new DateTime(2015, 8, 17),
                EndDate =  new DateTime(2015, 12, 5)

                },
                new Courses()
                {
                ID = 3, 
                CourseID = "T-316-UPPL", 
                Name =   "Upplýsingarþjóðfélagið",
                StartDate = new DateTime(2015, 8, 17),
                EndDate =  new DateTime(2015, 12, 5)

                },
                new Courses()
                {
                ID = 4, 
                CourseID = "T-302-HONN", 
                Name =   "Hönnun og smíði hugbúnaðar",
                StartDate = new DateTime(2015, 8, 17),
                EndDate =  new DateTime(2015, 12, 5)

                } 
               };
 
           }
        }

        [HttpGet]
        [Route("")]
        //Returns the list of courses when we execute the GET statement on the given route.
        public List<Courses> GetCourses()
        {

            return courses;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCourse")]

        //Returns the course with the given ID.
        public Courses GetCourseByID(int id)
        {
            var result = (from course in courses
                          where course.ID == id
                          select course).SingleOrDefault();

                   return result;

        }
        
    
        [HttpPost]
        [Route("")]

        //Uses the POST method to add a new course to the list of courses 
        public IHttpActionResult AddCourse(Courses course)
        {
            courses.Add(course);
            var location = Url.Link("GetCourse", new { id = course.ID });
            return Created(location, course);

        }

        [HttpPut]
        [Route("")]
        
        //Uses the PUT method to update a course. 
        public IHttpActionResult UpdateCourse(Courses c)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (c.ID == courses[i].ID)
                {
                    courses[i] = c;
                    
                }
            }

            return Ok();
        }
        [HttpDelete]
        [Route("")]

        //Uses the DELETE method to remove a course from the list.
        public void DeleteCourse(Courses c)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (c.ID == courses[i].ID)
                {

                    courses.RemoveAt(i);

                    break;
                }
            }

        }

        [HttpGet]
        [Route("{id}/students")]
        //Creates students to add to the courses and returns them in a list.
        public List<Students> GetStudents(int id)
        { 
            if(students == null)
            {
                students = new List<Students>
                {
                    new Students()
                    {

                    SSN = "140694-3479",
                    Name = "Birgir Þór Óskarsson"

                    },
                    new Students()
                    {

                    SSN = "010993-3349",
                    Name = "Þórhildur Guðný Sigþórsdóttir"

                    }
            

                };
            
            }

            return students;

        }
        
        [HttpGet]
        [Route("{id/students}", Name = "GetStudent")]

        //Gets the student by a given SSN number(ID)
        public Students GetStudentByID(string id)
        {
            var result = (from student in students
                          where student.SSN == id
                          select student).SingleOrDefault();
            if(result != null)
            {
                return result;
            }
            
            return "Error"
            
        }
       
        [HttpPost]
        [Route("{id}/students")]
 
        //Uses the POST method to add a new student to the list.
        //For some reason the only way to add a student to the list is to GET the list first
        //and then add to it. 
        public IHttpActionResult AddStudent(Students student)
        {
            students.Add(student);
            var location = Url.Link("GetStudent", new { id = student.SSN });
            return Created(location, student);

        }*/
        
    }
}
