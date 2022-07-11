using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCModels.MyEnum
{
    public enum City
    {
        台北 = 1,
        桃園 = 2,
        新竹 = 3,
        苗栗 = 4,
        宜蘭 = 5,
    }

    public class a
    {
        //Dictionary<string, City> dict = new Dictionary<string, City>{

        //    { nameof(City.台北  ), City.台北 },
        //    { nameof(City.桃園  ), City.桃園 },
        //    { nameof(City.桃園  ), City.台北 },
        //    { nameof(City.桃園  ), City.台北 },


        //};

        public object B(string name)//Type t ,
        {


             return Enum.Parse( typeof(City), name );
                //Enum.Parse(t, name );
        }
    }
}
