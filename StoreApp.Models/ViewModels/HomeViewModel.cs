using StoreApp.Models.Models;
using StoreApp.Models.ViewModels.IViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class HomeViewModel : IStoreFrontViewModel
    {
        public IEnumerable<CategoryModel> CategoryList { get; set; }
        public List<ProductModel> ProductModels { get; set; }
    }
}
