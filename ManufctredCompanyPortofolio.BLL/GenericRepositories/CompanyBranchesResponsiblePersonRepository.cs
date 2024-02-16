using ManufuctredCompanyPortofolio.BL.GenericRepositories;
using ManufuctredCompanyPortofolio.DAL.Contexts;
using ManufuctredCompanyPortofolio.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufctredCompanyPortofolio.BLL.GenericRepositories
{
	public class CompanyBranchesResponsiblePersonRepository : Repository<CompanyBranchesResponsiblePerson>
	{
        public CompanyBranchesResponsiblePersonRepository(AppDbContext context):base(context)
        {
               
        }
    }
}
