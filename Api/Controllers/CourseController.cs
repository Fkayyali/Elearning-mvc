using Entity.DTOs;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICoursesRepo coursesRepo;
        private readonly IUserRepo userRepo;
        private readonly IUserCourseRepo userCourseRepo;
        private readonly ITokenService tokenService;
        public CourseController(ICoursesRepo coursesRepo, IUserRepo userRepo, IUserCourseRepo userCourseRepo, ITokenService tokenService)
        {
            this.coursesRepo = coursesRepo;
            this.userRepo = userRepo;
            this.userCourseRepo = userCourseRepo;
            this.tokenService = tokenService;
        }

        [HttpGet("/courses")]
        public async Task<IActionResult> UserCourses()
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            var user = await userRepo.GetUser(userId);
            var courses = await coursesRepo.GetCourses(userId);

            return View(new {courses = courses, isTeacher = user.Role.Name == "Teacher"});
        }

        [HttpPost("/courses/add/{courseId}")]
        public async Task<IActionResult> Add(int courseId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.AddUserCourse(userId, courseId);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [HttpGet("/courses/add")]
        public async Task<IActionResult> Add()
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [HttpGet("/courses/new")]
        public IActionResult New()
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            return View();
        }

        [HttpPost("/courses/new")]
        public async Task<IActionResult> New( AddNewCourseDto newCourseDto)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            await coursesRepo.AddNewCourse(userId, newCourseDto);
            return Redirect("/courses");
        }


        [HttpDelete("courses/{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.RemoveUserCourse(userId, courseId);

            return Redirect("/courses");
        }

        [HttpGet("/courses/{courseId}/students")]
        public async Task<IActionResult> ViewStudents(int courseId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            int userId = tokenService.GetUserId(token);
            var students = await userRepo.GetStudents(courseId);
            return View(new { students= students, courseId= courseId});
        }

        [HttpDelete("/courses/{courseId}/students/{studentId}")]
        public async Task<IActionResult> DeleteStudent(int courseId, int studentId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            await userCourseRepo.RemoveUserCourse(studentId, courseId);
            var students = await userRepo.GetStudents(courseId);
            return View(new { students = students, courseId = courseId });
        }

        [HttpGet("/courses/{courseId}/addStudent")]
        public async Task<IActionResult> AddStudent(int courseId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            var filteredUsers = await userRepo.GetFilteredUsers(courseId);
            return View(new { filteredUsers = filteredUsers, courseId = courseId});
        }

        [HttpPost("/courses/{courseId}/addStudent/{studentId}")]
        public async Task<IActionResult> AddStudent(int courseId, int studentId)
        {
            var token = Request.Cookies["token"];
            if (!tokenService.IsTokenValid(token))
            {
                return Redirect("/login");
            }
            await userCourseRepo.AddUserCourse(studentId, courseId);
            var filteredUsers = await userRepo.GetFilteredUsers(courseId);
            return View(new { filteredUsers = filteredUsers, courseId = courseId });
        }
    }
}
