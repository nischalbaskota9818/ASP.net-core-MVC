/* using Microsoft.AspNetCore.Mvc;
using studentportal.web.Data;
using studentportal.web.Models;
using studentportal.web.Models.Entities;
using Microsoft.EntityFrameworkCore;
//added header 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace studentportal.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       // public ApplicationDbContext DbContext { get; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //let create submit method 

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();




            if (ModelState.IsValid)
            {
                // Process the data (e.g., save to database)
                // For now, let's just return the same view with the posted data
                return View("Success", viewModel);
            }
            return View(viewModel);
        }

       /* [HttpGet]
         public async Task<IActionResult> List()
         {
            {
                var students = await dbContext.Students.ToListAsync();

             return View(students);
         }*/

// mathi ko le kam nagarera yo haleko 

/*[HttpGet]
 public async Task<IActionResult> List()
 {
     try
     {
         var students = await dbContext.Students.ToListAsync();
         return View(students);
     }
     catch (Exception ex)
     {
         // Log the exception
         Console.WriteLine(ex.Message);
         return View(new List<Student>()); // Return an empty list in case of error
     }
 }


}
}

*/
using Microsoft.AspNetCore.Mvc;
using studentportal.web.Data;
using studentportal.web.Models;
using studentportal.web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentportal.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            //if (ModelState.IsValid)
            // {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();   //("Success", viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
     
            if (student is not null)
            {
                //we wnat to delete the details if student is not null.
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");

        }
    }
}




