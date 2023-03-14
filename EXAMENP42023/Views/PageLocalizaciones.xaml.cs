using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EXAMENP42023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLocalizaciones : ContentPage
    {
        Location location = null;
        public PageLocalizaciones()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {

            try
            {
                location = await Geolocation.GetLocationAsync();

                if (location != null &&
                    !String.IsNullOrEmpty(DescripcionCorta.Text) &&
                    !String.IsNullOrEmpty(DescripcionLarga.Text))
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);

                    var local = new Models.Localizacion
                    {
                        latitud = location.Latitude,
                        longitud = location.Longitude,
                        descripcion_larga = DescripcionLarga.Text,
                        descripcion_corta = DescripcionCorta.Text,
                    };

                    if (await App.Database.SaveGeo(local) > 0)
                    {
                        await DisplayAlert("AVISO", "Localizacion Guardada", "OK");
                    }

                }
                else
                {
                    if (location == null)
                    {
                        await DisplayAlert("ERROR", "El GPS no esta activo", "OK");
                    }
                    else if (String.IsNullOrEmpty(DescripcionLarga.Text))
                    {
                        await DisplayAlert("ERROR", "Sin descripcion corta", "OK");
                    }
                    else if (String.IsNullOrEmpty(DescripcionCorta.Text))
                    {
                        await DisplayAlert("ERROR", "Sin descripcion larga", "OK");
                    }

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "El GPS no esta activo", "OK");
            }
        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            var page = new Views.PageListGeo();
            await Navigation.PushAsync(page);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}