using ManufctredCompanyPortofolio.BLL.IUnitOfWork;
using ManufuctredCompanyPortofolio.DAL;
using ManufuctredCompanyPortofolio.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManufuctredCompanyPortofolio.PL.Controllers
{
	public class ManfCompanyBranchResPersonController : MyController
	{
        private readonly IUnitOfWork unitOfWork;

        //private readonly IProgramLanguage language;
        public ManfCompanyBranchResPersonController(IProgramLanguage language,IUnitOfWork unitOfWork):base(language)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? companyId , int? CompanyBranchId)
		{
            IEnumerable<ManufcturingCompany> companies;
            if(CompanyBranchId != null)
            {
                var companyBranchesResPerson = await unitOfWork.CompanyBranchesResponsiblePersonRepository.GetAll(x => x.ManuductringCompanyBranchId == CompanyBranchId);
                if (companyBranchesResPerson.Count() == 0)
                {
                    ViewData["companyBranchesResPerson"] = new List<CompanyBranchesResponsiblePerson>();
                    (ViewData["companyBranchesResPerson"] as List<CompanyBranchesResponsiblePerson>).Add(new CompanyBranchesResponsiblePerson());
                }
                else
                ViewData["companyBranchesResPerson"] = companyBranchesResPerson;
            }
            else
            {
                ViewData["companyBranchesResPerson"] = new List<CompanyBranchesResponsiblePerson>();
                (ViewData["companyBranchesResPerson"] as List<CompanyBranchesResponsiblePerson>).Add(new CompanyBranchesResponsiblePerson());
            }
            if (companyId != null)
            {                
                companies =await unitOfWork.ManufuctresCompanyRepository.GetAll(x => true);

                ViewData["CompanyBranches"] = await unitOfWork.ManuductringCompanyBranchRepository.GetAll(x => x.ManufcturingCompanyId == companyId);
            }
            else
            {
                companies = await unitOfWork.ManufuctresCompanyRepository.GetAll(x => true);
            }
			return View(companies);
		}
	}
}
