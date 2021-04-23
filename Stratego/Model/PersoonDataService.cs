using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Windows;

namespace Stratego.Model
{
    public class PersoonDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Persoon> GetPersonen()
        {


            string sql = "Select * from persoon order by score DESC";
            SqlDataAdapter adapter = new SqlDataAdapter("GetAllPersonen", db.ConnectionString);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            

            // Type casten van het generieke return type naar een collectie van personen
            return (List<Persoon>)db.Query<Persoon>(sql);
        }

        public List<String> GetPersonenNamen()
        {
            string sql = "Select naam from persoon";

            // Type casten van het generieke return type naar een collectie van personen
            return (List<string>)db.Query<string>(sql);
        }




        public List<Persoon> GetPersoon(Persoon persoon)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Persoon where naam = @naam and id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Persoon>)db.Query<Persoon>(sql, new
            {
                persoon.Naam
            });
        }

        public void UpdatePersoon(Persoon persoon)
        {
            // SQL statement update 
            string sql = "Update Persoon set naam = @naam, score = @score where id = @id";

            //// Uitvoeren SQL statement en doorgeven parametercollectie
            //if (GetPersoon(persoon).Count > 0)
            //{
            //    MessageBox.Show("Deze persoon bestaat al.");
            //}
            //else
            //{
                
            //}


            if (persoon.Naam == null || persoon.Score < 0)
            {
                MessageBox.Show("Veld verkeerd ingevuld.");

            }
            else
            {
                db.Execute(sql, new
                {

                    persoon.Naam,
                    persoon.Score,
                    persoon.ID
                });
            }

        }

        public void UpdateScore(Persoon persoon)
        {
            // SQL statement update 
            string sql = "Update Persoon set score = score + 1 where id = @id";

            if (persoon.Naam == null)
            {
                MessageBox.Show("Veld verkeerd ingevuld.");

            }
            else
            {
                db.Execute(sql, new
                {
                    persoon.ID
                });
            }

        }


        public void DeletePersoon(Persoon persoon)
        {
            // SQL statement delete 
            string sql = "Delete Persoon where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { persoon.ID });

          
        }

      
        //public void ToevoegenPersoon(Persoon persoon)
        //{
        //    // sql statement insert
        //    string sql = "insert into persoon (naam) values (@naam)";

        //    db.Execute("ToevoegenPersoon", new
        //    {
        //        persoon.PersoonNaam
        //    }, commandType: CommandType.StoredProcedure
        //    );          
        //}

        public void ToevoegenPersoon(Persoon persoon)
        {
            // SQL statement insert
            string sql = "Insert into persoon (naam, score) values (@naam, @score)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            if (persoon == null || persoon.Naam == null || persoon.Naam == "" || persoon.Naam == " " || persoon.Score < 0)
            {
                MessageBox.Show("Veld verkeerd of niet ingevuld.");

            }
            else if (NameIsUniqe(persoon.Naam) != true)
            {
                MessageBox.Show("Deze persoon bestaat al.");

            } else
            {
                db.Execute(sql, new
                {
                    persoon.Naam,
                    persoon.Score
                });
            }
                
            

        }

        public bool NameIsUniqe(string naam)
        {

            bool answer = true;

            foreach (string item in GetPersonenNamen())
            {
                if (item == naam)
                {
                    answer = false;
                } 


            }

            return answer;
        }

        //public void DeleteVoertuig(Voertuig voertuig)
        //{
        //    // SQL statement delete 
        //    string sql = "Delete Verplaatsing where voertuigID = @id";

        //    // Uitvoeren SQL statement en doorgeven parametercollectie
        //    db.Execute(sql, new { voertuig.ID });

        //    // SQL statement delete 
        //    sql = "Delete Voertuig where id = @id";

        //    // Uitvoeren SQL statement en doorgeven parametercollectie
        //    db.Execute(sql, new { voertuig.ID });
        //}



    }
}
