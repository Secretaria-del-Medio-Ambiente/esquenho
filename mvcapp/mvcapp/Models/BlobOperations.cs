using System;
using System.Web;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;


namespace mvcapp.Models
{

    /// <summary>
    /// Class to Store BLOB Info
    /// </summary>



    /// <summary>
    /// Class to Work with Blob
    /// </summary>
    public class BlobOperations
    {
        private static CloudBlobContainer profileBlobContainer;

        /// <summary>
        /// Initialize BLOB and Queue Here
        /// </summary>
        public BlobOperations()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["nteacgcesma"].ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get the blob container reference.
            profileBlobContainer = blobClient.GetContainerReference("profiles");
            //Create Blob Container if not exist
            profileBlobContainer.CreateIfNotExists();
        }


        /// <summary>
        /// Method to Upload the BLOB
        /// </summary>
        /// <param name="profileFile"></param>
        /// <returns></returns>
        public async Task<CloudBlockBlob> UploadBlob(HttpPostedFileBase profileFile)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFile.FileName);
            // GET a blob reference. 
            CloudBlockBlob profileBlob = profileBlobContainer.GetBlockBlobReference(blobName);
            // Uploading a local file and Create the blob.
            using (var fs = profileFile.InputStream)
            {
                await profileBlob.UploadFromStreamAsync(fs);
            }
            return profileBlob;
        }
        ///<param name="profileFileEdit"></param>
        public async Task<CloudBlockBlob> UploadBlobEdit(HttpPostedFileBase profileFileEdit)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileEdit.FileName);
            CloudBlockBlob profileBlobEdit = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileEdit.InputStream)
            {
                await profileBlobEdit.UploadFromStreamAsync(fs);
            }
            return profileBlobEdit;
        }
        ///<param name="profileFileConf"></param>
        public async Task<CloudBlockBlob> UploadBlobConf(HttpPostedFileBase profileFileConf)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileConf.FileName);
            CloudBlockBlob profileBlobConf = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileConf.InputStream)
            {
                await profileBlobConf.UploadFromStreamAsync(fs);
            }
            return profileBlobConf;
        }
        public async Task<CloudBlockBlob> UploadBlobExt(HttpPostedFileBase profileFileExt)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileExt.FileName);
            CloudBlockBlob profileBlobExt = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileExt.InputStream)
            {
                await profileBlobExt.UploadFromStreamAsync(fs);
            }
            return profileBlobExt;
        }
        public async Task<CloudBlockBlob> UploadBlobAdmin(HttpPostedFileBase profileFileAdmin)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileAdmin.FileName);
            CloudBlockBlob profileBlobAdmin = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileAdmin.InputStream)
            {
                await profileBlobAdmin.UploadFromStreamAsync(fs);
            }
            return profileBlobAdmin;
        }
        public async Task<CloudBlockBlob> UploadBlobSudo(HttpPostedFileBase profileFileSudo)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileSudo.FileName);
            CloudBlockBlob profileBlobSudo = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileSudo.InputStream)
            {
                await profileBlobSudo.UploadFromStreamAsync(fs);
            }
            return profileBlobSudo;
        }
        public async Task<CloudBlockBlob> UploadBlobUser(HttpPostedFileBase profileFileUser)
        {
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(profileFileUser.FileName);
            CloudBlockBlob profileBlobUser = profileBlobContainer.GetBlockBlobReference(blobName);
            using (var fs = profileFileUser.InputStream)
            {
                await profileBlobUser.UploadFromStreamAsync(fs);
            }
            return profileBlobUser;
        }
    }
}