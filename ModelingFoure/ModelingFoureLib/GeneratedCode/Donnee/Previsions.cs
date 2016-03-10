﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Donnee
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Previsions
	{
		public virtual IList<Date> lesDates
		{
			get;
			set;
		}

		public virtual bool ajoutPoint(int annee, int mois, int jour, int heure, double latitude, double longitude, double pression, double direction, double u, double v, double vitesse)
		{
            Date uneDate = this.rechercherDate(annee,mois,jour,heure);
            Point unPoint;
            Vent unVent;
            if (uneDate == null)
            {
                uneDate = new Date(annee, mois, jour, heure);
                unVent = new Vent(direction, u, v, vitesse);
                unPoint = new Point(latitude, longitude, unVent, pression);
                uneDate.lesPoints.Add(unPoint);
                lesDates.Add(uneDate);
            }
            else
            {
                unPoint = uneDate.recherchePoint(latitude, longitude);
                if (unPoint == null)
                {
                    unVent = new Vent(direction, u, v, vitesse);
                    unPoint = new Point(latitude, longitude, unVent, pression);
                    uneDate.lesPoints.Add(unPoint);
                    return true;
                }
            }
            return false;
		}

		public virtual bool ajoutDate(int annee, int mois, int jour, int heure)
		{
            Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            if (uneDate == null)
            {
                uneDate = new Date(annee, mois, jour, heure);
                lesDates.Add(uneDate);
                return true;
            }
            return false;
        }

		public virtual bool modifierPoint(int annee, int mois, int jour, int heure, double latitude, double longitude, double pression, double direction, double u, double v, double vitesse)
		{
            Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            Point unPoint;
            if (uneDate != null)
            {
                unPoint = uneDate.recherchePoint(latitude, longitude);
                if (unPoint != null)
                {
                    unPoint.leVent.Direction = direction;
                    unPoint.leVent.U = u;
                    unPoint.leVent.V = v;
                    unPoint.leVent.Vitesse = vitesse;
                    unPoint.Pression = pression;
                    return true;
                }
            }
            return false;
        }

		public virtual Point getPoint(int annee, int mois, int jour, int heure, double latitude, double longitude)
		{
			Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            Point unPoint = null;
            if (uneDate != null)
            {
                unPoint = uneDate.recherchePoint(latitude, longitude);
            }
            return unPoint;
        }

		public virtual Vent getVent(int annee, int mois, int jour, int heure, double latitude, int longitude)
		{
            Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            Vent unVent = null;
            if (uneDate != null)
            {
                Point unPoint = uneDate.recherchePoint(latitude, longitude);
                if (unPoint != null)
                {
                    unVent = unPoint.leVent;
                }
            }
            return unVent;
        }

		public virtual bool modifierZone(int annee, int mois, int jour, int heure, double lat1, double long1, double lat2, double long2, double pression, double direction, double u, double v, double vitesse)
		{
            Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            Vent unVent = new Vent(direction, u, v, vitesse);
            if (uneDate != null)
            {
                foreach (Point unPoint in uneDate.lesPoints)
                {
                    if ((unPoint.Latitude >= lat1) && (unPoint.Latitude <= lat2))
                    {
                        if ((unPoint.Longitude >= long1) && (unPoint.Longitude <= long2))
                        {
                            unPoint.leVent = unVent;
                            unPoint.Pression = pression;
                        }
                    }
                }
            }
            return false;
        }

		public virtual IList<Point> getZone(int annee, int mois, int jour, int heure, double lat1, double long1, double lat2, double long2, double pression, double direction, double u, double v, double vitesse)
		{
            List<Point> res = null;
            Date uneDate = this.rechercherDate(annee, mois, jour, heure);
            if (uneDate!= null)
            {
                foreach (Point unPoint in uneDate.lesPoints)
                {
                    if ((unPoint.Latitude >= lat1) && (unPoint.Latitude <= lat2))
                    {
                        if ((unPoint.Longitude >= long1) && (unPoint.Longitude <= long2))
                        {
                            res.Add(unPoint);
                        }
                    }
                }
            }
            return res;
        }

		public virtual Date rechercherDate(int annee, int mois, int jour, int heure)
		{
            foreach (Date uneDate in lesDates)
            {
                if (uneDate.Annee == annee)
                {
                    if (uneDate.Mois == mois)
                    {
                        if (uneDate.Jour == jour)
                        {
                            if (uneDate.Heure == heure)
                            {
                                return uneDate;
                            }
                        }
                    }
                }
            }
            return null;
        }

	}
}
