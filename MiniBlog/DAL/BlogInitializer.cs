using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MiniBlog.Models;

namespace MiniBlog.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var pages = new List<Page>
            {
            new Page{Title="Dragon Claws", Date=DateTime.Now, Author="jonathan.torres@gmail.com", Content="They are so, so, so, so OP."},
            new Page{Title="Elder Maul", Date=DateTime.Now, Author="jonathan.torres@gmail.com", Content="Buff plz lol."},
            new Page{Title="Wilderness Rejuvenation", Date=DateTime.Now, Author="jonathan.torres@gmail.com", Content="Jamflex pls"},
            new Page{Title="Revamp BH", Date=DateTime.Now, Author="jonathan.torres@gmail.com", Content="Pls revamp BH or i quit kty"},
            new Page{Title="Redwoods", Date=DateTime.Now, Author="jonathan.torres@gmail.com", Content="they are good"},
            };

            pages.ForEach(s => context.Pages.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
            new Category{Name="Skilling"},
            new Category{Name="PvM"},
            new Category{Name="PvP"},
            new Category{Name="General"},
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var pageCategories = new List<PageCategory>
            {
            new PageCategory{PageID=1, CategoryID=3},
            new PageCategory{PageID=2, CategoryID=3},
            new PageCategory{PageID=3, CategoryID=4},
            new PageCategory{PageID=4, CategoryID=4},
            new PageCategory{PageID=5, CategoryID=1},
            };

            pageCategories.ForEach(s => context.PageCategories.Add(s));
            context.SaveChanges(); 
        }
    }
}