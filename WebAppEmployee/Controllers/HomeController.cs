using Employee.Core.Application.Dtos;
using Employee.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppEmployee.Models;

namespace WebAppEmployee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _svc;
        private readonly IUploadFileService _uploadSvc;
        public HomeController(IEmployeeService svc, IUploadFileService uploadSvc)
        {
            _svc = svc;
            _uploadSvc = uploadSvc;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _svc.GetAllAsync());
        }

        public IActionResult Add()
        {
            return View("SaveEdit", new EmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto vm)
        {
            if (!ModelState.IsValid)
                return View("SaveEdit", vm);

            var imagen = vm.Fotografia;
            vm = await _svc.AddAsync(vm);


            string basePath = $"/Images/Property/{vm.Id}";

            vm.FotografiaUrl = _uploadSvc.UploadFile(imagen, basePath);
            await _svc.UpdateAsync(vm, vm.Id);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("SaveEdit", await _svc.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeDto vm)
        {
            await _svc.UpdateAsync(vm, vm.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Disassociation(int id)
        {
            return View("Disassociation", await _svc.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Disassociation(EmployeeDto vm)
        {
            await _svc.EmployeeTermination(vm.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}