using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHourService
    {
        void HourAdd(Hour hour);
        void HourRemove(Hour hour);
        void HourUpdate(Hour hour);
        List<Hour> HourList();
        Hour HourGetById(int id);
    }
}
