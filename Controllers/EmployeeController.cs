using Campus_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campus_Management_System.Controllers
{
    [Route("Test")]  // this is the routing which is used for the url 
                      //eg.https://localhost:7011/Test/Emp  (Emp is the Add Employee routing)
    public class EmployeeController : Controller
    {
        EmployeeModel empObj = new EmployeeModel();
        
        
        [Route("Show")]
        public IActionResult Index()
        {
            empObj = new EmployeeModel();
            List<EmployeeModel> lst = empObj.getData();

            return View(lst);
        }
        [Route("Emp")]  // this is the attribute routing 
        public IActionResult AddEmployee()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel emp)
        {
            bool res;
            //if (ModelState.IsValid) 
            //{ 
            empObj = new EmployeeModel();
            res = empObj.insert(emp);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            //} 
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }

            return View();
        }
        [Route("Update")]
        [Route("Emp_Update")]
        public IActionResult EditEmployee()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditEmployee(string id)
        {
            EmployeeModel emp = empObj.getData(id);
            return View(emp);
        }
       
        [HttpPost]
        public IActionResult EditEmployee(EmployeeModel emp)
        {
            bool res;
            // if (ModelState.IsValid) 
            // { 
            empObj = new EmployeeModel();
            res = empObj.update(emp);
            if (res)
            {
                TempData["msg"] = "Updated successfully";
            }
            //}    
            else
            {
                TempData["msg"] = "Not Updated. something went wrong..!!";
            }
            return View();
        }

        [Route("Dlt_emp")]
        [HttpGet]
        public IActionResult DeleteEmployee(string id)
        {
            EmployeeModel emp = empObj.getData(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeModel emp)
        {
            bool res;
            //if (ModelState.IsValid) 
            //{ 
            empObj = new EmployeeModel();
            res = empObj.delete(emp);
            if (res)
            {
                TempData["msg"] = "Deleted successfully";
            }
            //} 
            else
            {
                TempData["msg"] = "Not Deleted. something went wrong..!!";
            }

            return View();
        }
    }
}
