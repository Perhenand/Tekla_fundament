using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using proj1v1.Properties;

namespace proj1v1
{
    public partial class Form2 : Form
    {
        private Dictionary<string, dynamic> inpla = new Dictionary<string, dynamic>();
        private List<Dictionary<string, dynamic>> inplint = new List<Dictionary<string, dynamic>>();
        private bool status;
        private List<Namnvarde> dataKallaB = new List<Namnvarde>();
        private List<Armvarde> dataKallaHA = new List<Armvarde>();
        private List<Armvarde> dataKallaBA = new List<Armvarde>();
        private Dictionary<string, string> data_rit = new Dictionary<string, string>();


        public Form2(Dictionary<string, dynamic> data_platta_in, List<Dictionary<string, dynamic>> data_plint_in, bool status_indata, List<Namnvarde> dataB, List<Armvarde> dataHarm, List<Armvarde> dataBarm, Dictionary<string, string> data_rit_in)
        {
            InitializeComponent();
            inpla = data_platta_in;
            inplint = data_plint_in;
            status = status_indata;
            dataKallaB = dataB;
            dataKallaHA = dataHarm;
            dataKallaBA = dataBarm;
            data_rit = data_rit_in;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Bort dessa!
            //var dataKallaA = new List<Namnvarde>();
            //var armering = new List<Namnvarde>();
            //var armeringb = new List<Namnvarde>();
            //dataKallaA = ParamSam.Kvalitetarmering();
            //armering = ParamSam.Armeringdim();
            //armeringb = ParamSam.Armeringdim2();

            //listBoxKvalA.DataSource = dataKallaA;
            //listBoxKvalA.DisplayMember = "Value";
            //listBoxKvalA.ValueMember = "ID";
            //listBoxKvalA.SelectedValue = inpla["KvalA"];
            listBoxKvalB.DataSource = dataKallaB;
            listBoxKvalB.DisplayMember = "Value";
            listBoxKvalB.ValueMember = "ID";
            listBoxKvalB.SelectedValue = inpla["KvalB"];
            textBoxTs1.Text = inpla["Ts1"].ToString();
            textBoxTs2.Text = inpla["Ts2"].ToString();
            textBoxTs3.Text = inpla["Ts3"].ToString();
            textBoxL.Text = inpla["L"].ToString();
            textBoxB.Text = inpla["B"].ToString();
            textBoxT.Text = inpla["T"].ToString();
            
            Dim.DataSource = dataKallaHA;
            Dim.DisplayMember = "Varde1";
            Dim.ValueMember = "ID";
            Dim2.DataSource = dataKallaBA;
            Dim2.DisplayMember = "Varde1";
            Dim2.ValueMember = "ID";
            dataGridViewPlatta1.Rows.Add(inpla["Typ1"], inpla["Akt1"], inpla["Rikt1"], inpla["Dim1"], inpla["C1"], inpla["Dimb1"], inpla["Lb1"], inpla["Eb1"]);
            dataGridViewPlatta1.Rows.Add(inpla["Typ2"], inpla["Akt2"], inpla["Rikt2"], inpla["Dim2"], inpla["C2"], inpla["Dimb2"], inpla["Lb2"], inpla["Eb2"]);

            Dim3.DataSource = dataKallaHA;
            Dim3.DisplayMember = "Varde1";
            Dim3.ValueMember = "ID";
            Dim4.DataSource = dataKallaBA;
            Dim4.DisplayMember = "Varde1";
            Dim4.ValueMember = "ID";
            dataGridViewPlatta2.Rows.Add(inpla["Akt3"], inpla["Dim3"], inpla["C3"], inpla["Dimb3"], inpla["Lbs"], inpla["Ebs"]);

            Dimp1.DataSource = dataKallaHA;
            Dimp1.DisplayMember = "Varde1";
            Dimp1.ValueMember = "ID";
            Dimp2.DataSource = dataKallaHA;
            Dimp2.DisplayMember = "Varde1";
            Dimp2.ValueMember = "ID";
            Dimpb1.DataSource = dataKallaBA;
            Dimpb1.DisplayMember = "Varde1";
            Dimpb1.ValueMember = "ID";
            Nyrad1.Text = "+";
            Nyrad1.UseColumnTextForButtonValue = true;
            Tabortrad1.Text = "x";
            Tabortrad1.UseColumnTextForButtonValue = true;

            foreach (var k in inplint) 
            {
                dataGridPlint1.Rows.Add(k["Hp"], k["Bp"], k["Lp"], k["L2p"],
                    k["Vp"], k["valApl"], k["Ap"], k["Xp"], k["Yp"],
                    k["Dimp1"], k["Lgsu"], k["Lgso"], k["Bgs1"], k["Bgs2"],
                    k["Vgs"], k["Dimp2"], k["Dimpb1"], k["cminp1"], k["cminp2"],
                    k["Ebpl"], k["Laf"]);
            }

            for (int index = 0; index < dataGridPlint1.RowCount; index++) 
            {
                if (Convert.ToBoolean(dataGridPlint1.Rows[index].Cells[5].Value))
                {
                    dataGridPlint1.Rows[index].Cells[6].ReadOnly = false;
                    dataGridPlint1.Rows[index].Cells[7].ReadOnly = true;
                    dataGridPlint1.Rows[index].Cells[8].ReadOnly = true;
                    dataGridPlint1.Rows[index].Cells[6].Style.BackColor = Color.White;
                    dataGridPlint1.Rows[index].Cells[7].Style.BackColor = SystemColors.Control;
                    dataGridPlint1.Rows[index].Cells[8].Style.BackColor = SystemColors.Control;
                }
                else
                {
                    dataGridPlint1.Rows[index].Cells[6].ReadOnly = true;
                    dataGridPlint1.Rows[index].Cells[7].ReadOnly = false;
                    dataGridPlint1.Rows[index].Cells[8].ReadOnly = false;
                    dataGridPlint1.Rows[index].Cells[6].Style.BackColor = SystemColors.Control;
                    dataGridPlint1.Rows[index].Cells[7].Style.BackColor = Color.White;
                    dataGridPlint1.Rows[index].Cells[8].Style.BackColor = Color.White;
                }

            }



            for (int i = 0; i<2; i++) 
            {
                if (Convert.ToBoolean(dataGridViewPlatta1.Rows[i].Cells[1].Value) != true) 
                {
                    foreach (DataGridViewCell cell in dataGridViewPlatta1.Rows[i].Cells)
                    {
                        if (cell.ColumnIndex != 1)
                        {
                            cell.ReadOnly = true;
                            cell.Style.BackColor = SystemColors.Control;
                        }
                        else
                        {cell.Style.BackColor = SystemColors.Control;}
                    }
                }
            }

            if (Convert.ToBoolean(dataGridViewPlatta2.Rows[0].Cells[0].Value) != true)
            {
                foreach (DataGridViewCell cell in dataGridViewPlatta2.Rows[0].Cells)
                {
                    if (cell.ColumnIndex != 0)
                    {
                        cell.ReadOnly = true;
                        cell.Style.BackColor = SystemColors.Control;
                    }
                    else
                    {cell.Style.BackColor = SystemColors.Control;}
                }
            }
        }

