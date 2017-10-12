using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;
using static Exercises.Models.ViewModels.StudentVM;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new StudentVM();

            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());

            
            if(viewModel.Student.Courses != null)
            {
                viewModel.SelectedCourseIds = viewModel.Student.Courses.Select(c => c.CourseId).ToList();
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM, int id)
        {
            if(ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var ids in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(ids));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();

                viewModel.Student = StudentRepository.Get(id);
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());


                if (viewModel.Student.Courses != null)
                {
                    viewModel.SelectedCourseIds = viewModel.Student.Courses.Select(c => c.CourseId).ToList();
                }
                return View(viewModel);
            }
            
        }
        

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentVM();

            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());

            if (viewModel.Student.Courses != null)
            {
                viewModel.SelectedCourseIds = viewModel.Student.Courses.Select(c => c.CourseId).ToList();
            }


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Delete(studentVM.Student.StudentId);

            return RedirectToAction("List");
        }
    }
}