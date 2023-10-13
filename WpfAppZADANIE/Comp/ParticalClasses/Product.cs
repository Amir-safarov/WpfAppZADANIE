using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppZADANIE.Comp
{
    public partial class Product
    {
        public string GetRelevancePrice
        {
            get
            {
                if (Discount != 0)
                    return $"{Cost - (Cost * ((decimal)Discount/100))}P";
                else
                    return $"{Cost}P";
            }
        }
        
        public string GetOldPrice
        {
            get
            {
                if (Discount != 0)
                    return $"";
                else
                    return $"{Cost}P";
            }
        }
        public string GetDescription
        {
            get
            {
                if (Description != null)
                    return $"Название:{Title}\nОписание:{Description}";
                else return $"Название:{Title}\nОписание: Отсутствует";
            }
        }
        
        
    }
}
