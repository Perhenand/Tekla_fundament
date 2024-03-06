using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.Operations;
using System.Xml;
//using TSDa = Tekla.Structures.Datatype;
using Tekla.Structures.Analysis;

namespace proj1v1
{
    class UtforareTekla
    {
        private Dictionary<string, dynamic> inpla = new Dictionary<string, dynamic>();
        private List<Dictionary<string, dynamic>> inplint = new List<Dictionary<string, dynamic>>();
        private Dictionary<string, string> data_rit = new Dictionary<string, string>();

        public UtforareTekla(Dictionary<string, dynamic> data_platta_in, List<Dictionary<string, dynamic>> data_plint_in, Dictionary<string, string> data_rit_in)
        {
            inpla = data_platta_in;
            inplint = data_plint_in;
            data_rit = data_rit_in;
            //TSDa.Distance.CurrentUnitType = TSDa.Distance.UnitType.Meter;
        }

        public void SkapaFund()
        {
            bool status;
            Tabortallt();

            status = SkapaPlatta();
            status = SkapaPlintar();
        }

        public void SkapaMatlista()
        {
            string sokvag = "";
            string armnamn1 = data_rit["A-jarn"];
            string armnamn2 = data_rit["B-jarn"];
            string armnamn3 = data_rit["C-jarn"];
            string armnamn4 = data_rit["D-jarn"];
            string armnamn5 = data_rit["N-jarn"];
            string armnamn6 = data_rit["grskr"];
            double armL1 = 0;
            double armL2 = 0;
            double armL3 = 0;
            double armL4 = 0;
            double armL5 = 0;
            double armL6 = 0;
            string betnamn1 = inpla["KvalBk"];
            double betvol1 = 0;
            double tmp = 0;
            double tmp2 = 0;

            try
            {
                Model minModell = new Model();

                if (minModell.GetConnectionStatus())
                {
                    ModelObjectEnumerator mittEnum = minModell.GetModelObjectSelector().GetAllObjects();
                    int i = 0;
                    while (mittEnum.MoveNext())
                    {
                        tmp = 0;
                        tmp2 = 0;
                        if (mittEnum.Current is TSM.Reinforcement)
                        {
                            TSM.Reinforcement nyPart = mittEnum.Current as TSM.Reinforcement;
                            string namntmp = nyPart.Name;
                            tmp2 = nyPart.GetNumberOfRebars();
                            nyPart.GetReportProperty("LENGTH", ref tmp);
                            tmp = tmp * tmp2;
                            if (namntmp.Equals(armnamn1)) 
                            {armL1 = armL1 + tmp;}
                            else if (namntmp.Equals(armnamn2))
                            {armL2 = armL2 + tmp;}
                            else if (namntmp.Equals(armnamn3))
                            {armL3 = armL3 + tmp;}
                            else if (namntmp.Equals(armnamn4))
                            {armL4 = armL4 + tmp;}
                            else if (namntmp.Equals(armnamn5))
                            {armL5 = armL5 + tmp;}
                            else if (namntmp.Equals(armnamn6))
                            {armL6 = armL6 + tmp;}
                            i++;
                        }
                        if (mittEnum.Current is TSM.Beam)
                        {
                            TSM.Beam nyPart = mittEnum.Current as TSM.Beam;
                            //betvol1 = 0;
                            nyPart.GetReportProperty("VOLUME",ref tmp);
                            betvol1 = betvol1 + tmp;
                            i++;
                        }
                    }

                    try
                    {
                        SaveFileDialog savefile = new SaveFileDialog();
                        savefile.Title = "Spara materiallista com .CSV";
                        savefile.Filter = "txt files (*.csv)|*.csv";

                        if (savefile.ShowDialog() == DialogResult.OK)
                        {
                            sokvag = savefile.FileName;
                            string[] rader = new string[7];
                            rader[0] = string.Format("{0};{1}", betnamn1, Math.Round(betvol1).ToString());
                            if (armL1>0)
                            {rader[1] = string.Format("{0};{1}", armnamn1, Math.Round(armL1).ToString());}
                            if (armL2 > 0)
                            { rader[2] = string.Format("{0};{1}", armnamn2, Math.Round(armL2).ToString()); }
                            if (armL3 > 0)
                            { rader[3] = string.Format("{0};{1}", armnamn3, Math.Round(armL3).ToString()); }
                            if (armL4 > 0)
                            { rader[4] = string.Format("{0};{1}", armnamn4, Math.Round(armL4).ToString()); }
                            if (armL5 > 0)
                            { rader[5] = string.Format("{0};{1}", armnamn5, Math.Round(armL5).ToString()); }
                            if (armL6 > 0)
                            { rader[6] = string.Format("{0};{1}", armnamn6, Math.Round(armL6).ToString()); }

                            rader = rader.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            File.WriteAllLines(sokvag, rader);
                        }
                    }
                    catch (Exception ee)
                    { MessageBox.Show(ee.Message); }
                }
                else
                { MessageBox.Show("Ingen TEKLA-modell funnen!"); }
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private bool SkapaPlatta() 
        {
            Model minModel = new Model();
            bool status = true;

            if (minModel.GetConnectionStatus())
            {
                MessageBox.Show("fungerar");
                var dx = inpla["L"];
                var dy = inpla["B"];
                var xmitt = inpla["L"] * 0 + 10000.0;
                var ymitt = inpla["B"] * 0 + 10000.0;
                var t = inpla["T"];
                var kvb = inpla["KvalB"];
                var tsu = inpla["Ts1"];
                var ts = inpla["Ts2"];
                var kva = inpla["KvalA"];

                var dim1 = inpla["Dim1d"]; // Diameter, huvudarmering, niv 1/4 
                var dim2 = inpla["Dim2d"]; // Diameter, huvudarmering, niv 2/3 
                var dim1k = inpla["Dim1k"]; // Kvalitet, huvudarmering, niv 1/4 
                var dim2k = inpla["Dim2k"];
                var dimb1 = inpla["Dimb1d"];
                var dimb2 = inpla["Dimb2d"];
                var dimb1k = inpla["Dimb1k"];
                var dimb2k = inpla["Dimb2k"]; 
                var C1 = inpla["C1"];
                var C2 = inpla["C2"];
                var Lb1 = inpla["Lb1"];
                var Lb2 = inpla["Lb2"];
                var Eb1 = inpla["Eb1"];
                var Eb2 = inpla["Eb2"];

                var Dim3 = inpla["Dim3d"];
                var Dim3k = inpla["Dim3k"];
                var C3 = inpla["C3"];
                var Dimb3 = inpla["Dimb3d"];
                var Dimb3k = inpla["Dimb3k"];
                var Lbs3 = inpla["Lbs"];
                var Eb3 = inpla["Ebs"];

                string ajrn = data_rit["A-jarn"];
                string cjrn = data_rit["C-jarn"];

                //var dataKallaB = new List<Namnvarde>();
                //dataKallaB = ParamSam.Betongkvaliteter();
                
                //dataKallaB = ParamSam.Kvalitetarmering();
                //string kvalitetA = dataKallaB.First(d => d.ID == kva).Value;



                Beam platta = new Beam();
                platta.Profile.ProfileString = dx.ToString() + "*" + dy.ToString();
                platta.StartPoint.X = xmitt;
                platta.StartPoint.Y = ymitt;
                platta.StartPoint.Z = -t;
                platta.EndPoint.X = xmitt;
                platta.EndPoint.Y = ymitt;
                platta.EndPoint.Z = 0;
                platta.Position.Plane = Position.PlaneEnum.MIDDLE;
                platta.Position.Depth = Position.DepthEnum.MIDDLE;
                platta.Name = "Platta";
                platta.Material.MaterialString = inpla["KvalBk"];
                platta.Insert();

                double minX = platta.GetSolid().MinimumPoint.X + ts;
                double minY = platta.GetSolid().MinimumPoint.Y + ts;
                double maxX = platta.GetSolid().MaximumPoint.X - ts;
                double maxY = platta.GetSolid().MaximumPoint.Y - ts;
                double niv1Z = platta.GetSolid().MaximumPoint.Z - ts - dim1 / 2;
                double niv2Z = platta.GetSolid().MaximumPoint.Z - ts - dim1 - dim2 / 2;
                double niv3Z = platta.GetSolid().MinimumPoint.Z + tsu + dim1 + dim2 / 2;
                double niv4Z = platta.GetSolid().MinimumPoint.Z + tsu + dim1 / 2;

                if (inpla["Rikt1"] != true) 
                {
                    niv1Z = platta.GetSolid().MaximumPoint.Z - ts - dim1 / 2 - dim2;
                    niv2Z = platta.GetSolid().MaximumPoint.Z - ts - dim2 / 2;
                    niv3Z = platta.GetSolid().MinimumPoint.Z + tsu + dim2 / 2;
                    niv4Z = platta.GetSolid().MinimumPoint.Z + tsu + dim1 / 2 + dim2;

                    dim1 = inpla["Dim2d"]; // Diameter, huvudarmering, niv 1/4 
                    dim2 = inpla["Dim1d"]; // Diameter, huvudarmering, niv 2/3 
                    dim1k = inpla["Dim2k"]; // Kvalitet, huvudarmering, niv 1/4 
                    dim2k = inpla["Dim1k"];
                    dimb1 = inpla["Dimb2d"];
                    dimb2 = inpla["Dimb1d"];
                    dimb1k = inpla["Dimb2k"];
                    dimb2k = inpla["Dimb1k"];
                    C1 = inpla["C2"];
                    C2 = inpla["C1"];
                    Lb1 = inpla["Lb2"];
                    Lb2 = inpla["Lb1"];
                    Eb1 = inpla["Eb2"];
                    Eb2 = inpla["Eb1"];
                }

                double sidaZ1 = Math.Min(niv1Z, niv2Z);
                double sidaZ2 = Math.Max(niv3Z, niv4Z);

                // Huvudarmering + tillhörande byglar
                Polygon PolygonL11 = new Polygon();
                PolygonL11.Points.Add(new Point(minX, minY, niv1Z));
                PolygonL11.Points.Add(new Point(maxX, minY, niv1Z));
                Polygon PolygonL12 = new Polygon();
                PolygonL12.Points.Add(new Point(minX, maxY, niv1Z));
                PolygonL12.Points.Add(new Point(maxX, maxY, niv1Z));

                Polygon PolygonL21 = new Polygon();
                PolygonL21.Points.Add(new Point(minX, maxY, niv2Z));
                PolygonL21.Points.Add(new Point(minX, minY, niv2Z));
                Polygon PolygonL22 = new Polygon();
                PolygonL22.Points.Add(new Point(maxX, maxY, niv2Z));
                PolygonL22.Points.Add(new Point(maxX, minY, niv2Z));

                Polygon PolygonL31 = new Polygon();
                PolygonL31.Points.Add(new Point(minX, maxY, niv3Z));
                PolygonL31.Points.Add(new Point(minX, minY, niv3Z));
                Polygon PolygonL32 = new Polygon();
                PolygonL32.Points.Add(new Point(maxX, maxY, niv3Z));
                PolygonL32.Points.Add(new Point(maxX, minY, niv3Z));

                Polygon PolygonL41 = new Polygon();
                PolygonL41.Points.Add(new Point(minX, minY, niv4Z));
                PolygonL41.Points.Add(new Point(maxX, minY, niv4Z));
                Polygon PolygonL42 = new Polygon();
                PolygonL42.Points.Add(new Point(minX, maxY, niv4Z));
                PolygonL42.Points.Add(new Point(maxX, maxY, niv4Z));

                Polygon PolygonB141 = new Polygon();
                PolygonB141.Points.Add(new Point(minX+ Lb1, minY+ Eb1, niv1Z));
                PolygonB141.Points.Add(new Point(minX, minY + Eb1, niv1Z));
                PolygonB141.Points.Add(new Point(minX, minY + Eb1, niv4Z));
                PolygonB141.Points.Add(new Point(minX+ Lb1, minY + Eb1, niv4Z));
                Polygon PolygonB142= new Polygon();
                PolygonB142.Points.Add(new Point(minX + Lb1, maxY + Eb1, niv1Z));
                PolygonB142.Points.Add(new Point(minX, maxY + Eb1, niv1Z));
                PolygonB142.Points.Add(new Point(minX, maxY + Eb1, niv4Z));
                PolygonB142.Points.Add(new Point(minX + Lb1, maxY + Eb1, niv4Z));

                Polygon PolygonB143 = new Polygon();
                PolygonB143.Points.Add(new Point(maxX - Lb1, minY + Eb1, niv1Z));
                PolygonB143.Points.Add(new Point(maxX, minY + Eb1, niv1Z));
                PolygonB143.Points.Add(new Point(maxX, minY + Eb1, niv4Z));
                PolygonB143.Points.Add(new Point(maxX - Lb1, minY + Eb1, niv4Z));
                Polygon PolygonB144 = new Polygon();
                PolygonB144.Points.Add(new Point(maxX - Lb1, maxY + Eb1, niv1Z));
                PolygonB144.Points.Add(new Point(maxX, maxY + Eb1, niv1Z));
                PolygonB144.Points.Add(new Point(maxX, maxY + Eb1, niv4Z));
                PolygonB144.Points.Add(new Point(maxX - Lb1, maxY + Eb1, niv4Z));

                Polygon PolygonB231 = new Polygon();
                PolygonB231.Points.Add(new Point(minX + Eb2, minY + Lb2, niv2Z));
                PolygonB231.Points.Add(new Point(minX + Eb2, minY, niv2Z));
                PolygonB231.Points.Add(new Point(minX + Eb2, minY, niv3Z));
                PolygonB231.Points.Add(new Point(minX + Eb2, minY + Lb2, niv3Z));
                Polygon PolygonB232 = new Polygon();
                PolygonB232.Points.Add(new Point(maxX + Eb2, minY + Lb2, niv2Z));
                PolygonB232.Points.Add(new Point(maxX + Eb2, minY, niv2Z));
                PolygonB232.Points.Add(new Point(maxX + Eb2, minY, niv3Z));
                PolygonB232.Points.Add(new Point(maxX + Eb2, minY + Lb2, niv3Z));

                Polygon PolygonB233 = new Polygon();
                PolygonB233.Points.Add(new Point(minX + Eb2, maxY - Lb2, niv2Z));
                PolygonB233.Points.Add(new Point(minX + Eb2, maxY, niv2Z));
                PolygonB233.Points.Add(new Point(minX + Eb2, maxY, niv3Z));
                PolygonB233.Points.Add(new Point(minX + Eb2, maxY - Lb2, niv3Z));
                Polygon PolygonB234 = new Polygon();
                PolygonB234.Points.Add(new Point(maxX + Eb2, maxY - Lb2, niv2Z));
                PolygonB234.Points.Add(new Point(maxX + Eb2, maxY, niv2Z));
                PolygonB234.Points.Add(new Point(maxX + Eb2, maxY, niv3Z));
                PolygonB234.Points.Add(new Point(maxX + Eb2, maxY - Lb2, niv3Z));

                // Armering längs med sidorna + tillhörande byglar
                Polygon PolygonS11 = new Polygon();
                PolygonS11.Points.Add(new Point(minX, minY, sidaZ1));
                PolygonS11.Points.Add(new Point(maxX, minY, sidaZ1));
                Polygon PolygonS12 = new Polygon();
                PolygonS12.Points.Add(new Point(minX, minY, sidaZ2));
                PolygonS12.Points.Add(new Point(maxX, minY, sidaZ2));

                Polygon PolygonS21 = new Polygon();
                PolygonS21.Points.Add(new Point(minX, maxY, sidaZ1));
                PolygonS21.Points.Add(new Point(maxX, maxY, sidaZ1));
                Polygon PolygonS22 = new Polygon();
                PolygonS22.Points.Add(new Point(minX, maxY, sidaZ2));
                PolygonS22.Points.Add(new Point(maxX, maxY, sidaZ2));

                Polygon PolygonS31 = new Polygon();
                PolygonS31.Points.Add(new Point(maxX, minY, sidaZ1));
                PolygonS31.Points.Add(new Point(maxX, maxY, sidaZ1));
                Polygon PolygonS32 = new Polygon();
                PolygonS32.Points.Add(new Point(maxX, minY, sidaZ2));
                PolygonS32.Points.Add(new Point(maxX, maxY, sidaZ2));

                Polygon PolygonS41 = new Polygon();
                PolygonS41.Points.Add(new Point(minX, minY, sidaZ1));
                PolygonS41.Points.Add(new Point(minX, maxY, sidaZ1));
                Polygon PolygonS42 = new Polygon();
                PolygonS42.Points.Add(new Point(minX, minY, sidaZ2));
                PolygonS42.Points.Add(new Point(minX, maxY, sidaZ2));
                Polygon PolygonSB131 = new Polygon();
                PolygonSB131.Points.Add(new Point(maxX - Lbs3, minY, sidaZ1 + Eb3));
                PolygonSB131.Points.Add(new Point(maxX, minY, sidaZ1 + Eb3));
                PolygonSB131.Points.Add(new Point(maxX, minY + Lbs3, sidaZ1 + Eb3));
                Polygon PolygonSB132 = new Polygon();
                PolygonSB132.Points.Add(new Point(maxX - Lbs3, minY, sidaZ2 + Eb3));
                PolygonSB132.Points.Add(new Point(maxX, minY, sidaZ2 + Eb3));
                PolygonSB132.Points.Add(new Point(maxX, minY + Lbs3, sidaZ2 + Eb3));

                Polygon PolygonSB321 = new Polygon();
                PolygonSB321.Points.Add(new Point(maxX, maxY - Lbs3, sidaZ1 + Eb3));
                PolygonSB321.Points.Add(new Point(maxX, maxY, sidaZ1 + Eb3));
                PolygonSB321.Points.Add(new Point(maxX - Lbs3, maxY, sidaZ1 + Eb3));
                Polygon PolygonSB322 = new Polygon();
                PolygonSB322.Points.Add(new Point(maxX, maxY - Lbs3, sidaZ2 + Eb3));
                PolygonSB322.Points.Add(new Point(maxX, maxY, sidaZ2 + Eb3));
                PolygonSB322.Points.Add(new Point(maxX - Lbs3, maxY, sidaZ2 + Eb3));

                Polygon PolygonSB241 = new Polygon();
                PolygonSB241.Points.Add(new Point(minX + Lbs3, maxY, sidaZ1 + Eb3));
                PolygonSB241.Points.Add(new Point(minX, maxY, sidaZ1 + Eb3));
                PolygonSB241.Points.Add(new Point(minX, maxY - Lbs3, sidaZ1 + Eb3));
                Polygon PolygonSB242 = new Polygon();
                PolygonSB242.Points.Add(new Point(minX + Lbs3, maxY, sidaZ2 + Eb3));
                PolygonSB242.Points.Add(new Point(minX, maxY, sidaZ2 + Eb3));
                PolygonSB242.Points.Add(new Point(minX, maxY - Lbs3, sidaZ2 + Eb3));

                Polygon PolygonSB411 = new Polygon();
                PolygonSB411.Points.Add(new Point(minX, minY + Lbs3, sidaZ1 + Eb3));
                PolygonSB411.Points.Add(new Point(minX, minY, sidaZ1 + Eb3));
                PolygonSB411.Points.Add(new Point(minX+ Lbs3, minY, sidaZ1 + Eb3));
                Polygon PolygonSB412 = new Polygon();
                PolygonSB412.Points.Add(new Point(minX, minY + Lbs3, sidaZ2 + Eb3));
                PolygonSB412.Points.Add(new Point(minX, minY, sidaZ2 + Eb3));
                PolygonSB412.Points.Add(new Point(minX + Lbs3, minY, sidaZ2 + Eb3));

                RebarGroup RebarGroup = new RebarGroup();
                RebarGroup.RadiusValues.Add(40.0);
                RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
                RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
                RebarGroup.Father = platta;
                RebarGroup.Class = 3;
                RebarGroup.Size = "12";
                RebarGroup.NumberingSeries.StartNumber = 0;
                RebarGroup.NumberingSeries.Prefix = "Group";
                //RebarGroup.StartHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
                //RebarGroup.StartHook.Angle = -90;
                //RebarGroup.StartHook.Length = 3;
                //RebarGroup.StartHook.Radius = 20;
                //RebarGroup.EndHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
                //RebarGroup.EndHook.Angle = -90;
                //RebarGroup.EndHook.Length = 3;
                //RebarGroup.EndHook.Radius = 20;
                //RebarGroup.OnPlaneOffsets.Add(25.0);
                //RebarGroup.OnPlaneOffsets.Add(10.0);
                //RebarGroup.OnPlaneOffsets.Add(25.0);
                //RebarGroup.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                //RebarGroup.StartPointOffsetValue = 20;
                //RebarGroup.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
                //RebarGroup.EndPointOffsetValue = 60;
                //RebarGroup.FromPlaneOffset = 40;

                // Huvudarmering
                RebarGroup.Name = ajrn;
                RebarGroup.Spacings.Clear();
                RebarGroup.Spacings.Add(C1);
                RebarGroup.Grade = dim1k;
                RebarGroup.Size = dim1.ToString();
                RebarGroup.Polygons.Add(PolygonL11);
                RebarGroup.Polygons.Add(PolygonL12);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonL41);
                RebarGroup.Polygons.Add(PolygonL42);
                RebarGroup.Insert();

                RebarGroup.Spacings.Clear();
                RebarGroup.Spacings.Add(C2);
                RebarGroup.Grade = dim2k;
                RebarGroup.Size = dim2.ToString();
                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonL21);
                RebarGroup.Polygons.Add(PolygonL22);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonL31);
                RebarGroup.Polygons.Add(PolygonL32);
                RebarGroup.Insert();

                RebarGroup.Name = cjrn;
                RebarGroup.Spacings.Clear();
                RebarGroup.Spacings.Add(C1);
                RebarGroup.Grade = dimb1k;
                RebarGroup.Size = dimb1.ToString();
                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonB141);
                RebarGroup.Polygons.Add(PolygonB142);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonB143);
                RebarGroup.Polygons.Add(PolygonB144);
                RebarGroup.Insert();

