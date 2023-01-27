using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyContactService
    {
        void CompanyContactAdd(CompanyContact companyContact);
        void CompanyContactRemove(CompanyContact companyContact);
        void CompanyContactUpdate(CompanyContact companyContact);
        List<CompanyContact> CompanyContactList();
        CompanyContact CompanyContactGetById(int id);
    }
}
