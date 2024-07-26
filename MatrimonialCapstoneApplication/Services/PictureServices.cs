using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.DTOs.RequestDTOs;

namespace MatrimonialCapstoneApplication.Services
{
    public class PictureServices : BaseServices<Picture>, IPictureServices
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "kavinimages";
        public PictureServices(IRepository<int, Picture> repo, IConfiguration configuration) : base(repo)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<IEnumerable<string>> UploadImage(ImageRequestDto imageRequestDto)
        {
            var imageUris = new List<string>();
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            foreach (var file in imageRequestDto.formfiles)
            {
                var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
                }

                imageUris.Add(blobClient.Uri.ToString());
            }

            return imageUris;
        }
    }
}
