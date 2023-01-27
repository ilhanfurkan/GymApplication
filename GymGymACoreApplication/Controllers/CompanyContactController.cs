using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class CompanyContactController : Controller
    {
        CompanyContactManager cc = new CompanyContactManager(new EfCompanyContactRepository());


      
        
    }
}
