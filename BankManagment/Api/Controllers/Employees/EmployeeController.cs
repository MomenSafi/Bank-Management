using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Infrastructure.DTO;
using DomainEntities.DBEntities;
using Newtonsoft.Json;

namespace Api.Controllers.Employees
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IQualificationRepository _qualificationRepository;

        public EmployeeController (IEmployeeRepository employeeRepository, IQualificationRepository qualificationRepository)
        {
            _employeeRepository = employeeRepository;
            _qualificationRepository = qualificationRepository;
        }
        
        public IActionResult AddNewEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee();

            employee.Address = employeeDTO.Address;
            employee.DateOfBirth = employeeDTO.DateOfBirth;
            employee.Email = employeeDTO.Email;
            employee.FullName = employeeDTO.FullName;
            employee.JoinDate = employeeDTO.JoinDate;
            employee.Mobile = employeeDTO.Mobile;
            employee.Salary = employeeDTO.Salary;
            employee.QualificationId = employeeDTO.QualificationId;

            _employeeRepository.Add(employee);

            return Ok("Success");
        }
        
        public IActionResult UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee();
            employee = _employeeRepository.GetById(employeeDTO.Id);

            employee.Address = employeeDTO.Address;
            employee.DateOfBirth = employeeDTO.DateOfBirth;
            employee.Email = employeeDTO.Email;
            employee.FullName = employeeDTO.FullName;
            employee.JoinDate = employeeDTO.JoinDate;
            employee.Mobile = employeeDTO.Mobile;
            employee.Salary = employeeDTO.Salary;
            employee.QualificationId = employeeDTO.QualificationId;

            _employeeRepository.Update(employee);

            return Ok("Success");

        }

        public IActionResult DeleteEmployee(int id) 
        {
            Employee employee = new Employee();
            employee = _employeeRepository.GetById(id);

            _employeeRepository.Delete(employee);

            return Ok("Success");
        }

        public IActionResult GetAllEmployee()
        {
            List<EmployeeDTO> lstData = (from obj in _employeeRepository.GetAll()
                                         select new  EmployeeDTO
                                         {
                                             Id = obj.Id,
                                             Address = obj.Address,
                                             DateOfBirth = obj.DateOfBirth,
                                             Email = obj.Email,
                                             FullName = obj.FullName,
                                             Salary = obj.Salary,
                                             QualificationId = obj.QualificationId,
                                             JoinDate = obj.JoinDate,
                                             Mobile = obj.Mobile,
                                         }).ToList();

            string jsonString = JsonConvert.SerializeObject(lstData,Formatting.None,  new JsonSerializerSettings
                {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore

            });

            return Ok(jsonString);
        }

        public IActionResult GetAllQualification()
        {
            List<QualificationDTO> lst = (from obj in _qualificationRepository.GetAll()
                                          select new QualificationDTO
                                          {
                                              Id= obj.Id,
                                              Name= obj.Name,
                                          }).ToList ();

            string jsonString = JsonConvert.SerializeObject(lst, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok("jsonString");
        }
    }
}
