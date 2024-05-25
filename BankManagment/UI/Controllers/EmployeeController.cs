using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Create()
        {
            HttpClient httpClient = new HttpClient();

            string url = "http://localhost:37833/";

            var response = await httpClient.GetAsync(url + "api/Employee/GetAllQualification");

            string apiResponse = await response.Content.ReadAsStringAsync();

            ViewBag.Qualification = JsonConvert.DeserializeObject<List<QualificationDTO>>(apiResponse);

            return View();
        }

        public IActionResult AddNewEmployee(EmployeeDTO employeeDTO) 
        {
            return View();
        }
    }
}
