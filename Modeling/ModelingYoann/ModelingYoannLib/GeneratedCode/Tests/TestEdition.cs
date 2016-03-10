using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using donnee;
using conversion;
using edition;

namespace TestUnitaires
{
    [TestClass]
    public class UnitTestEdition
    {
        Edition e = null;
        Previsions p = null;
        DateTime[] debut = new DateTime[2], fin = new DateTime[2];
        double[] vitesse = new double[2], direction = new double[2], u = new double[2], v = new double[2], pression = new double[2];
        String ResultatObtenu, ResultatAttendu;

        [TestMethod]
        public void TestEditionPrevisionExiste()
        {
            debut[0] = new DateTime(2016, 3, 10, 11, 0, 0);
            debut[1] = new DateTime(2016, 3, 10, 12, 0, 0);
            fin[0] = new DateTime(2016, 3, 10, 12, 0, 0);
            fin[1] = new DateTime(2016, 3, 10, 13, 0, 0);

            vitesse[0] = 50;
            vitesse[1] = 110;
            direction[0] = 180;
            direction[1] = 90;

            u[0] = conversion.Conversion.obtenirU(direction[0], vitesse[0]);
            u[1] = conversion.Conversion.obtenirU(direction[1], vitesse[1]);
            v[0] = conversion.Conversion.obtenirV(direction[0], vitesse[0]);
            v[1] = conversion.Conversion.obtenirV(direction[1], vitesse[1]);

            pression[0] = 1015;
            pression[1] = 1015;


            e = new Edition();
            p = e.creerPrevision(47, 58, 48, 57, debut, fin, u, v, pression, TypeVitesseVent.KilometreHeure);

            ResultatObtenu = p.getVent(2016, 3, 10, 11, 47, 58).ToString();
            ResultatAttendu = "10/03/2016 11h : lat: 47 long: 57 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 47 long: 57,5 p: 1015 dir: 180 v: 50\n" 
                            + "10/03/2016 11h : lat: 47 long: 58 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 47,5 long: 57 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 47,5 long: 57,5 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 47,5 long: 58 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 48 long: 57 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 48 long: 57,5 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 11h : lat: 48 long: 58 p: 1015 dir: 180 v: 50\n"
                            + "10/03/2016 12h : lat: 47 long: 57 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 47 long: 57,5 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 47 long: 58 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 47,5 long: 57 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 47,5 long: 57,5 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 47,5 long: 58 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 48 long: 57 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 48 long: 57,5 p: 1015 dir: 90 v: 110\n"
                            + "10/03/2016 12h : lat: 48 long: 58 p: 1015 dir: 90 v: 110";

            Assert.IsNotNull(p);
            Assert.IsFalse(ResultatObtenu.Equals(ResultatAttendu));
        }
    }
}
