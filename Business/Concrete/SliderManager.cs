using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Migrations;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderService


    {
        ISliderDal sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            this.sliderDal = sliderDal;
        }
        public void SliderAdd(Slider slider)
        {
           sliderDal.Insert(slider);
        }

        

        public Slider SliderGetById(int id)
        {
            return sliderDal.Get( x=>x.SliderId==id);
        }

        public List<Slider> SliderList()
        {
            return sliderDal.Listing();
        }

        public void SliderRemove(Slider slider)
        {
            sliderDal.Delete(slider);
        }

        

        public void SliderUpdate(Slider slider)
        {
            sliderDal.Update(slider);
        }

       

        Entities.Concrete.Slider ISliderService.SliderGetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Entities.Concrete.Slider> ISliderService.SliderList()
        {
            throw new NotImplementedException();
        }
    }
}
