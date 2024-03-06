using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj1v1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> data_rit1 = new Dictionary<string, string>();
        private Dictionary<string, dynamic> data_platta = new Dictionary<string, dynamic>();
        private List<Dictionary<string, dynamic>> data_plint = new List<Dictionary<string, dynamic>>();
        private bool status_indata;

        private List<Namnvarde> dataKallaB = new List<Namnvarde>();
        private List<Armvarde> dataKallaHA = new List<Armvarde>();
        private List<Armvarde> dataKallaBA = new List<Armvarde>();

        public Form1()
        {   
            InitializeComponent();
            dataKallaB = ParamSam.Betongkvaliteter();
            dataKallaHA = ParamSam.Harmering();
            dataKallaBA = ParamSam.Barmering();

            data_rit1.Add("A-jarn", "A-järn");
            data_rit1.Add("B-jarn", "B-järn");
            data_rit1.Add("C-jarn", "C-järn");
            data_rit1.Add("D-jarn", "D-järn");
            data_rit1.Add("N-jarn", "N-järn");
            data_rit1.Add("grskr", "Grundskruv");

            status_indata = true;
            data_platta.Add("KvalA", 1);
            data_platta.Add("KvalB", 5);
            data_platta.Add("KvalBk", dataKallaB[5].Value);
            data_platta.Add("L", 5000);
            data_platta.Add("B", 5000);
            data_platta.Add("T", 500);
            data_platta.Add("Ts1", 50);
            data_platta.Add("Ts2", 40);
            data_platta.Add("Ts3", 40);
            data_platta.Add("Typ1", "Lager 1, 4");
            data_platta.Add("Typ2", "Lager 2-3");
            data_platta.Add("Akt1", true);
            data_platta.Add("Akt2", true);
            data_platta.Add("Rikt1", true);
            data_platta.Add("Rikt2", false);
            data_platta.Add("Dim1", 6);
            data_platta.Add("Dim2", 5);
            data_platta.Add("Dim1k", dataKallaHA[6].Varde2);
            data_platta.Add("Dim2k", dataKallaHA[5].Varde2);
            data_platta.Add("Dim1d", dataKallaHA[6].Varde3);
            data_platta.Add("Dim2d", dataKallaHA[5].Varde3);
            data_platta.Add("C1", 250);
            data_platta.Add("C2", 300);
            data_platta.Add("Dimb1", 6);
            data_platta.Add("Dimb2", 5);
            data_platta.Add("Dimb1k", dataKallaBA[6].Varde2);
            data_platta.Add("Dimb2k", dataKallaBA[5].Varde2);
            data_platta.Add("Dimb1d", dataKallaBA[6].Varde3);
            data_platta.Add("Dimb2d", dataKallaBA[5].Varde3);
            data_platta.Add("Lb1", 500);
            data_platta.Add("Lb2", 400);
            data_platta.Add("Eb1", 20);
            data_platta.Add("Eb2", 20);
            data_platta.Add("Akt3", true);
            data_platta.Add("Dim3", 4);
            data_platta.Add("Dim3k", dataKallaHA[4].Varde2);
            data_platta.Add("Dim3d", dataKallaHA[4].Varde3);
            data_platta.Add("C3", 200);
            data_platta.Add("Dimb3", 4);
            data_platta.Add("Dimb3k", dataKallaBA[4].Varde2);
            data_platta.Add("Dimb3d", dataKallaBA[4].Varde3);
            data_platta.Add("Lbs", 400);
            data_platta.Add("Ebs", 14);

            Dictionary<string, dynamic> lex_tmp = new Dictionary<string, dynamic>();
            lex_tmp.Add("Hp", 950);
            lex_tmp.Add("Bp", 300);
            lex_tmp.Add("Lp", 300);
            lex_tmp.Add("L2p", 900);
            lex_tmp.Add("Vp", 45.5);
            lex_tmp.Add("valApl", false);
            lex_tmp.Add("Ap", 0.0);
            lex_tmp.Add("Xp", 1500.0);
            lex_tmp.Add("Yp", 1500.0);
            lex_tmp.Add("Dimp1", 8);
            lex_tmp.Add("Dimp1k", dataKallaHA[8].Varde2);
            lex_tmp.Add("Dimp1d", dataKallaHA[8].Varde3);
            lex_tmp.Add("Lgsu", 1300);
            lex_tmp.Add("Lgso", 150);
            lex_tmp.Add("Bgs1", 150);
            lex_tmp.Add("Bgs2", 150);
            lex_tmp.Add("Vgs", 12.5);
            lex_tmp.Add("Dimp2", 6);
            lex_tmp.Add("Dimp2k", dataKallaHA[6].Varde2);
            lex_tmp.Add("Dimp2d", dataKallaHA[6].Varde3);
            lex_tmp.Add("Dimpb1", 6);
            lex_tmp.Add("Dimpb1k", dataKallaBA[6].Varde2);
            lex_tmp.Add("Dimpb1d", dataKallaBA[6].Varde3);
            lex_tmp.Add("cminp1", 100);
            lex_tmp.Add("cminp2", 100);
            lex_tmp.Add("Ebpl", 20);
            lex_tmp.Add("Laf", 150);
            data_plint.Add(lex_tmp);
            Dictionary<string, dynamic> lex_tmp2 = new Dictionary<string, dynamic>(lex_tmp);
            lex_tmp2["valApl"] = false;
            lex_tmp2["Ap"] = 0.0;
            lex_tmp2["Xp"] = 1500.0;
            lex_tmp2["Yp"] = -1500.0;
            lex_tmp2["Vp"] = 315.0;
            data_plint.Add(lex_tmp2);
        }

        private void stängToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Projektbeskrivning")
            {
                textBox1.Text = "";
            }
        }

        private void knappGeometri_Click(object sender, EventArgs e)
        {
            using (Form2 objForm2 = new Form2(data_platta, data_plint, status_indata, dataKallaB, dataKallaHA, dataKallaBA, data_rit1)) 
            {
                objForm2.ShowDialog();
                data_platta = objForm2.Data_platta;
                data_plint = objForm2.Data_plint;
                status_indata = objForm2.Data_status;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtforareTekla utforareTekla = new UtforareTekla(data_platta, data_plint, data_rit1);
            utforareTekla.SkapaFund();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UtforareTekla utforareTekla = new UtforareTekla(data_platta, data_plint, data_rit1);
            utforareTekla.SkapaMatlista();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> harmref = new Dictionary<int, int>();
            Dictionary<int, int> barmref = new Dictionary<int, int>();
            Dictionary<int, int> betref = new Dictionary<int, int>();
            List<int> harmtyp = new List<int>();
            List<int> barmtyp = new List<int>();
            List<int> bettyp = new List<int>();
            bettyp.Add(data_platta["KvalB"]);
            harmtyp.Add(data_platta["Dim1"]);
            harmtyp.Add(data_platta["Dim2"]);
            harmtyp.Add(data_platta["Dim3"]);
            barmtyp.Add(data_platta["Dimb1"]);
            barmtyp.Add(data_platta["Dimb2"]);
            barmtyp.Add(data_platta["Dimb3"]);

            foreach (var k in data_plint)
            {
                harmtyp.Add(k["Dimp1"]);
                harmtyp.Add(k["Dimp2"]);
                barmtyp.Add(k["Dimpb1"]);
            }

            using (Form4 objForm4 = new Form4(dataKallaB, dataKallaHA, dataKallaBA, harmtyp, barmtyp, bettyp))
            {
                objForm4.ShowDialog();
                dataKallaB = objForm4.Data_betong;
                dataKallaHA = objForm4.Data_harm;
                dataKallaBA = objForm4.Data_barm;
                harmref = objForm4.Data_harmref;
                barmref = objForm4.Data_barmref;
                betref = objForm4.Data_betref;
            }
            data_platta["KvalB"] = betref[data_platta["KvalB"]];
            data_platta["Dim1"] = harmref[data_platta["Dim1"]];
            data_platta["Dim2"] = harmref[data_platta["Dim2"]];
            data_platta["Dim3"] = harmref[data_platta["Dim3"]];
            data_platta["Dimb1"] = barmref[data_platta["Dimb1"]];
            data_platta["Dimb2"] = barmref[data_platta["Dimb2"]];
            data_platta["Dimb3"] = barmref[data_platta["Dimb3"]];

            foreach (var k in data_plint)
            {
                k["Dimp1"] = harmref[k["Dimp1"]];
                k["Dimp2"] = harmref[k["Dimp2"]];
                k["Dimpb1"] = barmref[k["Dimpb1"]];
            }
        }

        private void knappUnderritning_Click(object sender, EventArgs e)
        {
            using (Form5 objForm5 = new Form5(data_rit1))
            {
                objForm5.ShowDialog();
                data_rit1 = objForm5.Data_rit;
            }
        }
    }
}
