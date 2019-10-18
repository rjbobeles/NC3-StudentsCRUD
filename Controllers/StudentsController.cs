using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using studentsCRUD.AppDBContext;
using studentsCRUD.StudentsModel;

namespace studentsCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DBContext context;

        public StudentsController(DBContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View(context.Students.ToList());
        }

        public IActionResult Add() 
        {
            return View();
        }
 
        public IActionResult AddFull()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student stud)
        {
            await Task.Run(() => {
                context.Students.Add(stud);
                context.SaveChanges();
            });

            await Task.Run(() => {
                var id = stud.StudentID;
                context.StudentInfos.Add( new StudentInfo {
                    StudentInfoID = id
                });
                context.SaveChanges();
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFull(StudentClasses studentClasses)
        {
            await Task.Run(() => {
                context.Students.Add(studentClasses.stud);
                context.SaveChanges();
            });

            await Task.Run(() => {
                studentClasses.studInfo.StudentInfoID = studentClasses.stud.StudentID;
                context.StudentInfos.Add(studentClasses.studInfo);
                context.SaveChanges();
            });
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int? id)
        {
            StudentClasses StudClass = new StudentClasses();
            StudClass.stud = context.Students.Single(s => s.StudentID == (int)id);
            StudClass.studInfo = context.StudentInfos.Single(s => s.StudentInfoID == (int)id);
            return View(StudClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int DeleteID) {

            await Task.Run(() => {
                var stud = context.Students.Single(s => s.StudentID == DeleteID);
                context.Students.Attach(stud);
                context.Students.Remove(stud);
                context.SaveChanges();
            });
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null) return RedirectToAction("Index");
            StudentClasses StudClass = new StudentClasses();
            StudClass.stud = context.Students.Single(s => s.StudentID == (int)id);
            StudClass.studInfo = context.StudentInfos.Single(s => s.StudentInfoID == (int)id);
            return View(StudClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentClasses StudClass) {
            context.Students.Update(StudClass.stud);
            context.StudentInfos.Update(StudClass.studInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
