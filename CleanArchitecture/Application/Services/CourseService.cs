using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;

namespace Application.Services
{
    public class CourseService:ICourseService
    {
        private ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public CoursesViewModel GetCourses()
        {
            return new CoursesViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}
