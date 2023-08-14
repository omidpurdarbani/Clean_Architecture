using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            return View(_courseService.GetCourses());
        }

        public IActionResult Details(int id)
        {
            var model = _courseService.GetCourse(id);
            return model != null ? View(model) : NotFound();
        }
    }
}
