using Azure.Storage.Blobs.Models;
using Blobs.ViewModels;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blobs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string allowedExtensions = "Allowed Files|*.jpeg;*.png;*.gif;*.tif;*.svg";

        private readonly ItemsViewModel itemsViewModel;
        public MainWindow()
        {
            InitializeComponent();
            itemsViewModel = new ItemsViewModel();
            Init();
        }

        private void Init()
        {
            LbItems.ItemsSource = itemsViewModel.Items;
        }

        private void LbItems_SelectionChanged(object sender, SelectionChangedEventArgs e) => DataContext = LbItems.SelectedItem as BlobItem;

        private async void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = allowedExtensions;
            if (openFileDialog.ShowDialog() == true)
            {
                LblStates.Content = "Uploading...";
                await itemsViewModel.UploadAsync(openFileDialog.FileName);
                LblStates.Content = "Done!";

            }
            LbItems.ItemsSource = itemsViewModel.Items;
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbItems.SelectedItem is BlobItem blobItem))
            {
                return;
            }
            await itemsViewModel.DeleteAsync(blobItem);
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbItems.SelectedItem is BlobItem blobItem))
            {
                return;
            }
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = allowedExtensions,
                FileName = blobItem.Name.Contains(ItemsViewModel.ForwardSlash)
                ? blobItem.Name.Substring(blobItem.Name.LastIndexOf(ItemsViewModel.ForwardSlash) + 1)
                : blobItem.Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                await itemsViewModel.DownloadAsync(blobItem, saveFileDialog.FileName);
            }
        }

    }
}
