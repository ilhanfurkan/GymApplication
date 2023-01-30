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
    public class FooterDetailManager : IFooterDetailService
    {
        IFooterDetailDal footerDetailDal;
        public FooterDetailManager(IFooterDetailDal footerDetailDal)
        {
            this.footerDetailDal = footerDetailDal;
        }

        public void FooterAdd(FooterDetail fDetail)
        {
           footerDetailDal.Insert(fDetail);
        }

        public FooterDetail FooterGetById(int id)
        {
            return footerDetailDal.Get(x=>x.FooterId == id);
        }

        public List<FooterDetail> FooterList()
        {
            return footerDetailDal.Listing();
        }

        public void FooterRemove(FooterDetail fDetail)
        {
            footerDetailDal.Delete(fDetail);
        }

        public void FooterUpdate(FooterDetail fDetail)
        {
            footerDetailDal.Update(fDetail);
        }
    }
}
