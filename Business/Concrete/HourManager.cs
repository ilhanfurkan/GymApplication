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
    public class HourManager : IHourService
    {
        IHourDal hourDal;
        public HourManager(IHourDal hourDal)
        {
            this.hourDal = hourDal;
        }

        public void HourAdd(Hour hour)
        {
            hourDal.Insert(hour);
        }

        public Hour HourGetById(int id)
        {
            return hourDal.Get(x => x.HourId == id);
        }

        public List<Hour> HourList()
        {
            return hourDal.Listing();

        }

        public void HourRemove(Hour hour)
        {
            hourDal.Delete(hour);
        }

        public void HourUpdate(Hour hour)
        {
            hourDal.Update(hour);
        }
    }
}
