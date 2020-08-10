using System;
using System.Collections.ObjectModel;

namespace BurgersUIApp.ViewModels
{
    public class MenuDetailsViewModel
    {
        public ObservableCollection<Burgers> burgers { get; set; }

        public MenuDetailsViewModel()
        {

            burgers = new ObservableCollection<Burgers>
            {
                new Burgers
                {
                     Picture = "https://www.espiamos.com/7909-home_default/botella-de-agua-espia-full-hd-con-deteccion-de-movimiento.jpg",
                     Name = "Burger and Pizza Hub",
                     Description = "Burger - Pizza - Breakfast",
                     Rating=" 4.8",
                     RatingDetail=" (121 raitings)",
                     HomeSelected= "CompleteHeart"
                },
                new Burgers
                {
                     Picture = "MainBurger",
                     Name = "Burger and Pizza Hub",
                     Description = "Burger - Pizza - Breakfast",
                     Rating=" 4.8",
                     RatingDetail=" (121 raitings)",
                     HomeSelected= "EmptyHeart"
                },
                new Burgers
                {
                     Picture = "MainBurger",
                     Name = "Burger and Pizza Hub",
                     Description = "Burger - Pizza - Breakfast",
                     Rating=" 4.8",
                     RatingDetail=" (121 raitings)",
                     HomeSelected= "CompleteHeart"
                },
                new Burgers
                {
                     Picture = "MainBurger",
                     Name = "Burger and Pizza Hub",
                     Description = "Burger - Pizza - Breakfast",
                     Rating=" 4.8",
                     RatingDetail=" (121 raitings)",
                     HomeSelected= "EmptyHeart"
                }
            };
        }
    }

    public class Burgers
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string RatingDetail { get; set; }
        public string HomeSelected { get; set; }
    }
}
