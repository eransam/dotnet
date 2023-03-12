using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Collections;
using System.Data.SqlClient;

namespace food1
{
    /// <summary>
    /// Summary description for FoodService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FoodService : System.Web.Services.WebService
    {
        [WebMethod]
        public void getAllProduct()
        {
            DataSet ds = Connection.GetDataSetBySqlStr("select * from productFood");
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }

        [WebMethod]
        public void countProducts()
        {
            DataSet ds = Connection.GetDataSetBySqlStr("CountProducts");
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }


        [WebMethod]
        public void getAllWorkers()
        {
            DataSet ds = Connection.GetDataSetBySqlStr("GetAllWorkers");
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }

        [WebMethod]
        public void getAllCatogories()
        {
            DataSet ds = Connection.GetDataSetBySqlStr("GetAllCatogories");
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }



        [WebMethod]
        public void DeleteOne(string productId)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@productId", productId));
            DataSet ds = Connection.GetDataSetBySP("DeleteOne", arr);
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));

        }





        [WebMethod]
        public void InsertOne(string productname, string amount, string price, string imageName, string note, string status,string productId)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@productname", productname));
            arr.Add(new paramList("@amount", amount));
            arr.Add(new paramList("@price", price));
            arr.Add(new paramList("@imageName", imageName));
            arr.Add(new paramList("@note", note));
            arr.Add(new paramList("@status", status));
            arr.Add(new paramList("@productId", productId));

            //         Connection.spExec("prc_oved_insert",arr) 
            if (Connection.spExec("InsertOne",arr))
            {
                Context.Response.Write(JsonConvert.SerializeObject(true));
            }
            else
            {
                Context.Response.Write(JsonConvert.SerializeObject(false));
            }
        }




        [WebMethod]
        public void UpDateProduct(string productname, string amount, string price, string imageName, string note, string status, string productId)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@productname", productname));
            arr.Add(new paramList("@amount", amount));
            arr.Add(new paramList("@@price", price));
            arr.Add(new paramList("@imageName", imageName));
            arr.Add(new paramList("@note", note));
            arr.Add(new paramList("@status", status));
            arr.Add(new paramList("@productId", productId));

            //         Connection.spExec("prc_oved_insert",arr) 
            if (Connection.spExec("UpDateProduct", arr))
            {
                Context.Response.Write(JsonConvert.SerializeObject(true));
            }
            else
            {
                Context.Response.Write(JsonConvert.SerializeObject(false));
            }
        }


        [WebMethod]
        public void ovedInsert(string name, string adddress)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@name", name));
            //         Connection.spExec("prc_oved_insert",arr) 
            if (Connection.sqlExec("update ovdim set name = '2323232'"))
            {
                Context.Response.Write(JsonConvert.SerializeObject(true));
            }
            else
            {
                Context.Response.Write(JsonConvert.SerializeObject(false));
            }
        }


        [WebMethod]
        public void GetOneProduct(string productId)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@productId", productId));
            DataSet ds = Connection.GetDataSetBySP("GetOneProduct", arr);
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }




        [WebMethod]
        public void getOved(string id)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new paramList("@id", id));
            DataSet ds = Connection.GetDataSetBySP("prc_get_oved", arr);
            //SqlConnection myConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FoodConnectionString"].ConnectionString);
            //SqlCommand sCommand = new SqlCommand("", myConn);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //sCommand.CommandText = "prc_get_oved";
            //sCommand.CommandType = CommandType.StoredProcedure;
            //sCommand.Parameters.Add(new SqlParameter("@id", id));
            //da.SelectCommand = sCommand;
            //da.Fill(ds);
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }




        [WebMethod]
        public void getOvdim()
        {
            //DataSet ds = Connection.GetDataSetBySqlStr("select * from Ovdim");
            DataSet ds = Connection.GetDataSetBySqlStr("GetAllWorkers");
            Context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }



    }
}

