using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private UniversityDbContext _context;

        public CourseRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }
    }
}
