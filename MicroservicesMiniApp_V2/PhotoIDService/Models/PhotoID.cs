using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoIDService.Models
{
    [Table("PhotoID")]
    public class PhotoID
    {
        [Key]
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Path_Photo { get; set; }
    }

    public class RequestPhotoIDByNIK
    {
        public string NIK { get; set; }
    }

    public class RequestPhotoID
    {
        public string NIK { get; set; }
        public string Path_Photo { get; set; }
    }
    public class ResponsePhotoID
    {
        public int MsgCode { get; set; }
        public string MsgInfo { get; set; }
        public List<PhotoID> photoIDs { get; set; }
    }
}
