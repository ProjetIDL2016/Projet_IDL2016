

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.Threading;

namespace Maps
{
    public partial class Form1 : Form
    {
       
           private GMapOverlay polyOverlay = new GMapOverlay("polygons");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Afficher une map */

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            // On Choisi le Provider de la MAP
            gMapControl1.MapProvider = GMapProviders.OpenSeaMapHybrid;
            gMapControl1.Position = new PointLatLng(48.400786, -4.501220);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            
            /*Ajouter un marker */
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(48.400923, -4.503122),GMarkerGoogleType.green);
        
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(48.401537, -4.501976));
            points.Add(new PointLatLng(48.401553, -4.502671));
            points.Add(new PointLatLng(48.399633, -4.502665));
            points.Add(new PointLatLng(48.399633, -4.500007));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);

            gMapControl1.Overlays.Add(polyOverlay);
            polyOverlay.Polygons.Add(polygon);

            GMapOverlay polyOverlay2 = new GMapOverlay("polygons");
            List<PointLatLng> points2 = new List<PointLatLng>();
            points2.Add(new PointLatLng(48.401496, -4.503122));
            points2.Add(new PointLatLng(48.400323, -4.503092));
            points2.Add(new PointLatLng(48.400462, -4.500879));
            points2.Add(new PointLatLng(48.401122, -4.501176));
            GMapPolygon polygon2 = new GMapPolygon(points2, "mypolygon2");
            polygon2.Fill = new SolidBrush(Color.FromArgb(50, Color.Blue));
            polygon2.Stroke = new Pen(Color.Green, 1);

            gMapControl1.Overlays.Add(polyOverlay2);
            polyOverlay2.Polygons.Add(polygon2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            GMapOverlay polyOverlay2 = new GMapOverlay("polygons");
            List<PointLatLng> points2 = new List<PointLatLng>();
            points2.Add(new PointLatLng(48.401496, -4.503122));
            points2.Add(new PointLatLng(48.400323, -4.503092));
            points2.Add(new PointLatLng(48.400462, -4.500879));
            points2.Add(new PointLatLng(48.401122, -4.501176));
            GMapPolygon polygon2 = new GMapPolygon(points2, "mypolygon2");
            // Max
            polygon2.Fill = new SolidBrush(Color.FromArgb(255, Color.Yellow));
            polygon2.Stroke = new Pen(Color.Green, 1);

            gMapControl1.Overlays.Add(polyOverlay2);
            polyOverlay.Polygons.Add(polygon2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(polyOverlay.Polygons.Count());
            polyOverlay.Polygons.Remove(polyOverlay.Polygons.Last());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(48.400786, -4.501220);
        }
    }
}
