namespace AppProgramming.MainForm
{
    partial class Customers
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.schFirstName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.schRFC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.schMothersName = new System.Windows.Forms.TextBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.schLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.schID = new System.Windows.Forms.TextBox();
            this.customersDataGrid = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGoBudget = new System.Windows.Forms.Button();
            this.lbSelectionLegend = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.schFirstName);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.btnClearSearch);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.schRFC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.schMothersName);
            this.groupBox3.Controls.Add(this.lbLastName);
            this.groupBox3.Controls.Add(this.schLastName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.schID);
            this.groupBox3.Location = new System.Drawing.Point(12, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(895, 82);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Búsqueda";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(248, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 15);
            this.label22.TabIndex = 38;
            this.label22.Text = "Nombre";
            // 
            // schFirstName
            // 
            this.schFirstName.BackColor = System.Drawing.Color.Azure;
            this.schFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schFirstName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schFirstName.ForeColor = System.Drawing.Color.DimGray;
            this.schFirstName.Location = new System.Drawing.Point(119, 19);
            this.schFirstName.Name = "schFirstName";
            this.schFirstName.Size = new System.Drawing.Size(169, 19);
            this.schFirstName.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(351, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 26);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearSearch.Location = new System.Drawing.Point(469, 50);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(93, 26);
            this.btnClearSearch.TabIndex = 7;
            this.btnClearSearch.Text = "Limpiar";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(857, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "RFC";
            // 
            // schRFC
            // 
            this.schRFC.BackColor = System.Drawing.Color.Azure;
            this.schRFC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schRFC.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schRFC.ForeColor = System.Drawing.Color.DimGray;
            this.schRFC.Location = new System.Drawing.Point(709, 19);
            this.schRFC.Name = "schRFC";
            this.schRFC.Size = new System.Drawing.Size(175, 19);
            this.schRFC.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(630, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Apellido M.";
            // 
            // schMothersName
            // 
            this.schMothersName.BackColor = System.Drawing.Color.Azure;
            this.schMothersName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schMothersName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schMothersName.ForeColor = System.Drawing.Color.DimGray;
            this.schMothersName.Location = new System.Drawing.Point(508, 19);
            this.schMothersName.Name = "schMothersName";
            this.schMothersName.Size = new System.Drawing.Size(175, 19);
            this.schMothersName.TabIndex = 4;
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastName.Location = new System.Drawing.Point(431, 19);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(51, 15);
            this.lbLastName.TabIndex = 30;
            this.lbLastName.Text = "Apellido P.";
            // 
            // schLastName
            // 
            this.schLastName.BackColor = System.Drawing.Color.Azure;
            this.schLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schLastName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schLastName.ForeColor = System.Drawing.Color.DimGray;
            this.schLastName.Location = new System.Drawing.Point(313, 19);
            this.schLastName.Name = "schLastName";
            this.schLastName.Size = new System.Drawing.Size(169, 19);
            this.schLastName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(83, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "ID";
            // 
            // schID
            // 
            this.schID.BackColor = System.Drawing.Color.Azure;
            this.schID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schID.ForeColor = System.Drawing.Color.DimGray;
            this.schID.Location = new System.Drawing.Point(6, 19);
            this.schID.Name = "schID";
            this.schID.Size = new System.Drawing.Size(92, 19);
            this.schID.TabIndex = 1;
            // 
            // customersDataGrid
            // 
            this.customersDataGrid.BackgroundColor = System.Drawing.Color.LightCyan;
            this.customersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersDataGrid.Location = new System.Drawing.Point(12, 142);
            this.customersDataGrid.Name = "customersDataGrid";
            this.customersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersDataGrid.Size = new System.Drawing.Size(895, 258);
            this.customersDataGrid.TabIndex = 8;
            this.customersDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customersDataGrid_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::AppProgramming.MainForm.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 36);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::AppProgramming.MainForm.Resources.edit_32x32;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.Location = new System.Drawing.Point(98, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(82, 36);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGoBudget
            // 
            this.btnGoBudget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGoBudget.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBudget.Image = global::AppProgramming.MainForm.Resources.Print;
            this.btnGoBudget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBudget.Location = new System.Drawing.Point(378, 422);
            this.btnGoBudget.Name = "btnGoBudget";
            this.btnGoBudget.Size = new System.Drawing.Size(163, 44);
            this.btnGoBudget.TabIndex = 34;
            this.btnGoBudget.Text = "Realizar cotización";
            this.btnGoBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBudget.UseVisualStyleBackColor = true;
            this.btnGoBudget.Click += new System.EventHandler(this.btnGoBudget_Click);
            // 
            // lbSelectionLegend
            // 
            this.lbSelectionLegend.AutoSize = true;
            this.lbSelectionLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectionLegend.Location = new System.Drawing.Point(202, 19);
            this.lbSelectionLegend.Name = "lbSelectionLegend";
            this.lbSelectionLegend.Size = new System.Drawing.Size(705, 22);
            this.lbSelectionLegend.TabIndex = 37;
            this.lbSelectionLegend.Text = "POR FAVOR SELECCIONE UN CLIENTE PARA PODER REALIZAR LA COTIZACIÓN";
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(919, 470);
            this.Controls.Add(this.lbSelectionLegend);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGoBudget);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.customersDataGrid);
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Customers_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox schRFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox schMothersName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.TextBox schLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox schID;
        private System.Windows.Forms.DataGridView customersDataGrid;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox schFirstName;
        private System.Windows.Forms.Button btnGoBudget;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lbSelectionLegend;



    }
}