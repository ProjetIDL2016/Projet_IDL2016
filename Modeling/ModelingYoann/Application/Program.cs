using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using donnee;
using edition;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition e = null;
            Previsions p = null;
            DateTime[] debut = new DateTime[2], fin = new DateTime[2];
            double latitude1, longitude1, latitude2, longitude2;
            double[] vitesse = new double[2], direction = new double[2], u = new double[2], v = new double[2], pression = new double[2];
            int choix = 1;


            Console.WriteLine("Définissez la zone géographique de la nouvelle prévision : ");
            Console.WriteLine("Coordonnées du premier point :");
            Console.WriteLine("Latitude :");
            latitude1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Longitude :");
            longitude1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Coordonnées du deuxième point :");
            Console.WriteLine("Latitude :");
            latitude2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Longitude :");
            longitude2 = Convert.ToDouble(Console.ReadLine());

            while (choix == 1) {
                Console.WriteLine("Entrez la date et l'heure de début de la prévision (dd/mm/yyyy hh:mm:ss) :");
                debut[0] = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Entrez la date et l'heure de début de la prévision (dd/mm/yyyy hh:mm:ss) :");
                debut[0] = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Entrez la vitesse du vent en kmH");
                vitesse[0] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Entrez la direction du vent en degré (entre 0 et 360) :");
                direction[0] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Entrez la pression atmosphérique en hPa :");
                pression[0] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nQue voulez vous faire ?");
                Console.WriteLine("1: Ajouter une prévision");
                Console.WriteLine("2: Valider");
                Console.WriteLine("3: Annuler");
                choix = Convert.ToInt32(Console.ReadLine());
            }

            e = new Edition();
            p = e.creerPrevision(latitude1, longitude1, latitude2, longitude2, debut, fin, vitesse, direction, pression, TypeVitesseVent.KilometreHeure);

            Console.WriteLine(p.ToString());


            Console.ReadLine();

        }
    }
}
