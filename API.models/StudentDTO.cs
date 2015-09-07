using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.models
{
    public class StudentDTO
    {
        /// <summary>
        /// This class represents a student in a course.
        /// </summary>

        /// <summary>
        /// The students social securtity number which serves
        /// as a identifier for the student.
        /// Example: "010993-3349"
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// The name of the student.
        /// Example: "Þórhildur Guðný Sigþórsdóttir"
        /// </summary>
        public string Name { get; set; }
    }

}
