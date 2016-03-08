using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPlan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SharpMap.Map myMap = new SharpMap.Map(new Size(400, 300));
            myMap.Size = new System.Drawing.Size(300, 200); //Set output size

            myMap.MinimumZoom = 100; //Minimum zoom allowed
            myMap.BackgroundColor = Color.White; //Set background
            myMap.Center = new SharpMap.Geometry.Point(725000, 6180000); //Set center of map

            //Add PostGIS layer:
            SharpMap.Layers.VectorLayer myLayer = new SharpMap.Layers.VectorLayer("My layer");
            string ConnStr = "Server=127.0.0.1;Port=5432;UserId=postgres;Password=password;Database=myGisDb;";
            myLayer.DataSource = new SharpMap.Data.Providers.PostGIS(ConnStr, "myTable", "the_geom", 32632);
            myLayer.MaxVisible = 40000;
            myMap.Layers.Add(myLayer);

            //Render the map
            ////1st possibility: Set zoom level
            //myMap.Zoom = 1200; //Set zoom level
            //2nd. possibility: Zoom to extents
            myMap.ZoomToExtents();
            System.Drawing.Image imgMap = myMap.GetMap();
        }
    }
}
