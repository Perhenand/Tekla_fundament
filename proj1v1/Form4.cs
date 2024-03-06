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
    public partial class Form4 : Form
    {

        private List<Namnvarde> dataKallaB = new List<Namnvarde>();
        private List<Armvarde> dataKallaHA = new List<Armvarde>();
        private List<Armvarde> dataKallaBA = new List<Armvarde>();
        private Dictionary<int, int> harmref = new Dictionary<int, int>();
        private Dictionary<int, int> barmref = new Dictionary<int, int>();
        private Dictionary<int, int> betref = new Dictionary<int, int>();
        private List<int> harmtyp = new List<int>();
        private List<int> barmtyp = new List<int>();
        private List<int> bettyp = new List<int>();

        public Form4(List<Namnvarde> dataB, List<Armvarde> dataHarm, List<Armvarde> dataBarm, List<int> harmnr, List<int> barmnr, List<int> betnr)
        {
            InitializeComponent();
            dataKallaB = dataB;
            dataKallaHA = dataHarm;
            dataKallaBA = dataBarm;
            harmtyp = harmnr;
            barmtyp = barmnr;
            bettyp = betnr;
        }

        public List<Namnvarde> Data_betong
        {
            get { return dataKallaB; }
        }

        public List<Armvarde> Data_harm
        {
            get { return dataKallaHA; }
        }

        public List<Armvarde> Data_barm
        {
            get { return dataKallaBA; }
        }

        public Dictionary<int, int> Data_harmref
        {
            get { return harmref; }
        }

        public Dictionary<int, int> Data_barmref
        {
            get { return barmref; }
        }

        public Dictionary<int, int> Data_betref
        {
            get { return betref; }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (var k in dataKallaB)
            {
                dataGridBetong.Rows.Add(k.ID, k.Value);
            }

            foreach (var k in dataKallaHA)
            {
                dataGridHarmering.Rows.Add(k.ID, k.Varde1, k.Varde2, k.Varde3);
            }

            foreach (var k in dataKallaBA)
            {
                dataGridBarmering.Rows.Add(k.ID, k.Varde1, k.Varde2, k.Varde3);
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataKallaHA = new List<Armvarde>();
            dataKallaBA = new List<Armvarde>();
            dataKallaB = new List<Namnvarde>();
            harmref = new Dictionary<int, int>();
            barmref = new Dictionary<int, int>();
            betref = new Dictionary<int, int>();

            int tmp1;
            string tmp2;
            string tmp3;
            double tmp4;

            for (int index = 0; index < dataGridHarmering.RowCount; index++)
            {
                tmp1 = int.Parse(dataGridHarmering.Rows[index].Cells[0].Value.ToString());
                tmp2 = dataGridHarmering.Rows[index].Cells[1].Value.ToString();
                tmp3 = dataGridHarmering.Rows[index].Cells[2].Value.ToString();
                tmp4 = double.Parse(dataGridHarmering.Rows[index].Cells[3].Value.ToString());
                dataKallaHA.Add(new Armvarde() { ID = index, Varde1 = tmp2, Varde2 = tmp3, Varde3 = tmp4 });
                harmref.Add(tmp1, index);
            }

            for (int index = 0; index < dataGridBarmering.RowCount; index++)
            {
                tmp1 = int.Parse(dataGridBarmering.Rows[index].Cells[0].Value.ToString());
                tmp2 = dataGridBarmering.Rows[index].Cells[1].Value.ToString();
                tmp3 = dataGridBarmering.Rows[index].Cells[2].Value.ToString();
                tmp4 = double.Parse(dataGridBarmering.Rows[index].Cells[3].Value.ToString());
                dataKallaBA.Add(new Armvarde() { ID = index, Varde1 = tmp2, Varde2 = tmp3, Varde3 = tmp4 });
                barmref.Add(tmp1, index);
            }

            for (int index = 0; index < dataGridBetong.RowCount; index++)
            {
                tmp1 = int.Parse(dataGridBetong.Rows[index].Cells[0].Value.ToString());
                tmp2 = dataGridBetong.Rows[index].Cells[1].Value.ToString();
                dataKallaB.Add(new Namnvarde() { ID = index, Value = tmp2 });
                betref.Add(tmp1, index);
            }

        }

        private void dataGridArmering_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            int ID = int.Parse(dataGridHarmering.Rows[rad].Cells[0].Value.ToString());

            if (rad != -1 && kol == 4)
            {
                DataGridViewRow gamrad = dataGridHarmering.Rows[e.RowIndex];
                DataGridViewRow nyrad = (DataGridViewRow)gamrad.Clone();
                for (Int32 index = 0; index < nyrad.Cells.Count; index++)
                {
                    nyrad.Cells[index].Value = gamrad.Cells[index].Value;
                }
                nyrad.Cells[0].Value = -1;
                dataGridHarmering.Rows.Insert(e.RowIndex + 1, nyrad);
            }
            else if (rad != -1 && kol == 5)
            {
                if (dataGridHarmering.RowCount > 1 && harmtyp.IndexOf(ID) == -1)
                {
                    dataGridHarmering.Rows.Remove(dataGridHarmering.Rows[e.RowIndex]);
                }
            }
        }

        private void dataGridBarmering_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            int ID = int.Parse(dataGridBarmering.Rows[rad].Cells[0].Value.ToString());
            if (rad != -1 && kol == 4)
            {
                DataGridViewRow gamrad = dataGridBarmering.Rows[e.RowIndex];
                DataGridViewRow nyrad = (DataGridViewRow)gamrad.Clone();
                for (Int32 index = 0; index < nyrad.Cells.Count; index++)
                {
                    nyrad.Cells[index].Value = gamrad.Cells[index].Value;
                }
                nyrad.Cells[0].Value = -1;
                dataGridBarmering.Rows.Insert(e.RowIndex + 1, nyrad);
            }
            else if (rad != -1 && kol == 5)
            {
                if (dataGridBarmering.RowCount > 1 && barmtyp.IndexOf(ID) == -1) 
                { 
                    dataGridBarmering.Rows.Remove(dataGridBarmering.Rows[e.RowIndex]); 
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            int ID = int.Parse(dataGridBetong.Rows[rad].Cells[0].Value.ToString());
            if (rad != -1 && kol == 2)
            {
                DataGridViewRow gamrad = dataGridBetong.Rows[e.RowIndex];
                DataGridViewRow nyrad = (DataGridViewRow)gamrad.Clone();
                for (Int32 index = 0; index < nyrad.Cells.Count; index++)
                {
                    nyrad.Cells[index].Value = gamrad.Cells[index].Value;
                }
                nyrad.Cells[0].Value = -1;
                dataGridBetong.Rows.Insert(e.RowIndex + 1, nyrad);
            }
            else if (rad != -1 && kol == 3)
            {
                if (dataGridBetong.RowCount > 1 && bettyp.IndexOf(ID) == -1) 
                { 
                    dataGridBetong.Rows.Remove(dataGridBetong.Rows[e.RowIndex]); 
                }
            }
        }

        private void dataGridHarmering_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            bool tmp1;
            double tmp2;

            if (rad != -1 && (kol == 1 || kol == 2))
            {
                if (dataGridHarmering.Rows[rad].Cells[kol].Value == null || dataGridHarmering.Rows[rad].Cells[kol].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridHarmering.Rows[rad].Cells[kol].Value.ToString())) 
                { dataGridHarmering.Rows[rad].Cells[kol].Value = "abc"; }
            }
            else if (rad != -1 && kol == 3)
            {
                tmp1 = double.TryParse(dataGridHarmering.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1)
                {if (tmp2 < 1) { tmp1 = false; }}
                if (tmp1 != true)
                {dataGridHarmering.Rows[rad].Cells[kol].Value = "1";}
            }
        }

        private void dataGridBarmering_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;
            bool tmp1;
            double tmp2;

            if (rad != -1 && (kol == 1 || kol == 2))
            {
                if (dataGridBarmering.Rows[rad].Cells[kol].Value == null || dataGridBarmering.Rows[rad].Cells[kol].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridBarmering.Rows[rad].Cells[kol].Value.ToString()))
                { dataGridBarmering.Rows[rad].Cells[kol].Value = "abc"; }
            }
            else if (rad != -1 && kol == 3)
            {
                tmp1 = double.TryParse(dataGridBarmering.Rows[rad].Cells[kol].Value.ToString(), out tmp2);
                if (tmp1)
                { if (tmp2 < 1) { tmp1 = false; } }
                if (tmp1 != true)
                { dataGridBarmering.Rows[rad].Cells[kol].Value = "1"; }
            }
        }

        private void dataGridBetong_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rad = e.RowIndex;
            int kol = e.ColumnIndex;

            if (rad != -1 && (kol == 1 || kol == 2))
            {
                if (dataGridBetong.Rows[rad].Cells[kol].Value == null || dataGridBetong.Rows[rad].Cells[kol].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridBetong.Rows[rad].Cells[kol].Value.ToString()))
                { dataGridBetong.Rows[rad].Cells[kol].Value = "abc"; }
            }
        }
    }
}
