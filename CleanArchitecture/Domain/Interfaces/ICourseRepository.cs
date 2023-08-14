using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course?> GetCourses();
        public Course? GetCourseById(int id);
    }
}
