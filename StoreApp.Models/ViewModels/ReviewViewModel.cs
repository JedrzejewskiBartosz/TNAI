using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class ReviewViewModel
    {
        public ReviewModel Review { get; set; }

        public ReviewViewModel(int productId)
        {
            Review = new ReviewModel();
            Review.ProductId = productId;
        }

    }
}
