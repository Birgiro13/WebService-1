using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.models
{
    public class AddStudentViewModel
    {
        [Required]
        public string SSN { get; set; }

    }
}
