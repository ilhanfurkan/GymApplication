using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFooterDetailService
    {
        void FooterAdd(FooterDetail fDetail);
        void FooterRemove(FooterDetail fDetail);
        void FooterUpdate(FooterDetail fDetail);
        List<FooterDetail> FooterList();
        FooterDetail FooterGetById(int id);
    }
}
