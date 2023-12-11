﻿namespace Presentation.HousesDialogWindow
{
    using DAL.Data;
    using FlowMeterTeamProject.Presentation;
    using Presentation.Pages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for PropertiesHouse.xaml
    /// </summary>
    public partial class PropertiesHouse : Window
    {

        public int houseID;

        private IDataGridUpdater _dataGridUpdater;
        public PropertiesHouse(int houseid, IDataGridUpdater dataGridUpdater)
        {
            this.InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            houseID = houseid;
            _dataGridUpdater = dataGridUpdater;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var editData = new EditDataHouse();
            editData.ShowDialog();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var houseToDelete = context.houses.FirstOrDefault(c => c.HouseId == houseID);


                    var consumerToDelete = context.consumers.FirstOrDefault(a => a.HouseId == houseID);

                    var serviceToDelete = context.services.FirstOrDefault(b => b.HouseId == houseID);
                    


                    if (houseToDelete != null)
                    {

                        context.houses.Remove(houseToDelete);
                    }

                    if (consumerToDelete != null)
                    {

                        context.consumers.Remove(consumerToDelete);
                    }

                    if(serviceToDelete != null)
                    {

                        context.services.Remove(serviceToDelete);
                    }


                    context.SaveChanges();
                   this._dataGridUpdater?.UpdateDataGrid();
                    this.Close();
                    MessageBox.Show($"Житловий будинок : {houseToDelete.HouseAddress} видалено!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні даних: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
