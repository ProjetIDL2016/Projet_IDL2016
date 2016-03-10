using Grib.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Meteo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void img(string img) { }

        public void openGribFile(string filePath)
        {
            GribFile file = new GribFile("C:/Users/cedri/Desktop/" + filePath);


            foreach (GribMessage msg in file)
            {
                // Composante U
                if (msg["paramId"].AsString() == "131")
                {
                    foreach (GribValue val in msg)
                    {
                        if (val.Key.Equals("values"))
                        {
                            double[] tabValues = val.AsDoubleArray();
                            Console.WriteLine("NB val composante U: " + tabValues.Length);
                            foreach (double v in tabValues)
                            {
                                //Console.WriteLine(v);
                            }
                        }
                    }
                }

                // Composante V
                if (msg["paramId"].AsString() == "132")
                {
                    foreach (GribValue val in msg)
                    {
                        if (val.Key.Equals("values"))
                        {
                            double[] tabValues = val.AsDoubleArray();
                            Console.WriteLine("NB val composante V: " + tabValues.Length);
                            foreach (double v in tabValues)
                            {
                                //Console.WriteLine(v);
                            }
                        }
                    }
                }

                // 
                if (msg["paramId"].AsString() == "260065")
                {
                    foreach (GribValue val in msg)
                    {
                        if (val.Key.Equals("values"))
                        {
                            double[] tabValues = val.AsDoubleArray();
                            Console.WriteLine("NB val speed: " + tabValues.Length);
                            foreach (double v in tabValues)
                            {
                                //Console.WriteLine(v);
                            }
                        }
                    }
                }

                if (msg["paramId"].AsString() == "135")
                {
                    foreach (GribValue val in msg)
                    {
                        if (val.Key.Equals("values"))
                        {
                            double[] tabValues = val.AsDoubleArray();
                            Console.WriteLine("NB val Pression: " + tabValues.Length);
                            foreach (double v in tabValues)
                            {
                                //Console.WriteLine(v);
                            }
                        }
                    }
                }




                /*Console.WriteLine("*******");
                Console.WriteLine("[" + msg["paramId"].AsString() + "] " + msg["name"].AsString());
                Console.WriteLine("ParameterName: " + msg["parameterName"].AsString());
                Console.WriteLine("ShortName: " + msg["shortName"].AsString());
                Console.WriteLine("Units: " + msg["units"].AsString());
                Console.WriteLine("Coded values: " + msg["codedValues"].AsString());
                Console.WriteLine("Values: " + msg["values"].AsDoubleArray());*/
                //double[] val = msg["values"].AsDoubleArray();
                //Console.WriteLine("Val length: " + val.Length);
            }

        }

        public void editAndSaveGrb()
        {
            string outPath = "C:/Users/cedri/Desktop/fileOut.grb2";
            string readPath = "C:/Users/cedri/Desktop/file.grb2";

            using (GribFile readFile = new GribFile(readPath))
            {
                Console.WriteLine("Writing 1 message from {0} to {1}", readPath, outPath);

                var msg = readFile.First();
                msg["latitudeOfFirstGridPoint"].AsDouble(42);
                GribFile.Write(outPath, msg);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openGribFile("042.grb2");
        }
    }
}