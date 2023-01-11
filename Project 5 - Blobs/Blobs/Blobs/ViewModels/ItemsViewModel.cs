using Azure.Storage.Blobs.Models;
using Blobs.Dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.ViewModels
{
    internal class ItemsViewModel
    {
        public const string ForwardSlash = "/";
        private const string directory = "images";
        public ObservableCollection<BlobItem> Items { get; }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<BlobItem>();
            Refresh();
        }

        private void Refresh()
        {
            Items.Clear();
            Repository.Container.GetBlobs().ToList().ForEach(item =>
            {
                if (item.Name.Contains(ForwardSlash))
                {
                    string directory = item.Name.Substring(0, item.Name.LastIndexOf(ForwardSlash));
                }
                if (!item.Name.Contains(ForwardSlash))
                {
                    Items.Add(item);
                }
                else if (item.Name.Contains($"{directory}{ForwardSlash}"))
                {
                    Items.Add(item);
                }
            });
            
        }

        public async Task UploadAsync(string path)
        {
            string filename = path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            filename = string.IsNullOrEmpty(directory?.Trim()) ? filename : $"{directory}{Path.DirectorySeparatorChar}{filename}";
            using (var fs = File.OpenRead(path))
            {
                await Repository.Container.GetBlobClient(filename).UploadAsync(fs, true);
            }
            Refresh();
        }

        public async Task DeleteAsync(BlobItem blobItem)
        {
            await Repository.Container.GetBlobClient(blobItem.Name).DeleteAsync();
            Refresh();

        }

        public async Task DownloadAsync(BlobItem blobItem, string filename)
        {
            using (var fs = File.OpenWrite(filename))
            {
                await Repository.Container.GetBlobClient(blobItem.Name).DownloadToAsync(fs);
            }
        }
    }
}
