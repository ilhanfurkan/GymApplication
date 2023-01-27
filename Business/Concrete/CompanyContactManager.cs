using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyContactManager : ICompanyContactService
    {
        ICompanyContactDal companyContactDal;
        public CompanyContactManager(ICompanyContactDal companyContactDal)
        {
            this.companyContactDal = companyContactDal;
        }
        public void CompanyContactAdd(CompanyContact companyContact)
        {
            companyContactDal.Insert(companyContact);
        }

        public CompanyContact CompanyContactGetById(int id)
        {
            return companyContactDal.Get(x => x.CompanyContactId== id); 
        }

        public List<CompanyContact> CompanyContactList()
        {
            return companyContactDal.Listing();
        }

        public void CompanyContactRemove(CompanyContact companyContact)
        {
            companyContactDal.Delete(companyContact);
        }

        public void CompanyContactUpdate(CompanyContact companyContact)
        {
            companyContactDal.Update(companyContact);
        }
    }
}
