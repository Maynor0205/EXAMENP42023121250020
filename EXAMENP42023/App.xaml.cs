using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENP42023
{
    public partial class App : Application
    {
        static Controllers.LocalizacionController database;

        public static Controllers.LocalizacionController Database
        {
            get
            {
                if (database == null)
                {
                    var pathdatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Progr4.db3";
                    var Fullpath = Path.Combine(pathdatabase, dbname);
                    database = new Controllers.LocalizacionController(Fullpath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.PageLocalizaciones());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
