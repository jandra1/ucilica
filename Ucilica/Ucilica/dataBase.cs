using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucilica
{
    internal class dataBase
    {
        public List<pitanjeKlasa> getQuestionsByYearAndSubject(int year, string subject)
        {
            List<pitanjeKlasa> ret = new List<pitanjeKlasa>();
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter("select * from " + subject +" where razred = " + year.ToString(), con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ret.Add(new pitanjeKlasa()
                    {
                        id = int.Parse(row[0].ToString()),
                        pitanje = row[1].ToString(),
                        odgovori = new List<string>() { row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString() },
                        točan = row[5].ToString(),
                        razred = year,
                        slika = row[7].ToString(),
                        predmet = subject

                    }); ;
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ret;
        }

        public void addQuestion(pitanjeKlasa q)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into " + q.predmet + " ([pitanja],[odg_1],[odg_2],[odg_3],[odg_t],[razred],[slika]) values('" +
                   q.pitanje + "','" + q.odgovori[0] + "'," + q.odgovori[1] + ",'" + q.odgovori[2] + "','" + q.točan + "'," + q.razred + ",'" + q.slika + "')", con);
                int inserted = cmd.ExecuteNonQuery();
                Console.WriteLine("ubaceno redaka " + inserted);
                con.Close();
               // return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return false;
            }
        }

        public void addSubject(string subject)
        {

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("create table " + subject + "(ID AutoIncrement PRIMARY KEY, pitanja TEXT, odg_1 TEXT, odg_2 TEXT, "+
                  "odg_3 TEXT, odg_t TEXT, razred SMALLINT, slika TEXT)", con);
                int inserted = cmd.ExecuteNonQuery();
                Console.WriteLine("ubaceno redaka " + inserted);
                con.Close();
                // return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return false;
            }
        }

        public List<string> getTableNames() //ovo ne radi
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            List<string> tableNames = new List<string>();
            try
            {
                con.Open();
                /*String[] tblrestrictions = new String[] { "Nothing", "Nothing", "Nothing", "TABLE" };
                DataTable dt = con.GetSchema("tables", tblrestrictions);*/
                OleDbDataAdapter sda = new OleDbDataAdapter("select MSysObjects.name from MSysObjects where MSysObjects.type In(1, 4, 6) "+
                    "and MSysObjects.name not like '~*' and MSysObjects.name not like 'MSys*' order by MSysObjects.name", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine("novo");
                    if(row[0].ToString() != "login")
                    {
                        Console.WriteLine(row[0].ToString());
                        tableNames.Add(row[0].ToString());
                    }
                }
                con.Close();
                return tableNames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return tableNames;
            }
        }
    
    }
}
