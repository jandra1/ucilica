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
        public List<pitanjeKlasa> getQuestionsByYearAndubject(int year, string subject)
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
                        točan = row[6].ToString(),
                        slika = row[7].ToString(),
                        predmet = row[8].ToString(),
                        razred = int.Parse(row[9].ToString())

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

        public void addQuestion(string subject, string year, pitanjeKlasa q)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into " + subject+ " ([Naziv],[Kategorija],[Kolicina],[Kod],[Cijena],[Rok_trajanja],[Datum_nabave]) values('" +
                   p.name + "','" + p.cat + "'," + p.quant.ToString() + ",'" + p.code + "'," + p.price + "," + p.exp.ToString("#d/M/yyyy#") + "," + p.date.ToString("#d/M/yyyy#") + ")", con);
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
    
    }
}
