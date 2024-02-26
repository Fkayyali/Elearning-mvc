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
    [TypeFilter(typeof(TokenValidationFilterAttribute))]
    public class CourseController : Controller
    {
        private readonly ICoursesService coursesRepo;
        private readonly IUserService userRepo;
        private readonly IUserCourseService userCourseRepo;
        private readonly ITokenService tokenService;
        public CourseController(ICoursesService coursesRepo, IUserService userRepo, IUserCourseService userCourseRepo, ITokenService tokenService)
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
            int userId = tokenService.GetUserId(token);
            var user = await userRepo.GetUser(userId);
            var courses = await coursesRepo.GetCourses(userId);
            CoursesViewModel viewModel = new CoursesViewModel { Courses = courses, IsTeacher = user.Role.Name == "Teacher" };
            return View(viewModel);
        }

        [HttpPost("/courses/add/{courseId}")]
        public async Task<IActionResult> Add(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.AddUserCourse(userId, courseId);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [HttpGet("/courses/add")]
        public async Task<IActionResult> Add()
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            var courses = await coursesRepo.GetFilteredCourses(userId);
            return View(courses);
        }

        [HttpGet("/courses/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("/courses/new")]
        public async Task<IActionResult> New( AddNewCourseDto newCourseDto)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await coursesRepo.AddNewCourse(userId, newCourseDto);
            return Redirect("/courses");
        }

        [HttpDelete("courses/{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            await userCourseRepo.RemoveUserCourse(userId, courseId);

            return Redirect("/courses");
        }

        [HttpGet("/courses/{courseId}/students")]
        public async Task<IActionResult> ViewStudents(int courseId)
        {
            var token = Request.Cookies["token"];
            int userId = tokenService.GetUserId(token);
            var students = await userRepo.GetStudents(courseId);
            StudentsViewModel viewModel = new StudentsViewModel { CourseId = courseId, Students = students };
            return View(viewModel);
        }

        [HttpDelete("/courses/{courseId}/students/{studentId}")]
        public async Task<IActionResult> ViewStudents(int courseId, int studentId)
        {
            await userCourseRepo.RemoveUserCourse(studentId, courseId);
            var students = await userRepo.GetStudents(courseId);
            StudentsViewModel viewModel = new StudentsViewModel { CourseId = courseId, Students = students };
            return View(viewModel);
        }

        [HttpGet("/courses/{courseId}/addStudent")]
        public async Task<IActionResult> AddStudent(int courseId)
        {
            var filteredUsers = await userRepo.GetFilteredUsers(courseId);
            AddStudentViewModel viewModel = new AddStudentViewModel { CourseId = courseId, FilteredStudents = filteredUsers };
            return View(viewModel);
        }

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
