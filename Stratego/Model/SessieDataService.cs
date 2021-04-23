using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stratego.Model
{
    class SessieDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Sessie> GetSessies()
        {
            string sql = "Select * from sessie";

            //s INNER JOIN bord b on s.bord_id = b.id

            // Type casten van het generieke return type naar een collectie van personen
            return (List<Sessie>)db.Query<Sessie>(sql);
        }

        public List<Sessie> GetSessie(Sessie sessie)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from sessie where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Sessie>)db.Query<Sessie>(sql, new
            {          
                sessie.team1_Speler,
                sessie.team2_Speler
            });
        }

        public List<Bord> GetBordHexBySessieID(Bord bord)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from bord where bord_id = @bord_id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Bord>)db.Query<Sessie>(sql, new
            {
                bord.ID,
                bord.HexCode
            });
        }


        public void DeleteSessie(Sessie sessie)
        {

            // SQL statement delete 
            string sql = "Delete sessie where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { sessie.ID });
        }

        public void InsertSessie(Sessie sessie)
        {
            // SQL statement insert
            string sql = "Insert into sessie (team1_speler, team2_speler, bord_id, bord_kleur) values ( @team1_speler, @team2_speler, @bordid, @bordkleur)";

            if (sessie.team1_Speler == null|| sessie.team1_Speler == " " || sessie.team1_Speler == "" || sessie.team2_Speler == null || sessie.team2_Speler == " " || sessie.team2_Speler == "")
            {
                MessageBox.Show("Vul alles in.");
            } else
            {
                db.Execute(sql, new
                {
                    sessie.team1_Speler,
                    sessie.team2_Speler,
                    sessie.bordID,
                    sessie.BordKleur,
                    
                });
            }
           
               
            

        }

        public void UpdateSessie(Sessie sessie)
        {

            string sql = "Update Sessie set team1_speler = @team1_speler, team2_speler = @team2_speler where id = @id";

            db.Execute(sql, new
            {

                sessie.team1_Speler,
                sessie.team2_Speler,
                sessie.ID
            });
        }
    }
}