                RebarGroup.Spacings.Clear();
                RebarGroup.Spacings.Add(C2);
                RebarGroup.Grade = dimb2k;
                RebarGroup.Size = dimb2.ToString();
                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonB231);
                RebarGroup.Polygons.Add(PolygonB232);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonB233);
                RebarGroup.Polygons.Add(PolygonB234);
                RebarGroup.Insert();

                // Armering sidor
                RebarGroup.Name = ajrn;
                RebarGroup.Spacings.Clear();
                RebarGroup.Spacings.Add(C3);
                RebarGroup.Grade = Dim3k;
                RebarGroup.Size = Dim3.ToString();
                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonS11);
                RebarGroup.Polygons.Add(PolygonS12);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonS21);
                RebarGroup.Polygons.Add(PolygonS22);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonS31);
                RebarGroup.Polygons.Add(PolygonS32);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonS41);
                RebarGroup.Polygons.Add(PolygonS42);
                RebarGroup.Insert();

                RebarGroup.Name = cjrn;
                RebarGroup.Grade = Dimb3k;
                RebarGroup.Size = Dimb3.ToString();
                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonSB131);
                RebarGroup.Polygons.Add(PolygonSB132);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonSB321);
                RebarGroup.Polygons.Add(PolygonSB322);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonSB241);
                RebarGroup.Polygons.Add(PolygonSB242);
                RebarGroup.Insert();

                RebarGroup.Polygons.Clear();
                RebarGroup.Polygons.Add(PolygonSB411);
                RebarGroup.Polygons.Add(PolygonSB412);
                RebarGroup.Insert();

                minModel.CommitChanges();
            }
            return status;
        }

        private bool SkapaPlintar() 
        {
            Model minModel = new Model();
            bool status = true;
            string kvb = inpla["KvalBk"];

            if (minModel.GetConnectionStatus())
            {
                foreach (var k in inplint)
                {
                    status = SkapaPlint(k, kvb, minModel);
                }

            }
            return status;
        }

        private bool SkapaPlint(Dictionary<string, dynamic> indata,string bkvalitet, Model minModel) 
        {
            bool status = true;
            var dx = inpla["L"] * 0 + 10000.0;
            var dy = inpla["B"] * 0 + 10000.0;
            var vp = indata["Vp"];
            var hp = indata["Hp"];
            var bp = indata["Bp"];
            var lp = indata["Lp"];
            var l2p = indata["L2p"];
            var xp = indata["Xp"] + dx;
            var yp = indata["Yp"]+ dy;
            var bgs1 = indata["Bgs1"];
            var bgs2 = indata["Bgs2"];
            var lgsu = indata["Lgsu"];
            var lgso = indata["Lgso"];
            var t = inpla["T"];
            var tsu = inpla["Ts1"];
            var tsp = inpla["Ts3"];
            var dim1 = inpla["Dim1d"];
            var dim2 = inpla["Dim2d"];

            var dimp1 = indata["Dimp1d"];
            var dimp2 = indata["Dimp2d"];
            var dimp1k = indata["Dimp1k"];
            var dimp2k = indata["Dimp2k"];
            var cmin1 = indata["cminp1"];
            var cmin2 = indata["cminp2"];
            var laf = indata["Laf"];
            var dimpb1 = indata["Dimpb1d"];
            var dimpb1k = indata["Dimpb1k"];

            string cjrn = data_rit["C-jarn"];
            string grskr = data_rit["grskr"];
            string jrn1 = data_rit["A-jarn"];
            string jrn2 = data_rit["A-jarn"];
            if (laf>0) 
            {
                jrn1 = data_rit["B-jarn"];
                jrn2 = data_rit["B-jarn"];
                if (l2p> lp) { jrn2 = data_rit["D-jarn"]; }
            
            }

            var ebpl = indata["Ebpl"];
            int lbpl1 = 120;







            if (inpla["Akt1"] != true) { dim1 = 0; }
            if (inpla["Akt2"] != true) { dim2 = 0; }

            if (indata["valApl"]) 
            {
                xp = indata["Ap"] * Math.Cos(vp * Math.PI / 180) + dx;
                yp = indata["Ap"] * Math.Sin(vp * Math.PI / 180)+ dy;
            }
            var xmi = Math.Cos(vp * Math.PI / 180) * (lp - l2p) / 2 + xp;
            var ymi = Math.Sin(vp * Math.PI / 180) * (lp - l2p) / 2 + yp;

            Beam nyplint = new Beam();
            nyplint.Name = "PLINT";
            nyplint.Profile.ProfileString = bp.ToString() + "*" + l2p.ToString();
            nyplint.Material.MaterialString = bkvalitet;
            //nyplint.Class = "8";
            nyplint.StartPoint.X = xmi;
            nyplint.StartPoint.Y = ymi;
            nyplint.StartPoint.Z = 0.0;
            nyplint.EndPoint.X = xmi;
            nyplint.EndPoint.Y = ymi;
            nyplint.EndPoint.Z = hp;
            nyplint.Position.Plane = Position.PlaneEnum.MIDDLE;
            nyplint.Position.Depth = Position.DepthEnum.MIDDLE;
            nyplint.Position.Rotation = Position.RotationEnum.BACK;
            nyplint.Position.RotationOffset = vp;
            nyplint.Insert();

            // Byter från global koordinatsystem till lokalt koordinatsystem
            // glob x,y,z = lok z,-y,x
            TransformationPlane currentPlane = minModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            TransformationPlane localPlane = new TransformationPlane(nyplint.GetCoordinateSystem());
            minModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(localPlane);

            CutPlane CutPlane = new CutPlane();
            CutPlane.Plane = new Plane();
            CutPlane.Plane.Origin = new Point(hp, 0, l2p / 2 - lp);
            CutPlane.Plane.AxisX = new Vector(0, -1, 0);
            CutPlane.Plane.AxisY = new Vector(-hp, 0, lp - l2p);
            CutPlane.Father = nyplint;  
            CutPlane.Insert();

            // Grundskruvar
            SingleRebar bar = new SingleRebar();
            bar.Father = nyplint;
            bar.Size = dimp1.ToString();
            bar.Grade = dimp1k;
            bar.OnPlaneOffsets.Add(0.0);  // please note the data type has to be 'double'
            bar.FromPlaneOffset = 0.0;
            bar.Name = grskr;
            bar.Class = 7;
            //bar.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            //bar.EndPointOffsetValue = 25.0;
            //bar.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            //bar.StartPointOffsetValue = 25.0;

            bar.Polygon.Points.Add(new Point(hp + lgso, bgs1 / 2, l2p / 2 - lp / 2 + bgs2 / 2));
            bar.Polygon.Points.Add(new Point(hp - lgsu, bgs1 / 2, l2p / 2 - lp / 2 + bgs2 / 2));
            bar.Insert();
            bar.Polygon.Points.Clear();
            bar.Polygon.Points.Add(new Point(hp + lgso, -bgs1 / 2, l2p / 2 - lp / 2 + bgs2 / 2));
            bar.Polygon.Points.Add(new Point(hp - lgsu, -bgs1 / 2, l2p / 2 - lp / 2 + bgs2 / 2));
            bar.Insert();
            bar.Polygon.Points.Clear();
            bar.Polygon.Points.Add(new Point(hp + lgso, -bgs1 / 2, l2p / 2 - lp / 2 - bgs2 / 2));
            bar.Polygon.Points.Add(new Point(hp - lgsu, -bgs1 / 2, l2p / 2 - lp / 2 - bgs2 / 2));
            bar.Insert();
            bar.Polygon.Points.Clear();
            bar.Polygon.Points.Add(new Point(hp + lgso, bgs1 / 2, l2p / 2 - lp / 2 - bgs2 / 2));
            bar.Polygon.Points.Add(new Point(hp - lgsu, bgs1 / 2, l2p / 2 - lp / 2 - bgs2 / 2));
            bar.Insert();

            // Huvudarmering
            // glob x,y,z = lok z,-y,x
            Polygon PolygonHA11 = new Polygon();
            PolygonHA11.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - tsp));
            PolygonHA11.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - tsp));
            PolygonHA11.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - tsp + laf));
            Polygon PolygonHA12 = new Polygon();
            PolygonHA12.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - tsp));
            PolygonHA12.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - tsp));
            PolygonHA12.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - tsp + laf));

            Polygon PolygonHA21 = new Polygon();
            PolygonHA21.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - tsp));
            PolygonHA21.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - tsp));
            PolygonHA21.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp + laf, l2p / 2 - tsp));
            Polygon PolygonHA22 = new Polygon();
            PolygonHA22.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - lp + tsp));
            PolygonHA22.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - lp + tsp));
            PolygonHA22.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp + laf, l2p / 2 - lp + tsp));

            Polygon PolygonHA31 = new Polygon();
            PolygonHA31.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - tsp));
            PolygonHA31.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - tsp));
            PolygonHA31.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp - laf, l2p / 2 - tsp));
            Polygon PolygonHA32 = new Polygon();
            PolygonHA32.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - lp + tsp));
            PolygonHA32.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - lp + tsp));
            PolygonHA32.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp - laf, l2p / 2 - lp + tsp));

            double lutx = 0;
            if (lp<l2p) 
            {
                lutx = Convert.ToDouble((hp - tsp - (-t + dim1 + dim2 + dimp2 / 2))) * Convert.ToDouble(l2p - lp) / hp;
            }

            Polygon PolygonHA41 = new Polygon();
            PolygonHA41.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - lp + tsp));
            PolygonHA41.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - lp + tsp - lutx));
            PolygonHA41.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, bp / 2 - tsp, l2p / 2 - lp + tsp - lutx - laf));
            Polygon PolygonHA42 = new Polygon();
            PolygonHA42.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - lp + tsp));
            PolygonHA42.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - lp + tsp - lutx));
            PolygonHA42.Points.Add(new Point(-t + tsu + dim1 + dim2 + dimp2 / 2, -bp / 2 + tsp, l2p / 2 - lp + tsp - lutx - laf));

            // glob x,y,z = lok z,-y,x
            double lutxb = 0;
            double lutzb = lbpl1;
            double tmpL = 1;
            if (lp < l2p)
            {
                tmpL = Math.Sqrt(Convert.ToDouble(hp*hp+ (l2p - lp)*(l2p - lp)));
                lutxb = lbpl1* Convert.ToDouble(l2p - lp)/ tmpL;
                lutzb = lbpl1 * Convert.ToDouble(hp) / tmpL;
            }


            Polygon PolygonHB141 = new Polygon();
            PolygonHB141.Points.Add(new Point(hp - tsp - lutzb, bp / 2 - tsp - ebpl, l2p / 2 - tsp));
            PolygonHB141.Points.Add(new Point(hp - tsp, bp / 2 - tsp - ebpl, l2p / 2 - tsp));
            PolygonHB141.Points.Add(new Point(hp - tsp, bp / 2 - tsp - ebpl, l2p / 2 - lp + tsp));
            PolygonHB141.Points.Add(new Point(hp - tsp - lutzb, bp / 2 - tsp - ebpl, l2p / 2 - lp + tsp - lutxb));
            Polygon PolygonHB142 = new Polygon();
            PolygonHB142.Points.Add(new Point(hp - tsp - lutzb, -bp / 2 + tsp - ebpl, l2p / 2 - tsp));
            PolygonHB142.Points.Add(new Point(hp - tsp, -bp / 2 + tsp - ebpl, l2p / 2 - tsp));
            PolygonHB142.Points.Add(new Point(hp - tsp, -bp / 2 + tsp - ebpl, l2p / 2 - lp + tsp));
            PolygonHB142.Points.Add(new Point(hp - tsp - lutzb, -bp / 2 + tsp - ebpl, l2p / 2 - lp + tsp - lutxb));

            Polygon PolygonHB231 = new Polygon();
            PolygonHB231.Points.Add(new Point(hp - tsp - lbpl1, -bp / 2 + tsp, l2p / 2 - tsp - ebpl));
            PolygonHB231.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - tsp - ebpl));
            PolygonHB231.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - tsp - ebpl));
            PolygonHB231.Points.Add(new Point(hp - tsp - lbpl1, bp / 2 - tsp, l2p / 2 - tsp - ebpl));
            Polygon PolygonHB232 = new Polygon();
            PolygonHB232.Points.Add(new Point(hp - tsp - lbpl1, -bp / 2 + tsp, l2p / 2 - lp + tsp - ebpl));
            PolygonHB232.Points.Add(new Point(hp - tsp, -bp / 2 + tsp, l2p / 2 - lp + tsp - ebpl));
            PolygonHB232.Points.Add(new Point(hp - tsp, bp / 2 - tsp, l2p / 2 - lp + tsp - ebpl));
            PolygonHB232.Points.Add(new Point(hp - tsp - lbpl1, bp / 2 - tsp, l2p / 2 - lp + tsp - ebpl));

            RebarGroup RebarGroup = new RebarGroup();
            RebarGroup.RadiusValues.Add(40.0);
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup.Father = nyplint;
            RebarGroup.Class = 3;
            RebarGroup.NumberingSeries.StartNumber = 0;
            RebarGroup.NumberingSeries.Prefix = "Group";

            // Huvudarmering
            RebarGroup.Name = jrn1;
            RebarGroup.Spacings.Clear();
            RebarGroup.Spacings.Add(cmin2);
            RebarGroup.Grade = dimp2k;
            RebarGroup.Size = dimp2.ToString();
            RebarGroup.Polygons.Add(PolygonHA11);
            RebarGroup.Polygons.Add(PolygonHA12);
            RebarGroup.Insert();

            RebarGroup.Name = jrn2;
            RebarGroup.Polygons.Clear();
            RebarGroup.Polygons.Add(PolygonHA41);
            RebarGroup.Polygons.Add(PolygonHA42);
            RebarGroup.Insert();

            RebarGroup.Name = jrn1;
            RebarGroup.Spacings.Clear();
            RebarGroup.Spacings.Add(cmin1);
            RebarGroup.Polygons.Clear();
            RebarGroup.Polygons.Add(PolygonHA21);
            RebarGroup.Polygons.Add(PolygonHA22);
            RebarGroup.Insert();

            RebarGroup.Polygons.Clear();
            RebarGroup.Polygons.Add(PolygonHA31);
            RebarGroup.Polygons.Add(PolygonHA32);
            RebarGroup.Insert();

            // Byglar, huvudarmering
            RebarGroup.Name = cjrn;
            RebarGroup.Grade = dimpb1k;
            RebarGroup.Size = dimpb1.ToString();
            RebarGroup.Polygons.Clear();
            RebarGroup.Polygons.Add(PolygonHB141);
            RebarGroup.Polygons.Add(PolygonHB142);
            RebarGroup.Insert();

            RebarGroup.Polygons.Clear();
            RebarGroup.Polygons.Add(PolygonHB231);
            RebarGroup.Polygons.Add(PolygonHB232);
            RebarGroup.Insert();

            // Byter tillbaka till globalt koordinatsystem
            minModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlane);
            minModel.CommitChanges();

            return status;
        }

        private void Tabortallt() 
        {
            Model minModel = new Model();
            if (minModel.GetConnectionStatus())
            {
                ModelObjectEnumerator mittEnum = minModel.GetModelObjectSelector().GetAllObjects();

                while (mittEnum.MoveNext())
                {
                    //mittEnum.Current.Delete();
                    if (mittEnum.Current is TSM.Part)
                    {
                        TSM.Part nyPart = mittEnum.Current as TSM.Part;
                        nyPart.Delete();
                    }
                }

            }
        }


    }

    //RebarGroup.StartHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
    //RebarGroup.StartHook.Angle = -90;
    //RebarGroup.StartHook.Length = 3;
    //RebarGroup.StartHook.Radius = 20;
    //RebarGroup.EndHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
    //RebarGroup.EndHook.Angle = -90;
    //RebarGroup.EndHook.Length = 3;
    //RebarGroup.EndHook.Radius = 20;
    //RebarGroup.OnPlaneOffsets.Add(25.0);
    //RebarGroup.OnPlaneOffsets.Add(10.0);
    //RebarGroup.OnPlaneOffsets.Add(25.0);
    //RebarGroup.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
    //RebarGroup.StartPointOffsetValue = 20;
    //RebarGroup.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
    //RebarGroup.EndPointOffsetValue = 60;
    //RebarGroup.FromPlaneOffset = 40;

    //ContourPoint p1 = new ContourPoint(new Point(xmitt + dx, ymitt + dy, -t / 2), null);
    //ContourPoint p2 = new ContourPoint(new Point(xmitt + dx, ymitt - dy, -t / 2), null);
    //ContourPoint p3 = new ContourPoint(new Point(xmitt - dx, ymitt - dy, -t / 2), null);
    //ContourPoint p4 = new ContourPoint(new Point(xmitt - dx, ymitt + dy, -t / 2), null);
    //ContourPlate platta = new ContourPlate();
    //platta.AddContourPoint(p1);
    //platta.AddContourPoint(p2);
    //platta.AddContourPoint(p3);
    //platta.AddContourPoint(p4);
    //platta.Profile.ProfileString = "PL" + t.ToString();

    //var xk = Math.Cos(vp * Math.PI / 180) * (-lp) / 2 + xp;
    //var yk = Math.Sin(vp * Math.PI / 180) * (-lp) / 2 + yp;
    //var xp1 = Math.Cos(vp * Math.PI / 180) * (lp/2 - l2p) + xp;
    //var yp1 = Math.Sin(vp * Math.PI / 180) * (lp/2 - l2p) + yp;
    //var xp2 = Math.Cos((vp + 90) * Math.PI / 180) * lp / 2 + xk;
    //var yp2 = Math.Sin((vp + 90) * Math.PI / 180) * lp / 2 + yk;
    //CutPlane.Plane.Origin = new Point(xk, yk, hp);
    //CutPlane.Plane.AxisX = new Vector(xp2 - xk, yp2 - yk, 0);
    //CutPlane.Plane.AxisY = new Vector(xp1 - xk, yp1 - yk, -hp);
}
