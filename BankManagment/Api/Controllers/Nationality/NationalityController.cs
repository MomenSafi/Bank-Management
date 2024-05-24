using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories.IRepository;
using System.Xml;

namespace Api.Controllers.Nationality
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class NationalityController : Controller
    {
        private readonly INationalityRepository _nationalityRepository;

        public NationalityController(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }

        public IActionResult GetAllNationality()
        {
            var result = _nationalityRepository.GetAll().ToList();

            string JsonString = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(result);
        }
        public IActionResult AddNewNationality(Infrastructure.DTO.NationalityDTO nationalityDTO)
        {
            DomainEntities.DBEntities.Nationality obj = new DomainEntities.DBEntities.Nationality();
            obj.Name = nationalityDTO.NationalityName;

            _nationalityRepository.Add(obj);

            return Ok("Ok");
        }

        public IActionResult UpdateNationality(int Id, String Name)
        {
            DomainEntities.DBEntities.Nationality obj = new DomainEntities.DBEntities.Nationality();
            obj = _nationalityRepository.GetAll().Where(n => n.Id == Id).FirstOrDefault();

            obj.Name = Name;
            _nationalityRepository.Update(obj);
            return Ok("");
        }
    }
}
