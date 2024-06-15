using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemografiService.Models
{
    [Table("Demografi")]
    public class Demografi
    {
        [Key]
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Tempat_Lahir { get; set; }
        public DateTime Tanggal_Lahir { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Golongan_Darah { get; set; }
        public string Alamat { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string Kelurahan { get; set; }
        public string Desa { get; set; }
        public string Kecamatan { get; set; }
        public string Kota { get; set; }
        public string Provinsi { get; set; }
        public string Agama { get; set; }
        public string KodePos { get; set; }
        public string StatusPerkawinan { get; set; }
        public string Pekerjaan { get; set; }
        public string Kewarganegaraan { get; set; }
        public DateTime Masa_Berlaku { get; set; }
    }
    public class RequestDemografi
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Tempat_Lahir { get; set; }
        public DateTime Tanggal_Lahir { get; set; }
        public string Jenis_Kelamin { get; set; }
        public string Golongan_Darah { get; set; }
        public string Alamat { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string Kelurahan { get; set; }
        public string Desa { get; set; }
        public string Kecamatan { get; set; }
        public string Kota { get; set; }
        public string Provinsi { get; set; }
        public string Agama { get; set; }
        public string KodePos { get; set; }
        public string StatusPerkawinan { get; set; }
        public string Pekerjaan { get; set; }
        public string Kewarganegaraan { get; set; }
        public DateTime Masa_Berlaku { get; set; }
    }
    public class ResponseDemografi
    {
        public int MsgCode { get; set; }
        public string MsgInfo { get; set; }
        public List<Demografi> demografis { get; set; }
    }
}
