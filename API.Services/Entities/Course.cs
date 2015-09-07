using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Entities
{
    [Table ("Courses")]
    class Course
    {
        public int ID { get; set; }
        public string TemplateID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Semester { get; set; }
    }
}
