using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.Storage
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string _connectionString;
        public AzureStorageService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureStorageConnection");
        }
        public Task DeleteFile(string fileRoute, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFile(byte[] content, string fileName, string containerName)
        {
            var account = CloudStorageAccount.Parse(_connectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);

            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var blob = container.GetBlockBlobReference(fileName);

            if (!await blob.ExistsAsync())
            {
                await blob.UploadFromByteArrayAsync(content, 0, content.Length);
                blob.Properties.ContentType = "image/png";

                await blob.SetPropertiesAsync();
            }

            return blob.Uri.ToString();
        }
    }
}
