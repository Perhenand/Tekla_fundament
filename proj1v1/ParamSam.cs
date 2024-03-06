using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj1v1
{
    class ParamSam
    {
        //private static int aaa = 1;

        //public static int Aaa
        //{
        //    get { return aaa; }
        //    set { aaa = value; }
        //}
        
        public static List<Namnvarde> Betongkvaliteter()
        {
            var dataKalla = new List<Namnvarde>();
            dataKalla.Add(new Namnvarde() { ID = 0, Value = "C12/15" });
            dataKalla.Add(new Namnvarde() { ID = 1, Value = "C16/20" });
            dataKalla.Add(new Namnvarde() { ID = 2, Value = "C20/25" });
            dataKalla.Add(new Namnvarde() { ID = 3, Value = "C25/30" });
            dataKalla.Add(new Namnvarde() { ID = 4, Value = "C28/35" });
            dataKalla.Add(new Namnvarde() { ID = 5, Value = "C30/37" });
            dataKalla.Add(new Namnvarde() { ID = 6, Value = "C32/40" });
            dataKalla.Add(new Namnvarde() { ID = 7, Value = "C35/45" });
            dataKalla.Add(new Namnvarde() { ID = 8, Value = "C40/50" });
            dataKalla.Add(new Namnvarde() { ID = 9, Value = "C45/55" });
            dataKalla.Add(new Namnvarde() { ID = 10, Value = "C50/60" });
            dataKalla.Add(new Namnvarde() { ID = 11, Value = "C60/75" });
            return dataKalla;
        }

        public static List<Armvarde> Harmering()
        {
            var dataKalla = new List<Armvarde>();
            dataKalla.Add(new Armvarde() { ID = 0, Varde1 = "B500B_6", Varde2 = "B500B", Varde3 = 6 });
            dataKalla.Add(new Armvarde() { ID = 1, Varde1 = "B500B_8", Varde2 = "B500B", Varde3 = 8 });
            dataKalla.Add(new Armvarde() { ID = 2, Varde1 = "B500B_10", Varde2 = "B500B", Varde3 = 10 });
            dataKalla.Add(new Armvarde() { ID = 3, Varde1 = "B500B_12", Varde2 = "B500B", Varde3 = 12 });
            dataKalla.Add(new Armvarde() { ID = 4, Varde1 = "B500B_14", Varde2 = "B500B", Varde3 = 14 });
            dataKalla.Add(new Armvarde() { ID = 5, Varde1 = "B500B_16", Varde2 = "B500B", Varde3 = 16 });
            dataKalla.Add(new Armvarde() { ID = 6, Varde1 = "B500B_20", Varde2 = "B500B", Varde3 = 20 });
            dataKalla.Add(new Armvarde() { ID = 7, Varde1 = "B500B_25", Varde2 = "B500B", Varde3 = 25 });
            dataKalla.Add(new Armvarde() { ID = 8, Varde1 = "B500B_32", Varde2 = "B500B", Varde3 = 32 });
            return dataKalla;

        }

        public static List<Armvarde> Barmering()
        {
            var dataKalla = new List<Armvarde>();
            dataKalla.Add(new Armvarde() { ID = 0, Varde1 = "B500B_6", Varde2 = "B500B", Varde3 = 6 });
            dataKalla.Add(new Armvarde() { ID = 1, Varde1 = "B500B_8", Varde2 = "B500B", Varde3 = 8 });
            dataKalla.Add(new Armvarde() { ID = 2, Varde1 = "B500B_10", Varde2 = "B500B", Varde3 = 10 });
            dataKalla.Add(new Armvarde() { ID = 3, Varde1 = "B500B_12", Varde2 = "B500B", Varde3 = 12 });
            dataKalla.Add(new Armvarde() { ID = 4, Varde1 = "B500B_14", Varde2 = "B500B", Varde3 = 14 });
            dataKalla.Add(new Armvarde() { ID = 5, Varde1 = "B500B_16", Varde2 = "B500B", Varde3 = 16 });
            dataKalla.Add(new Armvarde() { ID = 6, Varde1 = "B500B_20", Varde2 = "B500B", Varde3 = 20 });
            dataKalla.Add(new Armvarde() { ID = 7, Varde1 = "B500B_25", Varde2 = "B500B", Varde3 = 25 });
            dataKalla.Add(new Armvarde() { ID = 8, Varde1 = "B500B_32", Varde2 = "B500B", Varde3 = 32 });
            return dataKalla;

        }

        public static List<Namnvarde> Kvalitetarmering() 
        {
            var dataKalla = new List<Namnvarde>();
            dataKalla.Add(new Namnvarde() { ID = 0, Value = "S235" });
            dataKalla.Add(new Namnvarde() { ID = 1, Value = "S355" });
            return dataKalla;

        }

        public static List<Namnvarde> Armeringdim() 
        {
            var dataKalla = new List<Namnvarde>();
            dataKalla.Add(new Namnvarde() { ID = 6, Value = "φ6" });
            dataKalla.Add(new Namnvarde() { ID = 8, Value = "φ8" });
            dataKalla.Add(new Namnvarde() { ID = 10, Value = "φ10" });
            dataKalla.Add(new Namnvarde() { ID = 12, Value = "φ12" });
            dataKalla.Add(new Namnvarde() { ID = 16, Value = "φ16" });
            dataKalla.Add(new Namnvarde() { ID = 20, Value = "φ20" });
            dataKalla.Add(new Namnvarde() { ID = 25, Value = "φ25" });
            dataKalla.Add(new Namnvarde() { ID = 32, Value = "φ32" });
            return dataKalla;
        }

        public static List<Namnvarde> Armeringdim2()
        {
            var dataKalla = new List<Namnvarde>();
            dataKalla.Add(new Namnvarde() { ID = 6, Value = "φ6" });
            dataKalla.Add(new Namnvarde() { ID = 8, Value = "φ8" });
            dataKalla.Add(new Namnvarde() { ID = 10, Value = "φ10" });
            dataKalla.Add(new Namnvarde() { ID = 12, Value = "φ12" });
            dataKalla.Add(new Namnvarde() { ID = 16, Value = "φ16" });
            dataKalla.Add(new Namnvarde() { ID = 20, Value = "φ20" });
            dataKalla.Add(new Namnvarde() { ID = 25, Value = "φ25" });
            dataKalla.Add(new Namnvarde() { ID = 32, Value = "φ32" });
            return dataKalla;
        }
    }

    public class Namnvarde 
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
    public class Armvarde
    {
        public int ID { get; set; }
        public string Varde1 { get; set; }
        public string Varde2 { get; set; }
        public double Varde3 { get; set; }
    }

}