        public Dictionary<string, dynamic> Data_platta 
        {
            get { return inpla; }
        }

        public List<Dictionary<string, dynamic>> Data_plint
        {
            get { return inplint; }
        }

        public bool Data_status
        {
            get { return status; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 objForm3 = new Form3();
            objForm3.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool tmp1;
            int tmp4;
            bool tmp3;

            status = true;

            inpla["KvalA"] = listBoxKvalA.SelectedValue;
            inpla["KvalB"] = listBoxKvalB.SelectedValue;
            tmp1 = int.TryParse(textBoxL.Text.ToString(), out tmp4);
            if (tmp1) { inpla["L"] = tmp4; }
            tmp1 = int.TryParse(textBoxB.Text.ToString(), out tmp4);
            if (tmp1) { inpla["B"] = tmp4; }
            tmp1 = int.TryParse(textBoxT.Text.ToString(), out tmp4);
            if (tmp1) { inpla["T"] = tmp4; }
            tmp1 = int.TryParse(textBoxTs1.Text.ToString(), out tmp4);
            if (tmp1) { inpla["Ts1"] = tmp4; }
            tmp1 = int.TryParse(textBoxTs2.Text.ToString(), out tmp4);
            if (tmp1) { inpla["Ts2"] = tmp4; }
            tmp1 = int.TryParse(textBoxTs3.Text.ToString(), out tmp4);
            if (tmp1) { inpla["Ts3"] = tmp4; }

            tmp1 = bool.TryParse(dataGridViewPlatta1.Rows[0].Cells[1].Value.ToString(), out tmp3);
            if (tmp1) { inpla["Akt1"] = tmp3; }
            tmp1 = bool.TryParse(dataGridViewPlatta1.Rows[1].Cells[1].Value.ToString(), out tmp3);
            if (tmp1) { inpla["Akt2"] = tmp3; }
            tmp1 = bool.TryParse(dataGridViewPlatta1.Rows[0].Cells[2].Value.ToString(), out tmp3);
            if (tmp1) { inpla["Rikt1"] = tmp3; }
            tmp1 = bool.TryParse(dataGridViewPlatta1.Rows[1].Cells[2].Value.ToString(), out tmp3);
            if (tmp1) { inpla["Rikt2"] = tmp3; }

            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[0].Cells[4].Value.ToString(), out tmp4);
            if (tmp1) { inpla["C1"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[1].Cells[4].Value.ToString(), out tmp4);
            if (tmp1) { inpla["C2"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[0].Cells[6].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Lb1"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[1].Cells[6].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Lb2"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[0].Cells[7].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Eb1"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[1].Cells[7].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Eb2"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[0].Cells[3].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dim1"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[1].Cells[3].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dim2"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[0].Cells[5].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dimb1"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta1.Rows[1].Cells[5].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dimb2"] = tmp4; }

            tmp1 = bool.TryParse(dataGridViewPlatta2.Rows[0].Cells[0].Value.ToString(), out tmp3);
            if (tmp1) { inpla["Akt3"] = tmp3; }
            tmp1 = int.TryParse(dataGridViewPlatta2.Rows[0].Cells[1].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dim3"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta2.Rows[0].Cells[2].Value.ToString(), out tmp4);
            if (tmp1) { inpla["C3"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta2.Rows[0].Cells[3].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Dimb3"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta2.Rows[0].Cells[4].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Lbs"] = tmp4; }
            tmp1 = int.TryParse(dataGridViewPlatta2.Rows[0].Cells[5].Value.ToString(), out tmp4);
            if (tmp1) { inpla["Ebs"] = tmp4; }

            inpla["Dim1k"] = dataKallaHA[inpla["Dim1"]].Varde2;
            inpla["Dim2k"] = dataKallaHA[inpla["Dim2"]].Varde2;
            inpla["Dim1d"] = dataKallaHA[inpla["Dim1"]].Varde3;
            inpla["Dim2d"] = dataKallaHA[inpla["Dim2"]].Varde3;
            inpla["Dimb1k"] = dataKallaBA[inpla["Dimb1"]].Varde2;
            inpla["Dimb2k"] = dataKallaBA[inpla["Dimb2"]].Varde2;
            inpla["Dimb1d"] = dataKallaBA[inpla["Dimb1"]].Varde3;
            inpla["Dimb2d"] = dataKallaBA[inpla["Dimb2"]].Varde3;
            inpla["Dim3k"] = dataKallaHA[inpla["Dim3"]].Varde2;
            inpla["Dim3d"] = dataKallaHA[inpla["Dim3"]].Varde3;
            inpla["Dimb3k"] = dataKallaBA[inpla["Dimb3"]].Varde2;
            inpla["Dimb3d"] = dataKallaBA[inpla["Dimb3"]].Varde3;

            inplint = new List<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> lex_tmp = new Dictionary<string, dynamic>();

            for (int index = 0; index < dataGridPlint1.RowCount; index++)
            {
                lex_tmp = new Dictionary<string, dynamic>();
                lex_tmp.Add("Hp", int.Parse(dataGridPlint1.Rows[index].Cells[0].Value.ToString()));
                lex_tmp.Add("Bp", int.Parse(dataGridPlint1.Rows[index].Cells[1].Value.ToString()));
                lex_tmp.Add("Lp", int.Parse(dataGridPlint1.Rows[index].Cells[2].Value.ToString()));
                lex_tmp.Add("L2p", int.Parse(dataGridPlint1.Rows[index].Cells[3].Value.ToString()));
                lex_tmp.Add("Vp", float.Parse(dataGridPlint1.Rows[index].Cells[4].Value.ToString()));
                lex_tmp.Add("valApl", Convert.ToBoolean(dataGridPlint1.Rows[index].Cells[5].Value));
                lex_tmp.Add("Ap", float.Parse(dataGridPlint1.Rows[index].Cells[6].Value.ToString()));
                lex_tmp.Add("Xp", float.Parse(dataGridPlint1.Rows[index].Cells[7].Value.ToString()));
                lex_tmp.Add("Yp", float.Parse(dataGridPlint1.Rows[index].Cells[8].Value.ToString()));
                lex_tmp.Add("Dimp1", int.Parse(dataGridPlint1.Rows[index].Cells[9].Value.ToString()));
                lex_tmp.Add("Lgsu", int.Parse(dataGridPlint1.Rows[index].Cells[10].Value.ToString()));
                lex_tmp.Add("Lgso", int.Parse(dataGridPlint1.Rows[index].Cells[11].Value.ToString()));
                lex_tmp.Add("Bgs1", int.Parse(dataGridPlint1.Rows[index].Cells[12].Value.ToString()));
                lex_tmp.Add("Bgs2", int.Parse(dataGridPlint1.Rows[index].Cells[13].Value.ToString()));
                lex_tmp.Add("Vgs", float.Parse(dataGridPlint1.Rows[index].Cells[14].Value.ToString()));
                lex_tmp.Add("Dimp2", int.Parse(dataGridPlint1.Rows[index].Cells[15].Value.ToString()));
                lex_tmp.Add("Dimpb1", int.Parse(dataGridPlint1.Rows[index].Cells[16].Value.ToString()));
                lex_tmp.Add("cminp1", int.Parse(dataGridPlint1.Rows[index].Cells[17].Value.ToString()));
                lex_tmp.Add("cminp2", int.Parse(dataGridPlint1.Rows[index].Cells[18].Value.ToString()));
                lex_tmp.Add("Ebpl", int.Parse(dataGridPlint1.Rows[index].Cells[19].Value.ToString()));
                lex_tmp.Add("Laf", int.Parse(dataGridPlint1.Rows[index].Cells[20].Value.ToString()));

                lex_tmp.Add("Dimp1k", dataKallaHA[lex_tmp["Dimp1"]].Varde2);
                lex_tmp.Add("Dimp1d", dataKallaHA[lex_tmp["Dimp1"]].Varde3);
                lex_tmp.Add("Dimp2k", dataKallaHA[lex_tmp["Dimp2"]].Varde2);
                lex_tmp.Add("Dimp2d", dataKallaHA[lex_tmp["Dimp2"]].Varde3);
                lex_tmp.Add("Dimpb1k", dataKallaBA[lex_tmp["Dimpb1"]].Varde2);
                lex_tmp.Add("Dimpb1d", dataKallaBA[lex_tmp["Dimpb1"]].Varde3);

                inplint.Add(lex_tmp);
            }
        }

        private void textBoxTs1_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxTs1.Text.ToString(), out tmp2);
            if (tmp1) 
            { 
                if (tmp2<0) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxTs1.Text = "0";
                e.Cancel = true;
            }
        }

