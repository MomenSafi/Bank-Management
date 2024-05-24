using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace UI.Controllers
{
    public class NationalityController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AddNewNationality(Infrastructure.DTO.NationalityDTO nationalityDTO)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:37833/";

            var nationalityContextDTO = JsonConvert.SerializeObject(nationalityDTO);

            var response = await client.PostAsync(url + "api/Nationality/AddNewNationality",
                new StringContent(nationalityContextDTO, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Good
            }
            else
            {
                 // Error
            }
            return View();
        }
    }
}
