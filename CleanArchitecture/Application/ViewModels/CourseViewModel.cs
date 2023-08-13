using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CoursesViewModel
    {
        [DisplayName("دوره ها")]
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }

    public class CourseViewModel
    {
        [DisplayName("کد")]
        public int Id { get; set; }

        [DisplayName("نام")]
        public string Name { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("عکس")]
        public string ImageUrl { get; set; }
    }
}
