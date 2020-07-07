using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GoogleMaps.Entities
{
    class ListPlacesView
    {

        public ListPlacesView()
        {
            // constructors
        }

        public ObservableCollection<ListPlaces> ObtenerListPlaces()
        {
            ObservableCollection<ListPlaces> oMenuPrincipal = new ObservableCollection<ListPlaces>();

            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 1",
                Habilitado = true,
                idOpcion = 1,
                icon = "ic_bullbasaur.png"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 2",
                Habilitado = true,
                idOpcion = 2,
                icon = "ic_charmander.png"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 3",
                Habilitado = true,
                idOpcion = 3,
                icon = "ic_pikachu.png"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 4",
                Habilitado = true,
                idOpcion = 4,
                icon = "ic_snorlax.png"
            });
            oMenuPrincipal.Add(new ListPlaces
            {
                Opcion = "ListView Ejemplo 5",
                Habilitado = true,
                idOpcion = 5,
                icon = "ic_squirtle.png"
            });


            return oMenuPrincipal;
        }




        }
    }
