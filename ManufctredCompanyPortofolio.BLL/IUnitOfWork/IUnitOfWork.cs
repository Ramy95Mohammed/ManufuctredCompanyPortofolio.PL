using ManufctredCompanyPortofolio.BLL.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufctredCompanyPortofolio.BLL.IUnitOfWork
{
    public interface IUnitOfWork
    {

      public  ManufuctresCompanyRepository ManufuctresCompanyRepository { get; set; }
      public  ManuductringCompanyBranchRepository ManuductringCompanyBranchRepository { get; set; }
       public ManufcturingCompanyPhoneRepository ManufcturingCompanyPhoneRepository { get; set; }
        public CompanyBranchesResponsiblePersonRepository CompanyBranchesResponsiblePersonRepository { get; set; }

		#region EmployeeDeaprtment
		public EmployeeRepository EmployeeRepository { get; set; }
        public DepartmentRepository DepartmentRepository { get; set; }

        #endregion
        public Task<int> SaveChangesAsync();
    }
}
