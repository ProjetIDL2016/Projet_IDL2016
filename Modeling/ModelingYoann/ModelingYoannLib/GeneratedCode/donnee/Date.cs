﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace donnee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Date
    {
        public Date(int a, int m, int j, int h)
        {
            this.Annee = a;
            this.Mois = m;
            this.Jour = j;
            this.Heure = h;
            this.lesPoints = null;
        }
        public virtual int Annee
        {
            get;
            set;
        }

        public virtual int Mois
        {
            get;
            set;
        }

        public virtual int Jour
        {
            get;
            set;
        }

        public virtual int Heure
        {
            get;
            set;
        }

        public virtual IList<Point> lesPoints
        {
            get;
            set;
        }

        public virtual Point recherchePoint(double latitude, double longitude)
        {
            foreach (Point unPoint in lesPoints)
            {
                if ((unPoint.Latitude == latitude) && (unPoint.Longitude == longitude))
                {
                    return unPoint;
                }
            }
            return null;
        }

        override public String ToString()
        {
            String res = String.Empty;
            if (lesPoints != null)
            {
                foreach (Point unPoint in lesPoints)
                {
                    if (this.Jour < 10)
                    {
                        res += "0";
                    }
                    res += this.Jour + "/";
                    if (this.Mois < 10)
                    {
                        res += "0";
                    }
                    res += this.Mois + "/" + this.Annee + " à " + this.Heure + "h : " + unPoint.ToString() + Environment.NewLine;
                }
            }
            return res;
        }

    }
}

