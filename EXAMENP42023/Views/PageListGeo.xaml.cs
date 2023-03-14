using EXAMENP42023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENP42023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListGeo : ContentPage
    {
        private Models.Localizacion seleccion;
 

        public PageListGeo()
        {
            InitializeComponent();
        }

        private void listlocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verifica si la selección es del tipo correcto.
            if (e.CurrentSelection[0] is Models.Localizacion seleccion)
            {
                // Obtiene la ubicación seleccionada.
                this.seleccion = seleccion;

                // Muestra los botones de eliminar y actualizar.
                Btneliminar.IsVisible = true;
                Btnactualizar.IsVisible = true;
                Btnvermapa.IsVisible = true;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listlocal.ItemsSource = await App.Database.GetListLocalizaciones();
        }

        private async void Btneliminar_Clicked(object sender, EventArgs e)
        {
            // Elimina la ubicación seleccionada de la base de datos.
            await App.Database.DeleteLocalizaciones(seleccion);

            // Actualiza la lista de ubicaciones en el CollectionView.
            listlocal.ItemsSource = await App.Database.GetListLocalizaciones();

            // Oculta los botones de eliminar y actualizar.
            Btneliminar.IsVisible = false;
            Btnactualizar.IsVisible = false;
            Btnvermapa.IsVisible = false;
        }

        private async void Btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (seleccion != null)
            {

                await App.Database.SaveGeo(seleccion);

                await Navigation.PopAsync();

                
                await App.Database.DeleteLocalizaciones(seleccion);

                
                listlocal.ItemsSource = await App.Database.GetListLocalizaciones();

            }
        }
        private void Btnvermapa_Clicked(object sender, EventArgs e)
        {
            var page = new Views.PageMap();
            page.BindingContext = seleccion;
            Navigation.PushAsync(page);
        }
    }

}