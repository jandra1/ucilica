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

        public bool register(string user, string pass)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = con;
                comm.CommandText = "insert into login ([Username], [Password]) values('" + user + "'," + pass + ")";
                comm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
            
        }

        public int login(string user, string pass)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter("select count(*) from login where Username='" + user + "' and Password=" + pass, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")   // ako vrijedi znači da u bazi postoji točno jedna osoba koja zadovoljava tražene uvjete (naveden username i lozinku)
                {

                    if (user == "admin")
                    {
                        con.Close();  // obavezno zatvaramo vezu s bazom
                        return -1;
                    }
                    else
                    {
                        con.Close();  // obavezno zatvaramo vezu s bazom
                        return 1;
                    }
                }

                else
                {
                    con.Close();
                    return 0;
                }
            }
            

            catch (Exception ex)  // ako povezivanje s bazom nije uspjelo - javi error
            {
                return -2;

            }
        }

        public bool checkIfPassExists(string pass)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbDataAdapter sd = new OleDbDataAdapter("select count(*) from login where Password=" + pass, con);
                DataTable dta = new DataTable();
                sd.Fill(dta);
                if (dta.Rows[0][0].ToString() == "1") //u bazi već postoji ta lozinka
                {
                    return false;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
            return true;
        }

        public bool chackIfUserExists(string user)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter("select count(*) from login where Username='" + user + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") //u bazi već postoji taj username
                    return false;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

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
                   q.pitanje + "','" + q.odgovori[0] + "','" + q.odgovori[1] + "','" + q.odgovori[2] + "','" + q.točan + "'," + q.razred + ",'" + q.slika + "')", con);
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

        public List<Tuple<string, int, string>> getScoresBySubjectAndYear(string subject, int year)
        {
            List<Tuple<string,int, string>> ret = new List<Tuple<string, int, string>>();

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter("select korisnik, bodovi, vrijeme from bodovi where predmet = "+ subject +"razred = " + year.ToString(), con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ret.Add(new Tuple<string, int, string>(row[0].ToString(), int.Parse(row[1].ToString()), row[2].ToString()));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ret;
        }

        public bool insertNewScore(string subject, int year, string user, int score, string time)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\login.accdb");
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into bodovi ([korisnik],[razred],[predmet],[bodovi],[vrijeme]) values('" +
                   user + "'," + year + ",'" + subject + "'," + score + ",'" + time + "')", con);
                int inserted = cmd.ExecuteNonQuery();
                Console.WriteLine("ubaceno redaka " + inserted);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    
    }
}
