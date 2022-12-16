using Microsoft.WindowsAzure.Storage.Table;
using System.ComponentModel.DataAnnotations;

namespace EntityStores
{
    public class ProfileEntity : TableEntity
    {
        public ProfileEntity()
        {

        }

        public ProfileEntity(int profid, string email)
        {
            this.RowKey = profid.ToString();
            this.PartitionKey = email;
        }


        public int ProfileId { get; set; }
        public string Correo { get; set; }
        public string Norma { get; set; }
        public string Perfil { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string NombreDelOrganismoPúblico_EmpresaPrivada { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Cargo { get; set; }
        public string NúmeroContacto { get; set; }
        public string ProfilePath { get; set; }
        public string ProfilePathConf { get; set; }
        public string ProfilePathExt { get; set; }  
        public string ProfilePathAdmin { get; set; }
        public string ProfilePathSudo { get; set; }
        public string ProfilePathUser { get; set; }
        public string Email { get; set; }
    }

     



    //public class BlobInfo
    //{

    //    public int ProfileId { get; set; }
    //    public Uri uriBlob { get; set; }

    //    public string Profession { get; set; }

    //    public string BLOBName
    //    {
    //        get
    //        {
    //            return uriBlob.Segments[uriBlob.Segments.Length - 1];
    //        }
    //    }
    //    public string BlobNameWithNoExtension
    //    {
    //        get
    //        {
    //            return Path.GetFileNameWithoutExtension(BLOBName);
    //        }
    //    }

    //}
    
}
