using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class CompanyContactController : Controller
    {
        CompanyContactManager cc = new CompanyContactManager(new EfCompanyContactRepository());

		public IActionResult Index(int page = 1, string searchText = "")
		{

			int pageSize = 5;
			Context c = new Context();
			Pager pager;
			List<CompanyContact> data;
			var itemCounts = 0;
			if (searchText != "" && searchText != null)
			{
				data = c.CompanyContacts.Where(usr => usr.CompanyContactDetail.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


				itemCounts = c.CompanyContacts.Where(usr => usr.CompanyContactDetail.Contains(searchText)).ToList().Count;
			}
			else
			{
				data = c.CompanyContacts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
				itemCounts = c.CompanyContacts.ToList().Count;
			}
			pager = new Pager(pageSize, itemCounts, page);

			ViewBag.pager = pager;
			ViewBag.actionName = "Index";
			ViewBag.contrName = "ChoseUs";
			ViewBag.searchText = searchText;
			return View(data);

		}
		public IActionResult Delete(int id)
		{
			CompanyContact companyContact = cc.CompanyContactGetById(id);
			cc.CompanyContactRemove(companyContact);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(CompanyContact companyContact)
		{
			CompanyContactValidator companyContactValidator = new CompanyContactValidator();
			var result = companyContactValidator.Validate(companyContact);
			if (result.IsValid)
			{
				cc.CompanyContactAdd(companyContact);
				return RedirectToAction("Index");

			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}

		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			CompanyContact companyContact = cc.CompanyContactGetById(id);
			return View(companyContact);

		}
		[HttpPost]
		public IActionResult Update(CompanyContact companyContact)
		{
			CompanyContactValidator companyContactValidator = new CompanyContactValidator();
			var result = companyContactValidator.Validate(companyContact);
			if (result.IsValid)
			{
				cc.CompanyContactUpdate(companyContact);
				return RedirectToAction("Index");

			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(companyContact);
			}
		}


	}
}
