using Microsoft.EntityFrameworkCore;
using NDbfReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Data
{
    public class TestDB : ITestDB
    {

        public async Task<List<DBFMail>> GetEmail(string path, string ID, bool direction)
            {
                List<DBFMail> emails = new List<DBFMail>();
            using (var table = await Table.OpenAsync(path + "EMAILFOX.DBF"))
            {
                var reader = table.OpenReader(Encoding.ASCII);

                while (reader.Read())
                {
                    var row = new DBFMail()
                    {

                        ID = reader.GetString("ID"),
                        CONTENT = reader.GetString("CONTENT"),
                        EXP_ID = reader.GetString("EXP_ID"),
                        DEST_ID = reader.GetString("DEST_ID"),
                        READ = reader.GetDecimal("READ")
                    };
                    if (direction)
                    {
                        if (row.EXP_ID == ID)
                            emails.Add(row);
                    }
                    else
                    {
                        if (row.DEST_ID == ID)
                            emails.Add(row);
                    }
                }
            }

            return emails;
            }
        //public async Task<DataTable> GetEmail(string path, int EXP_ID)
        //{
        //    string asd = @"F:\Proiecte";

        //    string sir = String.Format("Driver={{Microsoft dBase Driver (*.dbf)}};DriverID=277;" +
        //        "SourceType=DBF;SourceDB={0};Exclusive=No;Deleted=No;Readonly=TRUE", asd);
        //    DataTable dt1 = new DataTable();
        //    //using (OdbcConnection con = new OdbcConnection(sir))
        //    //{
        //    //    await con.OpenAsync();

        //    //    OdbcCommand comanda = new OdbcCommand("SELECT * FROM Email.DBF", con); // WHERE MG =? AND DATA >=? AND DATA<=?           
        //    //    //OdbcCommand comanda = new OdbcCommand("SELECT * FROM Email.DBF WHERE EXP_ID =" + EXP_ID, con); // WHERE MG =? AND DATA >=? AND DATA<=?           
        //    //    comanda.CommandType = System.Data.CommandType.Text;
        //    //    comanda.CommandTimeout = 0;
        //    //    //comanda.Parameters.Add("@_mg", OdbcType.VarChar).Value = fisier.Trim();
        //    //    //comanda.Parameters.Add("@_PAMP", System.Data.Odbc.OdbcType.VarChar).Value = "I";
        //    //    //comanda.Parameters.Add("@_data1", System.Data.Odbc.OdbcType.Double).Value = 40;
        //    //    //comanda.Parameters.Add("@_data2", System.Data.Odbc.OdbcType.Date).Value = 100;
        //    //    OdbcDataReader reader = comanda.ExecuteReader();
        //    //    dt1.Load(reader);
        //    //}
        //    return dt1;
        //}

        public async Task<List<Person>> GetUsers()
        {
            using StreamReader r = new StreamReader(@"F:\Proiecte\_Lucru\Persoane.json");
            string json = await r.ReadToEndAsync();
            List<Person> items = JsonConvert.DeserializeObject<List<Person>>(json);
            return items;

        }

        public async Task<Person> GetPerson(int ID)
        {
            List<Person> items = await GetUsers();
            for (int i = 0; i < items.Count(); i++)
            {
                if (items[i].ID == ID) return items[i];
            }
            return null;
        }



        public async Task<List<DBFMail>> OpenDBF(string path)
        {
            List<DBFMail> emails = new List<DBFMail>();
            using (var table = await Table.OpenAsync(path + "EMAILFOX.DBF"))
            {
                var reader = table.OpenReader(Encoding.ASCII);

                while (reader.Read())
                {
                    var row = new DBFMail()
                    {

                        ID = reader.GetString("ID"),
                        CONTENT = reader.GetString("CONTENT"),
                        EXP_ID = reader.GetString("EXP_ID"),
                        DEST_ID = reader.GetString("DEST_ID"),
                        READ = reader.GetDecimal("READ")
                    };
                    emails.Add(row);
                }
            }

            return emails;
        }


    }
}
