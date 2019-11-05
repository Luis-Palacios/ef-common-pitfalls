using EFCommonPitFalls.DataAccess;
using EFCommonPitFalls.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCommonPitFalls
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertMenuCategories();

            using var db = new RestaurantContext();

            var menuCategory = new MenuCategory
            {
                // Asume this data come from the UI
                Active = true,
                DateCreated = DateTime.Today,
                ImageUrl = "/somepath/foo.png",
                Name = "Starters",
                Order = 1
            };

            db.MenuCategories.Add(menuCategory);
            db.SaveChanges();

            // Asume menuItems is data coming from the UI that
            // we mapa into our model objects
            foreach (var menuItem in menuItems)
            {
                db.MenuItem.Add(new MenuItem
                    {
                        Name = menuItem.Name,
                        Description = menuItem.Description
                    });
                db.SaveChanges();
            }

            //using var db = new RestaurantContext();
            var menuCategories = db.MenuCategories
                                    .Where(c => c.Active)
                                    .OrderBy(c => c.Order)
                                    .Select(c => new
                                    {
                                        c.Id,
                                        c.Name,
                                        MenuItems = c.MenuItems
                                                        .Select(i => new
                                                        {
                                                            i.Name,
                                                            i.Description
                                                        })
                                    })
                                    .ToList();

            foreach (var category in menuCategories)
            {
                Console.WriteLine($"Category: {category.Name}, Id: {category.Id}");
                int i = 1;
                foreach (var item in category.MenuItems)
                {
                    Console.WriteLine($"\t {i}.{item.Name}\n\t {item.Description}\n");
                    i++;
                }
            }

        }

        static void InsertMenuCategories()
        {
            using var db = new RestaurantContext();
            db.MenuCategories.AddRange(
                    new MenuCategory
                    {
                        Active = true,
                        DateCreated = DateTime.Today,
                        ImageUrl = "/somepath/foo.png",
                        Name = "Starters",
                        Order = 1,
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Name = "Shrimp Heaven",
                                Description = "Some ingridients here and some fancy text that makes you want this dish"
                            },
                            new MenuItem
                            {
                                Name = "Popcorn shrimp",
                                Description = "Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus."
                            },
                            new MenuItem
                            {
                                Name = "Shrimp Nachos",
                                Description = "Tortilla bathed with a mixture of Monterey cheeses, jack, mozzarella and cheddar, pico de gallo and fresh jalapenos and shrimp"
                            },
                            new MenuItem
                            {
                                Name = "Captain\'s fish and chips",
                                Description = "Fish fingers with our special breaded meat served in a bed of crispy fries and tartar sauce"
                            },
                        }
                    },
                    new MenuCategory
                    {
                        Active = true,
                        DateCreated = DateTime.Today,
                        ImageUrl = "/somepath/foo.png",
                        Name = "Shrimp heaven",
                        Order = 2,
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Name = "Coconut Shrimp",
                                Description = "The favorite of many! Served with orange marmalade with cajun and french fries"
                            },
                            new MenuItem
                            {
                                Name = "Net catch",
                                Description = "Our best peel\'n eat shrimp, steamed with beer, yellow corn and potatoes with our secret sauce"
                            },
                            new MenuItem
                            {
                                Name = "Christmas Shrimp",
                                Description = "The favorite of many! Served with orange marmalade with cajun and french fries"
                            },
                        }
                    },
                    new MenuCategory
                    {
                        Active = true,
                        DateCreated = DateTime.Today,
                        ImageUrl = "/somepath/foo.png",
                        Name = "Drinks",
                        Order = 3,
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Name = "National Beer",
                                Description = ""
                            },
                            new MenuItem
                            {
                                Name = "Heineken",
                                Description = ""
                            },
                        }
                    },
                    new MenuCategory
                    {
                        Active = true,
                        DateCreated = DateTime.Today,
                        ImageUrl = "/somepath/foo.png",
                        Name = "Desserts",
                        Order = 4
                    }
            );
            db.SaveChanges();
        }
    }
}
