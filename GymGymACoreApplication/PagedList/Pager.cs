

using DataAccess.Concrete;

namespace GymGymACoreApplication.PagedList
{
    public class Pager
    {
        //Pagerda görünen son sayfa sayisi
        public int EndPage { get; set; }

        //Pagerda göünen ilk sayfa sayisi
        public int StartPage { get; set; }

        //Toplam sayfa sayısı
        public int TotalPage { get; set; }

        //sayfa da gösterilecek kayıt sayısı (pageSize)
        public int ViewedRecords { get; set; }

        //Databasede ki toplam kayıt sayısı (itemCounts)
        public int TotalRecords { get; set; }

        //Tıklanan sayfa  (page)
        public int ActivePage { get; set; }

        public Pager(int pageSize, int itemCounts, int page)
        {
            this.ActivePage = page;
            this.ViewedRecords = pageSize;
            this.TotalRecords = itemCounts;


            TotalPage =(int)Math.Ceiling((decimal)TotalRecords / (decimal)ViewedRecords);

            StartPage = ActivePage - 5;
            EndPage = ActivePage + 4;

            if (StartPage<1)
            {
                EndPage = EndPage - (StartPage - 1);
                StartPage=1;
            }
            if (EndPage>TotalPage)
            {
                EndPage = TotalPage;
                if (EndPage>10)
                {
                    StartPage = EndPage - 9;
                }
            }
            
            
        }
        
    }

}
