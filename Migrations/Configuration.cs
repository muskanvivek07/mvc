namespace TruYumMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TruYumMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TruYumMVC.Models.TruYumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TruYumMVC.Models.TruYumContext context)
        {
            var category = new List<Category>
            {
                new Category{Id=1,Name="Main Course"},
                new Category{Id=2,Name="Staters"},
                new Category{Id=3,Name="Snack"}
            };
            category.ForEach(ns => context.Categories.AddOrUpdate(x => x.Id, ns));
            category.ForEach(ns => context.Categories.AddOrUpdate(x => x.Name, ns));
        }
    }
}
