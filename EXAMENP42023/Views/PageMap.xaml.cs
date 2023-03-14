using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EXAMENP42023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var seleccion = (Models.Localizacion)this.BindingContext;

            var centromap = new Xamarin.Forms.Maps.Position(seleccion.latitud, seleccion.longitud);
            mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(centromap,1,1));

            Pin Ubicacion = new Pin();
            Ubicacion.Label = seleccion.descripcion_corta;
            Ubicacion.Address = seleccion.descripcion_larga;
            Ubicacion.Position = new Xamarin.Forms.Maps.Position(seleccion.latitud, seleccion.longitud);
            mapa.Pins.Add(Ubicacion);
        }
    }
}