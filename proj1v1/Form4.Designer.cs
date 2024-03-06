namespace proj1v1
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridHarmering = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridBetong = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridBarmering = new System.Windows.Forms.DataGridView();
            this.armID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harmkval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armdim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nyrad1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Tabortrad1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.brmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brmnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barmkval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barmdim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.betID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.betongkvalitet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHarmering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBetong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBarmering)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridHarmering
            // 
            this.dataGridHarmering.AllowUserToAddRows = false;
            this.dataGridHarmering.AllowUserToDeleteRows = false;
            this.dataGridHarmering.AllowUserToResizeColumns = false;
            this.dataGridHarmering.AllowUserToResizeRows = false;
            this.dataGridHarmering.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridHarmering.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridHarmering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHarmering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.armID,
            this.armnam,
            this.harmkval,
            this.armdim,
            this.Nyrad1,
            this.Tabortrad1});
            this.dataGridHarmering.Location = new System.Drawing.Point(12, 42);
            this.dataGridHarmering.Name = "dataGridHarmering";
            this.dataGridHarmering.RowHeadersVisible = false;
            this.dataGridHarmering.RowHeadersWidth = 51;
            this.dataGridHarmering.RowTemplate.Height = 24;
            this.dataGridHarmering.Size = new System.Drawing.Size(428, 396);
            this.dataGridHarmering.TabIndex = 66;
            this.dataGridHarmering.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridArmering_CellClick);
            this.dataGridHarmering.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHarmering_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Armering";
            // 
            // dataGridBetong
            // 
            this.dataGridBetong.AllowUserToAddRows = false;
            this.dataGridBetong.AllowUserToDeleteRows = false;
            this.dataGridBetong.AllowUserToResizeColumns = false;
            this.dataGridBetong.AllowUserToResizeRows = false;
            this.dataGridBetong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridBetong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridBetong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBetong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.betID,
            this.betongkvalitet,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2});
            this.dataGridBetong.Location = new System.Drawing.Point(892, 42);
            this.dataGridBetong.Name = "dataGridBetong";
            this.dataGridBetong.RowHeadersVisible = false;
            this.dataGridBetong.RowHeadersWidth = 51;
            this.dataGridBetong.RowTemplate.Height = 24;
            this.dataGridBetong.Size = new System.Drawing.Size(288, 396);
            this.dataGridBetong.TabIndex = 68;
            this.dataGridBetong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridBetong.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBetong_CellValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(889, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Betong";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Armering";
            // 
            // dataGridBarmering
            // 
            this.dataGridBarmering.AllowUserToAddRows = false;
            this.dataGridBarmering.AllowUserToDeleteRows = false;
            this.dataGridBarmering.AllowUserToResizeColumns = false;
            this.dataGridBarmering.AllowUserToResizeRows = false;
            this.dataGridBarmering.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridBarmering.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridBarmering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBarmering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brmID,
            this.brmnam,
            this.barmkval,
            this.barmdim,
            this.dataGridViewButtonColumn3,
            this.dataGridViewButtonColumn4});
            this.dataGridBarmering.Location = new System.Drawing.Point(452, 42);
            this.dataGridBarmering.Name = "dataGridBarmering";
            this.dataGridBarmering.RowHeadersVisible = false;
            this.dataGridBarmering.RowHeadersWidth = 51;
            this.dataGridBarmering.RowTemplate.Height = 24;
            this.dataGridBarmering.Size = new System.Drawing.Size(428, 396);
            this.dataGridBarmering.TabIndex = 70;
            this.dataGridBarmering.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBarmering_CellClick);
            this.dataGridBarmering.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBarmering_CellValueChanged);
            // 
            // armID
            // 
            this.armID.HeaderText = "ID";
            this.armID.MinimumWidth = 6;
            this.armID.Name = "armID";
            this.armID.ReadOnly = true;
            this.armID.Visible = false;
            this.armID.Width = 125;
            // 
            // armnam
            // 
            this.armnam.HeaderText = "Namn";
            this.armnam.MinimumWidth = 6;
            this.armnam.Name = "armnam";
            this.armnam.Width = 90;
            // 
            // harmkval
            // 
            this.harmkval.HeaderText = "Kvalitet";
            this.harmkval.MinimumWidth = 6;
            this.harmkval.Name = "harmkval";
            this.harmkval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.harmkval.Width = 70;
            // 
            // armdim
            // 
            this.armdim.HeaderText = "D [mm]";
            this.armdim.MinimumWidth = 6;
            this.armdim.Name = "armdim";
            this.armdim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.armdim.Width = 40;
            // 
            // Nyrad1
            // 
            this.Nyrad1.HeaderText = "";
            this.Nyrad1.MinimumWidth = 6;
            this.Nyrad1.Name = "Nyrad1";
            this.Nyrad1.Text = "+";
            this.Nyrad1.UseColumnTextForButtonValue = true;
            this.Nyrad1.Width = 40;
            // 
            // Tabortrad1
            // 
            this.Tabortrad1.HeaderText = "";
            this.Tabortrad1.MinimumWidth = 6;
            this.Tabortrad1.Name = "Tabortrad1";
            this.Tabortrad1.Text = "x";
            this.Tabortrad1.UseColumnTextForButtonValue = true;
            this.Tabortrad1.Width = 40;
            // 
            // brmID
            // 
            this.brmID.HeaderText = "ID";
            this.brmID.MinimumWidth = 6;
            this.brmID.Name = "brmID";
            this.brmID.ReadOnly = true;
            this.brmID.Visible = false;
            this.brmID.Width = 125;
            // 
            // brmnam
            // 
            this.brmnam.HeaderText = "Namn";
            this.brmnam.MinimumWidth = 6;
            this.brmnam.Name = "brmnam";
            this.brmnam.Width = 90;
            // 
            // barmkval
            // 
            this.barmkval.HeaderText = "Kvalitet";
            this.barmkval.MinimumWidth = 6;
            this.barmkval.Name = "barmkval";
            this.barmkval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.barmkval.Width = 70;
            // 
            // barmdim
            // 
            this.barmdim.HeaderText = "D [mm]";
            this.barmdim.MinimumWidth = 6;
            this.barmdim.Name = "barmdim";
            this.barmdim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.barmdim.Width = 40;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.MinimumWidth = 6;
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "+";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 40;
            // 
            // dataGridViewButtonColumn4
            // 
            this.dataGridViewButtonColumn4.HeaderText = "";
            this.dataGridViewButtonColumn4.MinimumWidth = 6;
            this.dataGridViewButtonColumn4.Name = "dataGridViewButtonColumn4";
            this.dataGridViewButtonColumn4.Text = "x";
            this.dataGridViewButtonColumn4.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn4.Width = 40;
            // 
            // betID
            // 
            this.betID.HeaderText = "ID";
            this.betID.MinimumWidth = 6;
            this.betID.Name = "betID";
            this.betID.ReadOnly = true;
            this.betID.Visible = false;
            this.betID.Width = 125;
            // 
            // betongkvalitet
            // 
            this.betongkvalitet.HeaderText = "Kvalitet";
            this.betongkvalitet.MinimumWidth = 6;
            this.betongkvalitet.Name = "betongkvalitet";
            this.betongkvalitet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.betongkvalitet.Width = 60;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.MinimumWidth = 6;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "+";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 40;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.MinimumWidth = 6;
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "x";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 40;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridBarmering);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridBetong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridHarmering);
            this.Name = "Form4";
            this.Text = "Form4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHarmering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBetong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBarmering)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridHarmering;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridBetong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridBarmering;
        private System.Windows.Forms.DataGridViewTextBoxColumn armID;
        private System.Windows.Forms.DataGridViewTextBoxColumn armnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn harmkval;
        private System.Windows.Forms.DataGridViewTextBoxColumn armdim;
        private System.Windows.Forms.DataGridViewButtonColumn Nyrad1;
        private System.Windows.Forms.DataGridViewButtonColumn Tabortrad1;
        private System.Windows.Forms.DataGridViewTextBoxColumn betID;
        private System.Windows.Forms.DataGridViewTextBoxColumn betongkvalitet;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn brmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn brmnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn barmkval;
        private System.Windows.Forms.DataGridViewTextBoxColumn barmdim;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn4;
    }
}