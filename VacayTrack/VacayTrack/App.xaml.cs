using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacayTrack
{
    public partial class App : Application
    {
        //для базы данных
        private static DB db;
        public static DB Db
        {
            get
            {
                if (db == null)
                    db = new DB("db.sqLite");
                return db;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
