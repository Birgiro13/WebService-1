using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.models
{
    /// <summary>
    /// This item represents and item in a list of courses
    /// </summary>
    public class CourseDTO
    {
        /// <summary>
        /// A unique identifier for the course.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the course.
        /// Example: "Vefþjónustur"
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// An identifier of the template of the course.
        /// Example: "T-514-VEFT"
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// The date the course starts.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date the course ends.
        /// </summary>
        public DateTime EndDate { get; set; }

        public int StudentCount { get; set; }
    }
}
