using ManufctredCompanyPortofolio.BLL.GenericRepositories;
using ManufuctredCompanyPortofolio.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufctredCompanyPortofolio.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }



        public async Task<int> SaveChangesAsync()
        {
            int GetSaveChengesCount =await context.SaveChangesAsync();

            if (GetSaveChengesCount > 0)
            {
                return GetSaveChengesCount;
            }
            else return 0;
        }

        #region priavteFields
        private ManufuctresCompanyRepository _manufuctresCompanyRepository;
        private ManuductringCompanyBranchRepository _manuductringCompanyBranchRepository;
        private ManufcturingCompanyPhoneRepository _manufcturingCompanyPhoneRepository;
        private CompanyBranchesResponsiblePersonRepository _companyBranchesResponsiblePersonRepository;
		#region EmplloyeeDepartment
		private EmployeeRepository _employeeRepository;
        private DepartmentRepository _departmentRepository;
        #endregion
        #endregion


        #region incapsulateFields_Emplementation


        public ManufuctresCompanyRepository ManufuctresCompanyRepository
        { get
            {
                return _manufuctresCompanyRepository = new ManufuctresCompanyRepository(context);
            }
            set
            {
                _manufuctresCompanyRepository = value;
            }
        }
        
        public ManuductringCompanyBranchRepository ManuductringCompanyBranchRepository
        { get
            {
                return _manuductringCompanyBranchRepository = new ManuductringCompanyBranchRepository(context);
            }
            set
            {
                _manuductringCompanyBranchRepository = value;
            }
        } 
        public ManufcturingCompanyPhoneRepository ManufcturingCompanyPhoneRepository
        { get
            {
                return _manufcturingCompanyPhoneRepository = new ManufcturingCompanyPhoneRepository(context);
            }
            set
            {
                _manufcturingCompanyPhoneRepository = value;
            }
        }
        public CompanyBranchesResponsiblePersonRepository CompanyBranchesResponsiblePersonRepository
		{ get
            {
                return _companyBranchesResponsiblePersonRepository = new CompanyBranchesResponsiblePersonRepository(context);
            }
            set
            {
				_companyBranchesResponsiblePersonRepository = value;
            }
        }
        

        #region EmployeeDepartment
        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository = new EmployeeRepository(context);
            }
            set
            {
                _employeeRepository = value;
            }
        }
        public DepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository = new DepartmentRepository(context);
            }
            set
            {
                _departmentRepository = value;
            }
        }
        #endregion

        #endregion
    }
}
