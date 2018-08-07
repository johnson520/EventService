using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EventService.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace EventService.Data
{
    public static class ImagesBlob
    {
        private const string BlobContainerName = "customimages";

        private static readonly CloudStorageAccount azureStorage = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

        private static readonly Regex rxDataUri = new Regex(@"^data:(?<mime>image/(?<ext>[a-z]+));base64,", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string SaveCustomImage(QOption cid)
        {
            var dataUri = cid.url;
            var match = rxDataUri.Match(dataUri);

            if (!match.Success)
                throw new Exception("Invalid data URI");

            var mime = match.Groups["mime"].Value;
            var ext = match.Groups["ext"].Value;
            var bytes = Convert.FromBase64String(dataUri.Substring(match.Length));

            var blob = GetBlobContainer().GetBlockBlobReference($"{cid.key}.{ext}");
            blob.Properties.ContentType = mime;
            blob.UploadFromByteArray(bytes, 0, bytes.Length);

            blob.Metadata["name"] = cid.value;
            blob.SetMetadata();

            return blob.Uri.AbsoluteUri;
        }

        public static List<QOption> GetCustomImages()
        {
            var container = GetBlobContainer();
            return container.ListBlobs().Select(item => GetQOption(container, item.Uri.AbsoluteUri)).OrderBy(o => o.sortKey).ToList();
        }

        public static bool DeleteCustomImage(string filename)
        {
            var container = GetBlobContainer();
            var blob = container.GetBlobReference(filename);
            try
            {
                blob.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static QOption GetQOption(CloudBlobContainer container, string url)
        {
            var blob = container.GetBlobReference(Path.GetFileName(url));
            blob.FetchAttributes();

            var key = Path.GetFileNameWithoutExtension(url);
            var name = blob.Metadata.ContainsKey("name") ? blob.Metadata["name"] : key;
            var sortKey = blob.Properties.LastModified?.ToString("s");

            return new QOption
            {
                key = key,
                value = name,
                url = url,
                sortKey = sortKey
            };
        }

        private static CloudBlobContainer GetBlobContainer()
        {
            var container = azureStorage.CreateCloudBlobClient().GetContainerReference(BlobContainerName);
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);
            return container;
        }
    }
}
