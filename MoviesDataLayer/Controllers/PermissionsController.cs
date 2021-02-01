using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesDataLayer.UWP.Controllers
{
   public  class PermissionsController
    {
        MoviesContext context;
        public PermissionsController()
        {
            context = new MoviesContext();
        }
        public void Init()
        {
            List<Permissions> permissions = new List<Permissions>()
            {
                new Permissions{Role="ADMIN"},
                new Permissions{Role="USER"}
            };
            List<Categories> categories = new List<Categories>()
            {
                new Categories(){Name="Action"},
                new Categories(){Name="Drama"},
                new Categories(){Name="Comedy"},
                new Categories(){Name="Tv Show"},
                new Categories(){Name="Carton"},
                new Categories(){Name="Horror"},
                new Categories(){Name="Advanture"},
            };
            context.Permissions.AddRange(permissions);
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
      
    }

}
