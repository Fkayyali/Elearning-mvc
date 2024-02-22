using Api.Filters;
using Api.ViewModels;
using Entity.DTOs;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpGet("/courses")]
        public async Task<IActionResult> UserCourses()
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            var user = await userRepo.GetUser(userId);
            var courses = await coursesRepo.GetCourses(userId);
            CoursesViewModel viewModel = new CoursesViewModel { Courses = courses, IsTeacher = user.Role.Name == "Teacher" };
            return View(viewModel);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpPost("/courses/add/{courseId}")]
        public async Task<IActionResult> Add(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.AddUserCourse(userId, courseId);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpGet("/courses/add")]
        public async Task<IActionResult> Add()
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpGet("/courses/new")]
        public IActionResult New()
        {
            return View();
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpPost("/courses/new")]
        public async Task<IActionResult> New( AddNewCourseDto newCourseDto)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await coursesRepo.AddNewCourse(userId, newCourseDto);
            return Redirect("/courses");
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpDelete("courses/{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.RemoveUserCourse(userId, courseId);

            return Redirect("/courses");
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpGet("/courses/{courseId}/students")]
        public async Task<IActionResult> ViewStudents(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            var students = await userRepo.GetStudents(courseId);
            StudentsViewModel viewModel = new StudentsViewModel { CourseId = courseId, Students = students };
            return View(viewModel);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpDelete("/courses/{courseId}/students/{studentId}")]
        public async Task<IActionResult> ViewStudents(int courseId, int studentId)
        {
            await userCourseRepo.RemoveUserCourse(studentId, courseId);
            var students = await userRepo.GetStudents(courseId);
            StudentsViewModel viewModel = new StudentsViewModel { CourseId = courseId, Students = students };
            return View(viewModel);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpGet("/courses/{courseId}/addStudent")]
        public async Task<IActionResult> AddStudent(int courseId)
        {
            var filteredUsers = await userRepo.GetFilteredUsers(courseId);
            AddStudentViewModel viewModel = new AddStudentViewModel { CourseId = courseId, FilteredStudents = filteredUsers };
            return View(viewModel);
        }

        [TypeFilter(typeof(TokenValidationFilterAttribute))]
        [HttpPost("/courses/{courseId}/addStudent/{studentId}")]
        public async Task<IActionResult> AddStudent(int courseId, int studentId)
        {
            await userCourseRepo.AddUserCourse(studentId, courseId);
            var filteredUsers = await userRepo.GetFilteredUsers(courseId);
            AddStudentViewModel viewModel = new AddStudentViewModel { CourseId = courseId, FilteredStudents = filteredUsers };
            return View(viewModel);
        }
    }
}
