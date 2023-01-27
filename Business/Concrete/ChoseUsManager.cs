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
	public class ChoseUsManager : IChoseUsService
	{
        IChoseUsDal choseUsDal;
        public ChoseUsManager(IChoseUsDal choseUsDal)
        {
            this.choseUsDal = choseUsDal;
        }

        public void ChoseUsAdd(ChoseUs choseUs)
		{
            choseUsDal.Insert(choseUs);
        }

		public ChoseUs ChoseUsGetById(int id)
		{
            return choseUsDal.Get(x => x.ChoseUsId == id);
		}

		public ChoseUs ChoseUsGetByName(string Name)
		{
            return choseUsDal.Get(x => x.ReasonTitle == Name);
        }

        public List<ChoseUs> ChoseUsList()
		{
            return choseUsDal.Listing();
        }

		public void ChoseUsRemove(ChoseUs choseUs)
		{
			choseUsDal.Delete(choseUs);

        }

		public void ChoseUsUpdate(ChoseUs choseUs)
		{
            choseUsDal.Update(choseUs);

        }
	}
}
