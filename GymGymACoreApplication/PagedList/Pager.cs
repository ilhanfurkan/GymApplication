

using DataAccess.Concrete;

namespace GymGymACoreApplication.PagedList
{
    public class Pager
    {
        //Pagerda görünen son sayfa sayisi
        public int bitisSayfasi { get; set; }

        //Pagerda göünen ilk sayfa sayisi
        public int baslangicSayfasi { get; set; }

        //Toplam sayfa sayısı
        public int sayfaSayisi { get; set; }

        //sayfa da gösterilecek kayıt sayısı
        public int goruntulenenKayitSayisi { get; set; }

        //Databasede ki toplam kayıt sayısı
        public int toplamKayitSayisi { get; set; }

        //Tıklanan sayfa
        public int aktifSayfa { get; set; }

        public Pager(int pageSize, int itemCounts, int page)
        {
            this.aktifSayfa = page;
            this.goruntulenenKayitSayisi = pageSize;
            this.toplamKayitSayisi=itemCounts;


            sayfaSayisi =(int)Math.Ceiling((decimal)toplamKayitSayisi / (decimal)goruntulenenKayitSayisi);

            baslangicSayfasi = aktifSayfa - 5;
            bitisSayfasi = aktifSayfa + 4;

            if (baslangicSayfasi<1)
            {
                bitisSayfasi = bitisSayfasi - (baslangicSayfasi - 1);
                baslangicSayfasi=1;
            }
            if (bitisSayfasi>sayfaSayisi)
            {
                bitisSayfasi = sayfaSayisi;
                if (bitisSayfasi>10)
                {
                    baslangicSayfasi = bitisSayfasi - 9;
                }
            }
            
            
        }
        
    }

}
