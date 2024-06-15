using PhotoIDService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhotoIDService.Services
{
    public class IPhotoID
    {
        public ResponsePhotoID GetPhotoID(SqlConnection connection)
        {
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            string sp = "[dbo].[PhotoID_Get]";
            SqlDataAdapter da = new SqlDataAdapter(sp, connection);
            DataTable dt = new DataTable();

            List<PhotoID> listPhotoIDs = new List<PhotoID>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PhotoID PhotoIDs = new PhotoID();
                    PhotoIDs.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    PhotoIDs.NIK = Convert.ToString(dt.Rows[i]["NIK"]);
                    PhotoIDs.Path_Photo = Convert.ToString(dt.Rows[i]["Path_Photo"]);

                    listPhotoIDs.Add(PhotoIDs);
                }
            }
            if (listPhotoIDs.Count > 0)
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data found";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }
            else
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data not found";
                ResponsePhotoID.photoIDs = null;
            }
            return ResponsePhotoID;
        }
        public ResponsePhotoID GetPhotoIDById(SqlConnection connection, int Id)
        {
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            string sp = "[dbo].[PhotoID_GetById]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            List<PhotoID> listPhotoIDs = new List<PhotoID>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PhotoID PhotoIDs = new PhotoID();
                    PhotoIDs.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    PhotoIDs.NIK = Convert.ToString(dt.Rows[i]["NIK"]);
                    PhotoIDs.Path_Photo = Convert.ToString(dt.Rows[i]["Path_Photo"]);

                    listPhotoIDs.Add(PhotoIDs);
                }
            }
            if (listPhotoIDs.Count > 0)
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data found";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }
            else
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data not found";
                ResponsePhotoID.photoIDs = null;
            }
            return ResponsePhotoID;
        }
        public ResponsePhotoID InsertPhotoID(SqlConnection connection, RequestPhotoID insertPhotoID)
        {
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            string sp = "[dbo].[PhotoID_Insert]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NIK", insertPhotoID.NIK);
            cmd.Parameters.AddWithValue("@Path_Photo", insertPhotoID.Path_Photo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<PhotoID> listPhotoIDs = new List<PhotoID>();
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
                    PhotoID PhotoIDs = new PhotoID();
                    PhotoIDs.Id = Convert.ToInt32(dr["Id"]);
                    PhotoIDs.NIK = Convert.ToString(dr["NIK"]);
                    PhotoIDs.Path_Photo = Convert.ToString(dr["Path_Photo"]);

                    listPhotoIDs.Add(PhotoIDs);
                }
            }
            if (Result == "Success")
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data has been created.";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }
            else
            {
                ResponsePhotoID.MsgCode = 100;
                ResponsePhotoID.MsgInfo = "Duplicate NIK, Please check your data.";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }

            return ResponsePhotoID;
        }
        public ResponsePhotoID UpdatePhotoID(SqlConnection connection, PhotoID updatePhotoID)
        {
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            string sp = "[dbo].[PhotoID_Update]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", updatePhotoID.Id);
            cmd.Parameters.AddWithValue("@NIK", updatePhotoID.NIK);
            cmd.Parameters.AddWithValue("@Path_Photo", updatePhotoID.Path_Photo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<PhotoID> listPhotoIDs = new List<PhotoID>();
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
                    PhotoID PhotoIDs = new PhotoID();
                    PhotoIDs.Id = Convert.ToInt32(dr["Id"]);
                    PhotoIDs.NIK = Convert.ToString(dr["NIK"]);
                    PhotoIDs.Path_Photo = Convert.ToString(dr["Path_Photo"]);

                    listPhotoIDs.Add(PhotoIDs);
                }
            }
            if (Result == "Success")
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data has been updated.";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }
            else
            {
                ResponsePhotoID.MsgCode = 100;
                ResponsePhotoID.MsgInfo = "Data not found.";
                ResponsePhotoID.photoIDs = listPhotoIDs;
            }

            return ResponsePhotoID;
        }
        public ResponsePhotoID DeletePhotoID(SqlConnection connection, int Id)
        {
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            string sp = "[dbo].[PhotoID_Delete]";
            SqlCommand cmd = new SqlCommand(sp, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            List<PhotoID> listPhotoIDs = new List<PhotoID>();
            da.Fill(dt);
            string Result = string.Empty;
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                Result = Convert.ToString(dr["ResultProcess"]);
            }
            if (Result == "Success")
            {
                ResponsePhotoID.MsgCode = 200;
                ResponsePhotoID.MsgInfo = "Data has been deleted.";
                ResponsePhotoID.photoIDs = null;
            }
            else
            {
                ResponsePhotoID.MsgCode = 100;
                ResponsePhotoID.MsgInfo = "Data not found.";
                ResponsePhotoID.photoIDs = null;
            }

            return ResponsePhotoID;
        }
    }
}
