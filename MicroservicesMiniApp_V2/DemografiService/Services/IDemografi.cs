using DemografiService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DemografiService.Services
{
    public class IDemografi
    {
        public ResponseDemografi GetDemografi(SqlConnection connection)
        {
            ResponseDemografi responseDemografi = new ResponseDemografi();
            string sp = "[dbo].[Demografi_Get]";
            SqlDataAdapter da = new SqlDataAdapter(sp, connection);
            DataTable dt = new DataTable();

            List<Demografi> listDemografis = new List<Demografi>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Demografi demografis = new Demografi();
                    demografis.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    demografis.NIK = Convert.ToString(dt.Rows[i]["NIK"]);
                    demografis.Nama = Convert.ToString(dt.Rows[i]["Nama"]);
                    demografis.Tempat_Lahir = Convert.ToString(dt.Rows[i]["Tempat_Lahir"]);
                    demografis.Tanggal_Lahir = Convert.ToDateTime(dt.Rows[i]["Tanggal_Lahir"]);
                    demografis.Jenis_Kelamin = Convert.ToString(dt.Rows[i]["Jenis_Kelamin"]);
                    demografis.Golongan_Darah = Convert.ToString(dt.Rows[i]["Golongan_Darah"]);
                    demografis.Alamat = Convert.ToString(dt.Rows[i]["Alamat"]);
                    demografis.RT = Convert.ToString(dt.Rows[i]["RT"]);
                    demografis.RW = Convert.ToString(dt.Rows[i]["RW"]);
                    demografis.Kelurahan = Convert.ToString(dt.Rows[i]["Kelurahan"]);
                    demografis.Desa = Convert.ToString(dt.Rows[i]["Desa"]);
                    demografis.Kecamatan = Convert.ToString(dt.Rows[i]["Kecamatan"]);
                    demografis.Kota = Convert.ToString(dt.Rows[i]["Kota"]);
                    demografis.Provinsi = Convert.ToString(dt.Rows[i]["Provinsi"]);
                    demografis.Agama = Convert.ToString(dt.Rows[i]["Agama"]);
                    demografis.KodePos = Convert.ToString(dt.Rows[i]["KodePos"]);
                    demografis.StatusPerkawinan = Convert.ToString(dt.Rows[i]["StatusPerkawinan"]);
                    demografis.Pekerjaan = Convert.ToString(dt.Rows[i]["Pekerjaan"]);
                    demografis.Kewarganegaraan = Convert.ToString(dt.Rows[i]["Kewarganegaraan"]);
                    demografis.Masa_Berlaku = Convert.ToDateTime(dt.Rows[i]["Masa_Berlaku"]);

                    listDemografis.Add(demografis);
                }
            }
            if (listDemografis.Count > 0)
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data found";
                responseDemografi.demografis = listDemografis;
            }
            else
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data not found";
                responseDemografi.demografis = null;
            }
            return responseDemografi;
        }
        public ResponseDemografi GetDemografiById(SqlConnection connection, int Id)
        {
            ResponseDemografi responseDemografi = new ResponseDemografi();
            string sp = "[dbo].[Demografi_GetById]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            List<Demografi> listDemografis = new List<Demografi>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Demografi demografis = new Demografi();
                    demografis.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    demografis.NIK = Convert.ToString(dt.Rows[i]["NIK"]);
                    demografis.Nama = Convert.ToString(dt.Rows[i]["Nama"]);
                    demografis.Tempat_Lahir = Convert.ToString(dt.Rows[i]["Tempat_Lahir"]);
                    demografis.Tanggal_Lahir = Convert.ToDateTime(dt.Rows[i]["Tanggal_Lahir"]);
                    demografis.Jenis_Kelamin = Convert.ToString(dt.Rows[i]["Jenis_Kelamin"]);
                    demografis.Golongan_Darah = Convert.ToString(dt.Rows[i]["Golongan_Darah"]);
                    demografis.Alamat = Convert.ToString(dt.Rows[i]["Alamat"]);
                    demografis.RT = Convert.ToString(dt.Rows[i]["RT"]);
                    demografis.RW = Convert.ToString(dt.Rows[i]["RW"]);
                    demografis.Kelurahan = Convert.ToString(dt.Rows[i]["Kelurahan"]);
                    demografis.Desa = Convert.ToString(dt.Rows[i]["Desa"]);
                    demografis.Kecamatan = Convert.ToString(dt.Rows[i]["Kecamatan"]);
                    demografis.Kota = Convert.ToString(dt.Rows[i]["Kota"]);
                    demografis.Provinsi = Convert.ToString(dt.Rows[i]["Provinsi"]);
                    demografis.Agama = Convert.ToString(dt.Rows[i]["Agama"]);
                    demografis.KodePos = Convert.ToString(dt.Rows[i]["KodePos"]);
                    demografis.StatusPerkawinan = Convert.ToString(dt.Rows[i]["StatusPerkawinan"]);
                    demografis.Pekerjaan = Convert.ToString(dt.Rows[i]["Pekerjaan"]);
                    demografis.Kewarganegaraan = Convert.ToString(dt.Rows[i]["Kewarganegaraan"]);
                    demografis.Masa_Berlaku = Convert.ToDateTime(dt.Rows[i]["Masa_Berlaku"]);

                    listDemografis.Add(demografis);
                }
            }
            if (listDemografis.Count > 0)
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data found";
                responseDemografi.demografis = listDemografis;
            }
            else
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data not found";
                responseDemografi.demografis = null;
            }
            return responseDemografi;
        }
        public ResponseDemografi InsertDemografi(SqlConnection connection, RequestDemografi insertDemografi)
        {
            ResponseDemografi responseDemografi = new ResponseDemografi();
            string sp = "[dbo].[Demografi_Insert]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NIK", insertDemografi.NIK);
            cmd.Parameters.AddWithValue("@Nama", insertDemografi.Nama);
            cmd.Parameters.AddWithValue("@Tempat_Lahir", insertDemografi.Tempat_Lahir);
            cmd.Parameters.AddWithValue("@Tanggal_Lahir", insertDemografi.Tanggal_Lahir);
            cmd.Parameters.AddWithValue("@Jenis_Kelamin", insertDemografi.Jenis_Kelamin);
            cmd.Parameters.AddWithValue("@Golongan_Darah", insertDemografi.Golongan_Darah);
            cmd.Parameters.AddWithValue("@Alamat", insertDemografi.Alamat);
            cmd.Parameters.AddWithValue("@RT", insertDemografi.RT);
            cmd.Parameters.AddWithValue("@RW", insertDemografi.RW);
            cmd.Parameters.AddWithValue("@Kelurahan", insertDemografi.Kelurahan);
            cmd.Parameters.AddWithValue("@Desa", insertDemografi.Desa);
            cmd.Parameters.AddWithValue("@Kecamatan", insertDemografi.Kecamatan);
            cmd.Parameters.AddWithValue("@Kota", insertDemografi.Kota);
            cmd.Parameters.AddWithValue("@Provinsi", insertDemografi.Provinsi);
            cmd.Parameters.AddWithValue("@Agama", insertDemografi.Agama);
            cmd.Parameters.AddWithValue("@KodePos", insertDemografi.KodePos);
            cmd.Parameters.AddWithValue("@StatusPerkawinan", insertDemografi.StatusPerkawinan);
            cmd.Parameters.AddWithValue("@Pekerjaan", insertDemografi.Pekerjaan);
            cmd.Parameters.AddWithValue("@Kewarganegaraan", insertDemografi.Kewarganegaraan);
            cmd.Parameters.AddWithValue("@Masa_Berlaku", insertDemografi.Masa_Berlaku);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<Demografi> listDemografis = new List<Demografi>();
            da.Fill(dt);
            string Result = string.Empty;
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Result = Convert.ToString(dr["ResultProcess"]);
            }
            if (dt.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[1].Rows)
                {
                    Demografi demografis = new Demografi();
                    demografis.Id = Convert.ToInt32(dr["Id"]);
                    demografis.NIK = Convert.ToString(dr["NIK"]);
                    demografis.Nama = Convert.ToString(dr["Nama"]);
                    demografis.Tempat_Lahir = Convert.ToString(dr["Tempat_Lahir"]);
                    demografis.Tanggal_Lahir = Convert.ToDateTime(dr["Tanggal_Lahir"]);
                    demografis.Jenis_Kelamin = Convert.ToString(dr["Jenis_Kelamin"]);
                    demografis.Golongan_Darah = Convert.ToString(dr["Golongan_Darah"]);
                    demografis.Alamat = Convert.ToString(dr["Alamat"]);
                    demografis.RT = Convert.ToString(dr["RT"]);
                    demografis.RW = Convert.ToString(dr["RW"]);
                    demografis.Kelurahan = Convert.ToString(dr["Kelurahan"]);
                    demografis.Desa = Convert.ToString(dr["Desa"]);
                    demografis.Kecamatan = Convert.ToString(dr["Kecamatan"]);
                    demografis.Kota = Convert.ToString(dr["Kota"]);
                    demografis.Provinsi = Convert.ToString(dr["Provinsi"]);
                    demografis.Agama = Convert.ToString(dr["Agama"]);
                    demografis.KodePos = Convert.ToString(dr["KodePos"]);
                    demografis.StatusPerkawinan = Convert.ToString(dr["StatusPerkawinan"]);
                    demografis.Pekerjaan = Convert.ToString(dr["Pekerjaan"]);
                    demografis.Kewarganegaraan = Convert.ToString(dr["Kewarganegaraan"]);
                    demografis.Masa_Berlaku = Convert.ToDateTime(dr["Masa_Berlaku"]);

                    listDemografis.Add(demografis);
                }
            }
            if (Result == "Success")
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data has been created.";
                responseDemografi.demografis = listDemografis;
            }
            else
            {
                responseDemografi.MsgCode = 100;
                responseDemografi.MsgInfo = "Duplicate NIK, Please check your data.";
                responseDemografi.demografis = listDemografis;
            }

            return responseDemografi;
        }
        public ResponseDemografi UpdateDemografi(SqlConnection connection, Demografi updateDemografi)
        {
            ResponseDemografi responseDemografi = new ResponseDemografi();
            string sp = "[dbo].[Demografi_Update]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", updateDemografi.Id);
            cmd.Parameters.AddWithValue("@NIK", updateDemografi.NIK);
            cmd.Parameters.AddWithValue("@Nama", updateDemografi.Nama);
            cmd.Parameters.AddWithValue("@Tempat_Lahir", updateDemografi.Tempat_Lahir);
            cmd.Parameters.AddWithValue("@Tanggal_Lahir", updateDemografi.Tanggal_Lahir);
            cmd.Parameters.AddWithValue("@Jenis_Kelamin", updateDemografi.Jenis_Kelamin);
            cmd.Parameters.AddWithValue("@Golongan_Darah", updateDemografi.Golongan_Darah);
            cmd.Parameters.AddWithValue("@Alamat", updateDemografi.Alamat);
            cmd.Parameters.AddWithValue("@RT", updateDemografi.RT);
            cmd.Parameters.AddWithValue("@RW", updateDemografi.RW);
            cmd.Parameters.AddWithValue("@Kelurahan", updateDemografi.Kelurahan);
            cmd.Parameters.AddWithValue("@Desa", updateDemografi.Desa);
            cmd.Parameters.AddWithValue("@Kecamatan", updateDemografi.Kecamatan);
            cmd.Parameters.AddWithValue("@Kota", updateDemografi.Kota);
            cmd.Parameters.AddWithValue("@Provinsi", updateDemografi.Provinsi);
            cmd.Parameters.AddWithValue("@Agama", updateDemografi.Agama);
            cmd.Parameters.AddWithValue("@KodePos", updateDemografi.KodePos);
            cmd.Parameters.AddWithValue("@StatusPerkawinan", updateDemografi.StatusPerkawinan);
            cmd.Parameters.AddWithValue("@Pekerjaan", updateDemografi.Pekerjaan);
            cmd.Parameters.AddWithValue("@Kewarganegaraan", updateDemografi.Kewarganegaraan);
            cmd.Parameters.AddWithValue("@Masa_Berlaku", updateDemografi.Masa_Berlaku);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<Demografi> listDemografis = new List<Demografi>();
            da.Fill(dt);
            string Result = string.Empty;
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Result = Convert.ToString(dr["ResultProcess"]);
            }
            if (dt.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[1].Rows)
                {
                    Demografi demografis = new Demografi();
                    demografis.Id = Convert.ToInt32(dr["Id"]);
                    demografis.NIK = Convert.ToString(dr["NIK"]);
                    demografis.Nama = Convert.ToString(dr["Nama"]);
                    demografis.Tempat_Lahir = Convert.ToString(dr["Tempat_Lahir"]);
                    demografis.Tanggal_Lahir = Convert.ToDateTime(dr["Tanggal_Lahir"]);
                    demografis.Jenis_Kelamin = Convert.ToString(dr["Jenis_Kelamin"]);
                    demografis.Golongan_Darah = Convert.ToString(dr["Golongan_Darah"]);
                    demografis.Alamat = Convert.ToString(dr["Alamat"]);
                    demografis.RT = Convert.ToString(dr["RT"]);
                    demografis.RW = Convert.ToString(dr["RW"]);
                    demografis.Kelurahan = Convert.ToString(dr["Kelurahan"]);
                    demografis.Desa = Convert.ToString(dr["Desa"]);
                    demografis.Kecamatan = Convert.ToString(dr["Kecamatan"]);
                    demografis.Kota = Convert.ToString(dr["Kota"]);
                    demografis.Provinsi = Convert.ToString(dr["Provinsi"]);
                    demografis.Agama = Convert.ToString(dr["Agama"]);
                    demografis.KodePos = Convert.ToString(dr["KodePos"]);
                    demografis.StatusPerkawinan = Convert.ToString(dr["StatusPerkawinan"]);
                    demografis.Pekerjaan = Convert.ToString(dr["Pekerjaan"]);
                    demografis.Kewarganegaraan = Convert.ToString(dr["Kewarganegaraan"]);
                    demografis.Masa_Berlaku = Convert.ToDateTime(dr["Masa_Berlaku"]);

                    listDemografis.Add(demografis);
                }
            }
            if (Result == "Success")
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data has been updated.";
                responseDemografi.demografis = listDemografis;
            }
            else
            {
                responseDemografi.MsgCode = 100;
                responseDemografi.MsgInfo = "Data not found.";
                responseDemografi.demografis = listDemografis;
            }

            return responseDemografi;
        }
        public ResponseDemografi DeleteDemografi(SqlConnection connection, int Id)
        {
            ResponseDemografi responseDemografi = new ResponseDemografi();
            string sp = "[dbo].[Demografi_Delete]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<Demografi> listDemografis = new List<Demografi>();
            da.Fill(dt);
            string Result = string.Empty;
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Result = Convert.ToString(dr["ResultProcess"]);
            }
            if (Result == "Success")
            {
                responseDemografi.MsgCode = 200;
                responseDemografi.MsgInfo = "Data has been deleted.";
                responseDemografi.demografis = null;
            }
            else
            {
                responseDemografi.MsgCode = 100;
                responseDemografi.MsgInfo = "Data not found.";
                responseDemografi.demografis = null;
            }

            return responseDemografi;
        }

    }
}
