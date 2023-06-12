using Asp.Net_Core_Homework.Data;
using Asp.Net_Core_Homework.Models;
using Asp.Net_Core_Homework.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Homework.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ProjectDbContext projectDbContext;

        public DoctorsController(ProjectDbContext projectDbContext)
        {
            this.projectDbContext = projectDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await projectDbContext.Doctors.ToListAsync();
            return View(doctors);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddDoctorViewModel addDoctorRequest)
        {
            var doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                Name = addDoctorRequest.Name,
                Email = addDoctorRequest.Email,
                Branch = addDoctorRequest.Branch,
                PhoneNumber = addDoctorRequest.PhoneNumber,
                DateOfBirth = addDoctorRequest.DateOfBirth,
                NumberOfPatients = addDoctorRequest.NumberOfPatients,
            };

            await projectDbContext.Doctors.AddAsync(doctor);
            await projectDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {

            var doctor = await projectDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                var viewModel = new UpdateDoctorViewModel()
                {

                    Id = doctor.Id,
                    Name = doctor.Name,
                    Email = doctor.Email,
                    Branch = doctor.Branch,
                    PhoneNumber = doctor.PhoneNumber,
                    DateOfBirth = doctor.DateOfBirth,
                    NumberOfPatients = doctor.NumberOfPatients,

                };
                return await Task.Run(() => View("View", viewModel));

            }

            {




            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateDoctorViewModel model)
        {

            var doctor = await projectDbContext.Doctors.FindAsync(model.Id);
            if (doctor != null)
            {
                doctor.Name = model.Name;
                doctor.Email = model.Email;
                doctor.PhoneNumber = model.PhoneNumber;
                doctor.DateOfBirth = model.DateOfBirth;
                doctor.Branch = model.Branch;
                doctor.NumberOfPatients = model.NumberOfPatients;
                await projectDbContext.SaveChangesAsync();


            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateDoctorViewModel model)
        {

            var doctor = await projectDbContext.Doctors.FindAsync(model.Id);
            if (doctor != null)
            {
                projectDbContext.Doctors.Remove(doctor);
                await projectDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

