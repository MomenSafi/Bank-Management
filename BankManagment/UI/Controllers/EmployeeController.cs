using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Newtonsoft.Json;
using System.Text;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:37833/";

            var response = await client.GetAsync(url + "api/Employee/GetAllQualification");

            string apiResponse = await response.Content.ReadAsStringAsync();

            ViewBag.Qualification = JsonConvert.DeserializeObject<List<QualificationDTO>>(apiResponse);

            return View();
        }

        public async Task<IActionResult> AddNewEmployee(EmployeeDTO employeeDTO) 
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:37833/";

            var EmployeeContextDTO = JsonConvert.SerializeObject(employeeDTO);

            var response = await client.PostAsync(url + "api/Employee/AddNewEmployee",
                new StringContent(EmployeeContextDTO, Encoding.UTF8, "application/json"));

            if(response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
                //Error page 
            }
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:37833/";

            var response = await client.GetAsync(url + "api/Employee/GetAllEmployee");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(apiResponse);



            return View(result);
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
