using Donnee;
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
            String affichage = null;
            Previsions lesPrevisions = new Previsions();
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 12.5844, 8.3564, 1200, 90.25, 2.356, 4.369, 56);
            lesPrevisions.ajoutPoint(2016, 3, 10, 9, 13.5746, 7.3687, 1200, 36.24, 1.089, 3.568, 12);
            lesPrevisions.ajoutDate(2016, 3, 10, 12);

            affichage = lesPrevisions.ToString();
            Console.WriteLine(affichage);
            Console.ReadKey();
        }
    }
}
