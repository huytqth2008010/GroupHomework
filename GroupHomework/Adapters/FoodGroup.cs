using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupHomework.Adapters
{
    class FoodGroup
    {
        private readonly string baseURL = "http://foodgroup.herokuapp.com";
        // singleton pattern
        private static FoodGroup instance;

        private FoodGroup()
        {

        }
        public string ApiHome
        {
            get => String.Format(baseURL + "/api/today-special");
        }
        public static FoodGroup GetInstance()
        {
            if (instance == null)
            {
                instance = new FoodGroup();
            }
            return instance;
        }

        // api list categories
        public string ApiMenu
        {
            get => String.Format(baseURL + "/api/menu");
        }

        public string CategoryDetail(string id)
        {
            return String.Format(baseURL + "/api/category/" + id);
        }
    }
}