        private void textBoxTs2_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxTs2.Text.ToString(), out tmp2);
            if (tmp1)
            {
                if (tmp2 < 0) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxTs2.Text = "0";
                e.Cancel = true;
            }
        }

        private void textBoxTs3_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxTs3.Text.ToString(), out tmp2);
            if (tmp1)
            {
                if (tmp2 < 0) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxTs3.Text = "0";
                e.Cancel = true;
            }
        }

        private void textBoxL_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxL.Text.ToString(), out tmp2);
            if (tmp1)
            {
                if (tmp2 < 100) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxL.Text = "100";
                e.Cancel = true;
            }
        }

        private void textBoxB_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxB.Text.ToString(), out tmp2);
            if (tmp1)
            {
                if (tmp2 < 100) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxB.Text = "100";
                e.Cancel = true;
            }
        }

        private void textBoxT_Validating(object sender, CancelEventArgs e)
        {
            bool tmp1;
            int tmp2;
            tmp1 = int.TryParse(textBoxT.Text.ToString(), out tmp2);
            if (tmp1)
            {
                if (tmp2 < 100) { tmp1 = false; }
            }
            if (tmp1 != true)
            {
                textBoxT.Text = "100";
                e.Cancel = true;
            }
        }

        private void dataGridViewPlatta1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            bool tmp1;
            int tmp2;

            if (rad != -1 && (kol == 4 || kol == 6 || kol == 7))
            {
                tmp1 = int.TryParse(dataGridViewPlatta1.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1)
                {
                    if (tmp2 < 1) { tmp1 = false; }
                }
                if (tmp1 != true)
                {
                    dataGridViewPlatta1.Rows[rad].Cells[kol].Value = "1";
                    //e.Cancel = true;
                }
            }
            else if (kol == 1 && rad != -1)
            {
                if (Convert.ToBoolean(dataGridViewPlatta1.Rows[rad].Cells[1].Value))
                {
                    foreach (DataGridViewCell cell in dataGridViewPlatta1.Rows[rad].Cells)
                    {
                        cell.ReadOnly = false;
                        cell.Style.BackColor = Color.White;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridViewPlatta1.Rows[rad].Cells)
                    {
                        if (cell.ColumnIndex != 1)
                        {
                            cell.ReadOnly = true;
                            cell.Style.BackColor = SystemColors.Control;
                        }
                        else
                        {
                            cell.Style.BackColor = SystemColors.Control;
                        }
                    }
                }

            }
            if (kol == 2 && rad != -1)
            {
                int tmp = 0;
                if (rad == 0) { tmp = 1; }
                bool varde = true;
                bool.TryParse(dataGridViewPlatta1.Rows[rad].Cells[2].Value.ToString(), out varde);
                if (varde) { varde = false; }
                else { varde = true; }
                dataGridViewPlatta1.Rows[tmp].Cells[2].Value = varde;
            }
        }

        private void dataGridViewPlatta2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            bool tmp1;
            int tmp2;

            if (rad != -1 && (kol == 2 || kol == 4 || kol == 5))
            {
                tmp1 = int.TryParse(dataGridViewPlatta2.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1)
                {
                    if (tmp2 < 1) { tmp1 = false; }
                }
                if (tmp1 != true)
                {
                    dataGridViewPlatta2.Rows[rad].Cells[kol].Value = "1";
                    //e.Cancel = true;
                }
            }
            else if (kol == 0 && rad != -1)
            {
                if (Convert.ToBoolean(dataGridViewPlatta2.Rows[0].Cells[0].Value))
                {
                    foreach (DataGridViewCell cell in dataGridViewPlatta2.Rows[0].Cells)
                    {
                        cell.ReadOnly = false;
                        cell.Style.BackColor = Color.White;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridViewPlatta2.Rows[0].Cells)
                    {
                        if (cell.ColumnIndex != 0)
                        {
                            cell.ReadOnly = true;
                            cell.Style.BackColor = SystemColors.Control;
                        }
                        else
                        { cell.Style.BackColor = SystemColors.Control; }
                    }
                }
            }
        }

        private void dataGridPlint1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            bool tmp1;
            float tmp2;
            int tmp4;

            if (kol == 5 && rad != -1)
            {
                if (Convert.ToBoolean(dataGridPlint1.Rows[rad].Cells[5].Value))
                {
                    dataGridPlint1.Rows[rad].Cells[6].ReadOnly = false;
                    dataGridPlint1.Rows[rad].Cells[7].ReadOnly = true;
                    dataGridPlint1.Rows[rad].Cells[8].ReadOnly = true;
                    dataGridPlint1.Rows[rad].Cells[6].Style.BackColor = Color.White;
                    dataGridPlint1.Rows[rad].Cells[7].Style.BackColor = SystemColors.Control;
                    dataGridPlint1.Rows[rad].Cells[8].Style.BackColor = SystemColors.Control;
                }
                else
                {
                    dataGridPlint1.Rows[rad].Cells[6].ReadOnly = true;
                    dataGridPlint1.Rows[rad].Cells[7].ReadOnly = false;
                    dataGridPlint1.Rows[rad].Cells[8].ReadOnly = false;
                    dataGridPlint1.Rows[rad].Cells[6].Style.BackColor = SystemColors.Control;
                    dataGridPlint1.Rows[rad].Cells[7].Style.BackColor = Color.White;
                    dataGridPlint1.Rows[rad].Cells[8].Style.BackColor = Color.White;
                }
            }
            else if(rad != -1 && (kol == 0 || kol == 1 || kol == 2 || kol == 3 ||  kol == 10 || kol == 11 || kol == 12 || kol == 13 || kol == 17 || kol == 18 || kol == 19))
            {
                tmp1 = int.TryParse(dataGridPlint1.Rows[rad].Cells[kol].Value.ToString(), out tmp4);
                if (tmp1)
                {
                    if (tmp4 < 1) { tmp1 = false; }
                }
                if (tmp1 != true) { dataGridPlint1.Rows[rad].Cells[kol].Value = "1";}
            }
            else if (rad != -1 && (kol == 4 || kol == 14) )
            {
                tmp1 = float.TryParse(dataGridPlint1.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1)
                {
                    if (tmp2 < 0) { dataGridPlint1.Rows[rad].Cells[kol].Value = "0"; }
                    else if (tmp2 > 360) { dataGridPlint1.Rows[rad].Cells[kol].Value = "360"; }
                }
                if (tmp1 != true) { dataGridPlint1.Rows[rad].Cells[kol].Value = "0";}
            }
            else if (rad != -1 && (kol == 6 || kol == 7 || kol == 8))
            {
                tmp1 = float.TryParse(dataGridPlint1.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1 != true) { dataGridPlint1.Rows[rad].Cells[kol].Value = "0"; }
            }
            else if (rad != -1 && kol == 20)
            {
                tmp1 = int.TryParse(dataGridPlint1.Rows[rad].Cells[kol].Value.ToString(), out tmp4);
                if (tmp1)
                {
                    if (tmp4 < 0) { tmp1 = false; }
                }
                if (tmp1 != true) { dataGridPlint1.Rows[rad].Cells[kol].Value = "0"; }
            }
        }

        private void dataGridPlint1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            if (rad != -1 && kol == 21)
            {
                DataGridViewRow gamrad = dataGridPlint1.Rows[e.RowIndex];
                DataGridViewRow nyrad = (DataGridViewRow)gamrad.Clone();
                for (Int32 index = 0; index < nyrad.Cells.Count; index++)
                {
                    nyrad.Cells[index].Value = gamrad.Cells[index].Value;
                }
                dataGridPlint1.Rows.Insert(e.RowIndex+1,nyrad);
            }
            else if (rad != -1 && kol == 22)
            {
                if (dataGridPlint1.RowCount > 1) { dataGridPlint1.Rows.Remove(dataGridPlint1.Rows[e.RowIndex]); }
            }
        }



        //private void dataGridPlint_KeyDown1(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        foreach (DataGridViewRow item in this.dataGridPlint1.SelectedRows)
        //        {
        //            dataGridPlint1.Rows.RemoveAt(item.Index);
        //        }
        //    }
        //}

        private void dataGridViewPlatta1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                dataGridViewPlatta1.EndEdit();
            }
        }

        private void dataGridViewPlatta2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                dataGridViewPlatta2.EndEdit();
            }
        }

        private void dataGridPlint_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                dataGridPlint1.EndEdit();
            }
        }
    }
}
