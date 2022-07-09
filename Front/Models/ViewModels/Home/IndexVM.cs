using System.Collections.Generic;

namespace Front.Models.ViewModels.Home
{
    public class IndexVM
    {
        public List<CityCard> CityCards { get; set; }


    }


    public class CityCard
    {
        public string CityName { get; set; }
        public int Price { get; set; }

        public string ImgUrl { get; set; }
        //public string Link { get; set; }

    }


}
