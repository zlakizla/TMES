using DAL;
using TMES.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Utils;

namespace TMES
{
    public static class Global
    {
        public static UserContext Context;
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow _mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserContext>());  
          
            Application.Current.Resources.MergedDictionaries.Clear();
            AddLib(@"/MVVMMappingResources.xaml");

        }

        static void AddLib(string UriString)
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(UriString, UriKind.RelativeOrAbsolute)
            });
        }
    }
}
