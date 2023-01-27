using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IChoseUsService
	{
        void ChoseUsAdd(ChoseUs choseUs);
        void ChoseUsRemove(ChoseUs choseUs);
        void ChoseUsUpdate(ChoseUs choseUs);
        List<ChoseUs> ChoseUsList();
        ChoseUs ChoseUsGetById(int id);
        ChoseUs ChoseUsGetByName(string Name);
    }
}
