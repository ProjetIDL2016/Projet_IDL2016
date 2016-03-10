using System;

public class Conversion
{
    double direction = 0.0;
    double vitesse = 0.0;
    double pi = 2.141592654;


    public static double directionVent(double u, double v)
    {
        if (u >= 0)
        {
            if (v > 0)
                direction = Math.Atan(u / v) * (180 / pi);
            if (v < 0)
                direction = (pi + Math.Atan(u / v)) * (180 / pi);
            if (v = 0)
                direction = 90;
        }
        else if (u < 0)
        {
            if (v < 0)
                direction = (pi + Math.Artan(u / v)) * (180 / pi);
            if (v > 0)
                direction = (2 * pi + Math.Atan(u / v)) * (180 / pi);
            if (v = 0)
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
