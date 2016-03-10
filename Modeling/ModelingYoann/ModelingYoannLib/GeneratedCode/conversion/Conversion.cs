using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversion
{
    public class Conversion
    {

        static double direction = 0.0;
        static double vitesse = 0.0;
        static double pi = 3.141592654;


        public static double directionVent(double u, double v)
        {
            if (u >= 0)
            {
                if (v > 0)
                    direction = Math.Atan(u / v) * (180 / pi);
                if (v < 0)
                    direction = (pi + Math.Atan(u / v)) * (180 / pi);
                if (v == 0)
                    direction = 90;
            }
            else if (u < 0)
            {
                if (v < 0)
                    direction = (pi + Math.Atan(u / v)) * (180 / pi);
                if (v > 0)
                    direction = (2 * pi + Math.Atan(u / v)) * (180 / pi);
                if (v == 0)
                    direction = 270;
            }
            return direction;
        }

        public static double vitesseVent(double u, double v)
        {
            double uCarre = u * u;
            double vCarre = v * v;
            vitesse = Math.Sqrt((uCarre + vCarre)); // RacineCarre(u²+v²)
            return vitesse;
        }

        public static double obtenirV(double direction, double vitesse)
        {
            double u = 0.0;
            u = Math.Cos(direction * pi / 180) * vitesse;
            return u;
        }

        public static double obtenirU(double direction, double vitesseV)
        {
            double u = 0.0;
            u = Math.Sin(direction * pi / 180) * vitesse;
            return u;
        }

        public static double msVersKMH(double vitesse)
        {
            vitesse = vitesse * 3.6;
            return vitesse;
        }

        public static double msVersNoeud(double vitesse)
        {
            vitesse = vitesse * 1.94384;
            return vitesse;
        }

        public static double kmVersMs(double vitesse)
        {
            vitesse = vitesse * 0.277778;
            return vitesse;
        }

        public static double kmVersNoeud(double vitesse)
        {
            vitesse = vitesse * 0.539957;
            return vitesse;
        }

        public static double noeudVersMs(double vitesse)
        {
            vitesse = vitesse * 0.5144;
            return vitesse;
        }

        public static double noeudVersKm(double vitesse)
        {
            vitesse = vitesse * 1.8519;
            return vitesse;
        }
    }
}
