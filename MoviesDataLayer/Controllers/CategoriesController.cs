using Microsoft.EntityFrameworkCore;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Controllers
{
   public class CategoriesController
    {
        private MoviesContext _db;

        public CategoriesController()
        {
            _db = new MoviesContext();
        }
        public async Task<List<Categories>> GetCategories()
        {

            var cateogries = await _db.Categories.ToListAsync();
          
            if (cateogries != null && cateogries.Count > 0)
            {
                
                return cateogries;
            }
            else
            {
                return null;
            }

        }
    }
}
