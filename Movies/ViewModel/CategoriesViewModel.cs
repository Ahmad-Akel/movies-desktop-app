using MoviesDataLayer.UWP.Controllers;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.ViewModel
{
    public class CategoriesViewModel
    {
        CategoriesController categoriesController = new CategoriesController();
        public List<Categories> GetCategories()
        {
          return  categoriesController.GetCategories().Result;
        }

    }
}
