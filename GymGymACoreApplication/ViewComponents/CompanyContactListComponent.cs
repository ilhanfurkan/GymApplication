using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.ViewComponents
{
	public class CompanyContactListComponent : ViewComponent
	{
		CompanyContactManager ccm = new CompanyContactManager(new EfCompanyContactRepository());

		public IViewComponentResult Invoke()
		{
			var CCList = ccm.CompanyContactList();
			return View(CCList);
		}
	}
}
