using ManufuctredCompanyPortofolio.DAL.Resources;
using ManufuctredCompanyPortofolio.DAL.Entities;
using ManufuctredCompanyPortofolio.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ManufctredCompanyPortofolio.BLL.IUnitOfWork;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;





namespace ManufuctredCompanyPortofolio.PL.Controllers
{    
    public class ManufctredCompanyController : MyController
    {                
        private readonly IProgramLanguage language;
        private readonly IUnitOfWork unitOfWork;
        public ManufctredCompanyController(IUnitOfWork iUnitOfWork
            , IProgramLanguage language):base(language)
        {         
            this.unitOfWork = iUnitOfWork;
            this.language = language;
        }
      
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {            
            ManufcturingCompany company;
            if (id != null)
            {
                 company =await unitOfWork.ManufuctresCompanyRepository.GetFirstOrDefault(x => x.KeyID == id,
                     $"{nameof(ManufcturingCompany.ManuductringCompanyBranches)},{nameof(ManufcturingCompany.ManufcturingCompanyPhones)}");  
            }
            else
            {
                company = new ManufcturingCompany() { IsActive=true};
                company.ManuductringCompanyBranches.Add(new ManuductringCompanyBranch() { IsActive=true});
                company.ManufcturingCompanyPhones.Add(new ManufcturingCompanyPhone());
            }
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ManufcturingCompany company)
        {
            try
            {
                var CompanyBranches = company.ManuductringCompanyBranches.Where(x => x.IsCompanyBranchDeleted == false);
                var companyPhones = company.ManufcturingCompanyPhones.Where(x => x.IsCompanyCommuncationDeleted == false);

                company.ManuductringCompanyBranches = CompanyBranches.ToList();
                company.ManufcturingCompanyPhones = companyPhones.ToList();
               await unitOfWork.ManufuctresCompanyRepository.Insert(company);
                if(await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["msg"] = Resource.lbl_operationSucceded;
                    return Redirect("/ManufctredCompany/Index/");
                }
                else
                {
                    return View(nameof(Index), company);
                }
            }
            catch (Exception ex)
            {
                //Write Exption To log File Here
                return Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManufcturingCompany company)
        {
            try
            {
                if (await unitOfWork.ManufuctresCompanyRepository.GetFirstOrDefault(x => x.KeyID != company.KeyID && x.Code == company.Code) != null)
                {
                    TempData["msg"] = Resource.lbl_RepeatedCode;

                    return View(nameof(Index) ,company);
                }

                var ToDelete = company.ManuductringCompanyBranches.Where(x => x.IsCompanyBranchDeleted == true);
                foreach (var x in ToDelete.ToList())
                {
                    var Branch = await unitOfWork.ManuductringCompanyBranchRepository.GetFirstOrDefault(y => y.KeyID == x.KeyID);
                    if (Branch != null)
                    {
                        await unitOfWork.ManuductringCompanyBranchRepository.Delete(Branch);
                    }
                }                           

                var CompanyBranches = company.ManuductringCompanyBranches.Where(x => x.IsCompanyBranchDeleted == false);
                foreach (var x in CompanyBranches.ToList())
                {
                    x.ManufcturingCompanyId = company.KeyID;
                    if (await unitOfWork.ManuductringCompanyBranchRepository.GetFirstOrDefault(y => y.KeyID == x.KeyID) != null)
                    {
                        await unitOfWork.ManuductringCompanyBranchRepository.Deatach(nameof(x.KeyID), x.KeyID);
                        await unitOfWork.ManuductringCompanyBranchRepository.Update(x);
                    }
                    else
                    {
                        await unitOfWork.ManuductringCompanyBranchRepository.Insert(x);
                    }

                }

                foreach (var x in company.ManufcturingCompanyPhones.Where(x => x.IsCompanyCommuncationDeleted == true).ToList())
                {
                    var phone = unitOfWork.ManufcturingCompanyPhoneRepository.GetFirstOrDefault(y => y.KeyID == x.KeyID).Result;
                    if (phone != null)
                    {
                        await unitOfWork.ManufcturingCompanyPhoneRepository.Delete(phone);
                    }
                }               

                var companyPhones = company.ManufcturingCompanyPhones.Where(x => x.IsCompanyCommuncationDeleted == false);

                foreach (var x in companyPhones.ToList())
                {
                    x.ManufcturingCompanyId = company.KeyID;
                    if (await unitOfWork.ManufcturingCompanyPhoneRepository.GetFirstOrDefault(y => y.KeyID == x.KeyID) != null)
                    {
                        await unitOfWork.ManufcturingCompanyPhoneRepository.Deatach(nameof(x.KeyID), x.KeyID);
                        await unitOfWork.ManufcturingCompanyPhoneRepository.Update(x);
                    }
                    else
                    {
                        await unitOfWork.ManufcturingCompanyPhoneRepository.Insert(x);
                    }
                }               
               await unitOfWork.ManufuctresCompanyRepository.Update(company);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["msg"] = Resource.lbl_operationSucceded;
                    return Redirect("/ManufctredCompany/Index/");
                }
                else
                {
                    return View(nameof(Index), company);
                }
            }
            catch (Exception ex)
            {
                //Write Exption To log File Here
                return Redirect("/Home/Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ManufcturingCompany company)
        {
            try
            {

               await unitOfWork.ManuductringCompanyBranchRepository.DeleteRange(await unitOfWork.ManuductringCompanyBranchRepository.GetAll(x => x.ManufcturingCompanyId == company.KeyID));
               await unitOfWork.ManufcturingCompanyPhoneRepository.DeleteRange(await unitOfWork.ManufcturingCompanyPhoneRepository.GetAll(x => x.ManufcturingCompanyId == company.KeyID));
                await unitOfWork.ManufuctresCompanyRepository.Delete(await unitOfWork.ManufuctresCompanyRepository.GetFirstOrDefault(x => x.KeyID == company.KeyID));
              
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    TempData["msg"] = Resource.lbl_operationSucceded;
                    return Redirect("/ManufctredCompany/Index/");
                }
                else
                {
                    return View(nameof(Index), company);
                }
            }
            catch (Exception ex)
            {
                //Write Exption To log File Here
                return Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? strSearch)
        {                
            if (string.IsNullOrEmpty(strSearch))
            {
                return View(await unitOfWork.ManufuctresCompanyRepository.GetAll(x => true));
            }
            else
            {
                var result =await unitOfWork.ManufuctresCompanyRepository.GetAll(x => (ProgramLanguage.Language == ProgramLanguage.Arabic) ? x.ArName.Contains(strSearch.ToLower()) : x.EnName.Contains(strSearch.ToLower()));
                return View(result);
            }
        }

        public IActionResult SetLanguage(string? lang)
        {
            if (lang != null)
            {
                Response.Cookies.Delete("lang");
                Response.Cookies.Append("lang", lang, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    HttpOnly = false, 
                });
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
