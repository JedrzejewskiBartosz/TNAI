using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels.IViewModel
{
    public interface IStoreFrontViewModel
    {
        public IEnumerable<CategoryModel> CategoryList { get; set; }
    }
}
