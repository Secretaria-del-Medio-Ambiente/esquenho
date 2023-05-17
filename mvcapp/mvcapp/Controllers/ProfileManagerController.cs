using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using EntityStores;
using mvcapp.Models;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace mvcapp.Controllers
{

    public class ProfileManagerController : Controller
    {
        BlobOperations blobOperations;
        TableOperations tableOperations;


        public ProfileManagerController()
        {
            blobOperations = new BlobOperations();
            tableOperations = new TableOperations(); 
        }
        // GET: ProfileManager
        public ActionResult Index()
        {
            var profiles = tableOperations.GetEntities(User.Identity.Name);
            return View(profiles);
        }

        public ActionResult Create()
        {
            var Profile = new ProfileEntity();
            Profile.ProfileId = new Random().Next(); //Generate the Profile Id Randomly
            Profile.Email = User.Identity.Name; // The Login Email
            ViewBag.Norma = new SelectList(new List<string>()
            {
               "NTEA - 18","NTEA - 19"
            });
            ViewBag.Perfil = new SelectList(new List<string>()
            {
               "Persona Física","Jurídico Colectivo","Dependencia Pública"
            });
            ViewBag.Estado = new SelectList(new List<string>()
            {
               "Estado de México","Aguascalientes","Baja California","Baja California Sur","Campeche","Chiapas","Chihuahua",
               "Ciudad de México","Coahuila","Colima","Durango","Guanajuato","Guerrero","Hidalgo",
               "Jalisco","Michoacán","Morelos","Nayarit","Nuevo León","Oaxaca","Puebla","Querétaro","Quintana Roo",
               "San Luis Potosí","Sinaloa","Sonora","Tabasco","Tamaulipas","Tlaxcala","Veracruz","Yucatán","Zacatecas"
            });
            return View(Profile);
        }


        [HttpPost]

        public async Task<ActionResult> 
            Create(
               ProfileEntity obj,
          HttpPostedFileBase profileFile,
          HttpPostedFileBase profileFileEdit,
          HttpPostedFileBase profileFileConf,
          HttpPostedFileBase profileFileExt,
          HttpPostedFileBase profileFileAdmin,
          HttpPostedFileBase profileFileSudo,
          HttpPostedFileBase profileFileUser

            )
        {

            CloudBlockBlob profileBlob = null;
            CloudBlockBlob profileBlobEdit = null;
            CloudBlockBlob profileBlobConf = null;
            CloudBlockBlob profileBlobExt = null;
            CloudBlockBlob profileBlobAdmin = null;
            CloudBlockBlob profileBlobSudo = null;
            CloudBlockBlob profileBlobUser = null;




            #region Upload File In Blob Storage
            //Step 1: Uploaded File in BLob Storage
            if (profileFileUser == null || profileFileUser.ContentLength == 0)
            {
            }
            else
            {
                profileBlob = await blobOperations.UploadBlob(profileFile);
                obj.ProfilePath = profileBlob.Uri.ToString();
                profileBlobEdit = await blobOperations.UploadBlob(profileFileEdit);
                obj.ProfilePathEdit = profileBlobEdit.Uri.ToString();
                profileBlobConf = await blobOperations.UploadBlob(profileFileConf);
                obj.ProfilePathConf = profileBlobConf.Uri.ToString();
                profileBlobExt = await blobOperations.UploadBlob(profileFileExt);
                obj.ProfilePathExt = profileBlobExt.Uri.ToString();
                profileBlobAdmin = await blobOperations.UploadBlob(profileFileAdmin);
                obj.ProfilePathAdmin = profileBlobAdmin.Uri.ToString();
                profileBlobSudo = await blobOperations.UploadBlob(profileFileSudo);
                obj.ProfilePathAdmin = profileBlobSudo.Uri.ToString();
                profileBlobUser = await blobOperations.UploadBlob(profileFileUser);
                obj.ProfilePathUser = profileBlobUser.Uri.ToString();
            }
                    //Ends Here 
                    #endregion

                    #region Save Information in Table Storage
                    //Step 2: Save the Infromation in the Table Storage

                    //Get the Original File Size
                    obj.Email = User.Identity.Name; // The Login Email
            obj.RowKey = obj.ProfileId.ToString();
            obj.PartitionKey = obj.Email;
            //Save the File in the Table
            tableOperations.CreateEntity(obj);
            //Ends Here 
            #endregion

             

            return RedirectToAction("Index");
     
        }
    }
}