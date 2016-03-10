using donnee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDonnee
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> listepoint;
            String affichage = null;
            Previsions lesPrevisions = new Previsions();
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 12.5844, 8.3564, 1200, 90.25, 2.356, 4.369, 56);
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 13.5746, 7.3687, 1200, 36.24, 1.089, 3.568, 12);
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 13.7489, 9.6312, 1200, 36.24, 1.089, 3.568, 12);
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 11.2351, 1.2236, 1200, 36.24, 1.089, 3.568, 12);
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 55.2562, 89.3687, 1200, 36.24, 1.089, 3.568, 12);
            lesPrevisions.ajoutDate(2016, 3, 10, 12);
            affichage = lesPrevisions.ToString();
            Console.WriteLine(affichage);

            //listepoint = lesPrevisions.lesDates.Where(Date.Equals(new Date(2016, 3, 10, 9));
            affichage = lesPrevisions.getPoint(2016, 3, 10, 9, 13.7489, 9.6312).ToString();
            Console.WriteLine(affichage);
            Console.WriteLine();

            listepoint = lesPrevisions.getZone(2016, 3, 10, 9, 10, 7, 14, 10).ToList();
            foreach (Point p in listepoint)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadKey();
        }
    }
}
