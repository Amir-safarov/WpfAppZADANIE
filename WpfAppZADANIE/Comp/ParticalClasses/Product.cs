using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppZADANIE.Comp
{
    public partial class Product
    {
        public string GetRelevancePrice
        {
            get
            {
                if (Discount != 0)
                    return $"{Cost - (Cost * ((decimal)Discount/100)):0}P";
                else
                    return $"{Cost:0}P";
            }
        }
        
        public string GetOldPrice
        {
            get
            {
                if (Discount == 0)
                    return $"";
                else
                    return $"{Cost:0}P";
            }
        }
        public string GetSale
        {
            get
            {
                if (Discount == 0)
                    return $"";
                else return $"-{Discount}%";
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
        public string GetAverageFeedback
        {
            get
            {
                double avg = 0;
                if (Feedback.Count() == 0)
                {
                    return "Оценок нет";
                }
                else
                {
                    foreach (var item in Feedback)
                        avg += item.Evaluation;

                    return $"{avg / Feedback.Count():f1}";
                }
            }
        }
        public string GetReviewesAmount
        {
            get
            {
                if (Feedback.Count() == 0)
                    return "Отзывов нет";
                else
                    return $"{Feedback.Count()} отзыв(ов)";
            }
        }



    }
}
