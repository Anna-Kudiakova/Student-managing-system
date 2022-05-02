using System;
using System.Windows;
using System.Windows.Controls;
using CSharp.Lab04.Models;
using CSharp.Lab04.Tools.DataStorage;
using CSharp.Lab04.ViewModels;

namespace CSharp.Lab04.Tools.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentPerson { get; set; }
        internal static Person EditPerson { get; set; }
        internal static DataGrid PersonDataGrid { get; set; }
        internal static EditPersonViewModel EditPersonViewModel { get; set; }
        internal static MainScreenViewModel TablePersonViewModel { get; set; }

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("Application is shut down");
            Environment.Exit(1);
        }

    }
}
