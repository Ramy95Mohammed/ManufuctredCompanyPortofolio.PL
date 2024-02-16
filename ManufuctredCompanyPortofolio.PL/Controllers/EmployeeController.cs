using ManufctredCompanyPortofolio.BLL.IUnitOfWork;
using ManufuctredCompanyPortofolio.DAL;
using ManufuctredCompanyPortofolio.DAL.Entities;
using ManufuctredCompanyPortofolio.DAL.Resources;
using ManufuctredCompanyPortofolio.PL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ManufuctredCompanyPortofolio.PL.Controllers
{
	
	public class EmployeeController : MyController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProgramLanguage language;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IUnitOfWork unitOfWork, IProgramLanguage language, IWebHostEnvironment hostingEnvironment) :base(language)
        {
            this.unitOfWork = unitOfWork;
            this.language = language;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            Employee employee;
            if (id != null)
                employee = await unitOfWork.EmployeeRepository.GetFirstOrDefault(x => x.KeyID == id);
            else employee = new Employee();
                return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Employee employee)
        {
            try
            {
              string strFilePath =  await ExtCls.SaveImageFile(employee.Image, _hostingEnvironment,employee.ImageName);
                employee.ImageName = strFilePath;
                await unitOfWork.EmployeeRepository.Insert(employee);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["Employeemsg"] = Resource.lbl_operationSucceded;
                    return Redirect("/Employee/Index/");
                }
                return View(nameof(Index));
            }
            catch(Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }
       [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            try
            {
                if(employee.Image != null)
                ExtCls.DeleteImageFile(employee.ImageName,_hostingEnvironment);
                string strFilePath = await ExtCls.SaveImageFile(employee.Image, _hostingEnvironment,employee.ImageName);
                employee.ImageName = strFilePath;
                await unitOfWork.EmployeeRepository.Update(employee);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["Employeemsg"] = Resource.lbl_operationSucceded;
                    return Redirect("/Employee/Index/");
                }
                return View(nameof(Index));
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            try
            {
                ExtCls.DeleteImageFile(employee.ImageName, _hostingEnvironment);                                
                await unitOfWork.EmployeeRepository.Delete(employee);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["Employeemsg"] = Resource.lbl_operationSucceded;
                    return Redirect("/Employee/Index/");
                }
                return View(nameof(Index));
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }       
    }
}
