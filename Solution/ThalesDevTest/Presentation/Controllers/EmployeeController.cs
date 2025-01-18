using Business;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly B_Employee _employee;

        public EmployeeController(B_Employee b_Employee) {
            _employee = b_Employee;
        }

        public IActionResult Employee() {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetEmployees() {
            var data = await _employee.GetEmployees();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetEmployeeById([FromRoute] int id) {
            var data = await _employee.GetEmployeeById(id);
            return Json(data);
        }
    }
}
