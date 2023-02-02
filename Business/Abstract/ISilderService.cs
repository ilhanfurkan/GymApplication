using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderService
    {
        void SliderAdd(Slider slider);
        void SliderRemove(Slider slider);
        void SliderUpdate(Slider slider);
        List<Slider> SliderList();
        Slider SliderGetById(int id);
    }
}
