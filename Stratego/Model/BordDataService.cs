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
    class BordDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Bord> GetBorden()
        {
            string sql = "Select * from bord";

            // Type casten van het generieke return type naar een collectie van personen
            return (List<Bord>)db.Query<Bord>(sql);
        }

        public List<Bord> GetBord(Bord bord)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Bord where id = @id";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Bord>)db.Query<Bord>(sql, new
            {
                bord.Kleur,
                bord.HexCode
            });
        }

        public void UpdateBord(Bord bord)
        {
            // SQL statement update 
            string sql = "Update Bord set kleur = @kleur, hexcode = @hexcode where id = @id";

            //// Uitvoeren SQL statement en doorgeven parametercollectie
            //if (GetPersoon(persoon).Count > 0)
            //{
            //    MessageBox.Show("Deze persoon bestaat al.");
            //}
            //else
            //{
            db.Execute(sql, new
            {

                bord.Kleur,
                bord.HexCode,
                bord.ID
            }); ;
            //}
        }

        public void DeleteBord(Bord bord)
        {
            // SQL statement delete 
            string sql = "Delete Bord where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { bord.ID });


        }

        public void ToevoegenBord(Bord bord)
        {
            // SQL statement insert
            string sql = "Insert into bord (kleur, hexcode) values (@kleur, @hexcode)";

            // Uitvoeren SQL statement en doorgeven parametercollectie

            if (bord == null || bord.Kleur == null || bord.Kleur == "" || bord.Kleur == " " || bord.HexCode == null){
                MessageBox.Show("Vul alles in.");
            } else
            {
                db.Execute(sql, new
                {
                    bord.Kleur,
                    bord.HexCode
                });
            }
            


        }


    }
}
