namespace AppProgramming.MainForm
{
    partial class SuperMainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.cotizacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.top10AsesoresConMásCotizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Aquamarine;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cotizacionesToolStripMenuItem1,
            this.usersMenuItem,
            this.clientesToolStripMenuItem1,
            this.reportsMenuItem,
            this.salirToolStripMenuItem1,
            this.cerrarSesiónToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // cotizacionesToolStripMenuItem1
            // 
            this.cotizacionesToolStripMenuItem1.Image = global::AppProgramming.MainForm.Resources.e4awand_32_budget_report_wizard;
            this.cotizacionesToolStripMenuItem1.Name = "cotizacionesToolStripMenuItem1";
            this.cotizacionesToolStripMenuItem1.Size = new System.Drawing.Size(102, 20);
            this.cotizacionesToolStripMenuItem1.Text = "Cotizaciones";
            this.cotizacionesToolStripMenuItem1.Click += new System.EventHandler(this.cotizacionesToolStripMenuItem1_Click);
            // 
            // usersMenuItem
            // 
            this.usersMenuItem.Image = global::AppProgramming.MainForm.Resources.users_32;
            this.usersMenuItem.Name = "usersMenuItem";
            this.usersMenuItem.Size = new System.Drawing.Size(80, 20);
            this.usersMenuItem.Text = "Usuarios";
            this.usersMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Image = global::AppProgramming.MainForm.Resources.Users;
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(77, 20);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // reportsMenuItem
            // 
            this.reportsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.top10AsesoresConMásCotizacionesToolStripMenuItem,
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem});
            this.reportsMenuItem.Image = global::AppProgramming.MainForm.Resources.reports_32;
            this.reportsMenuItem.Name = "reportsMenuItem";
            this.reportsMenuItem.Size = new System.Drawing.Size(81, 20);
            this.reportsMenuItem.Text = "Reportes";
            this.reportsMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem1_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Image = global::AppProgramming.MainForm.Resources.logout;
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusUserName});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel.Text = "Usuario:";
            // 
            // toolStripStatusUserName
            // 
            this.toolStripStatusUserName.Name = "toolStripStatusUserName";
            this.toolStripStatusUserName.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusUserName.Text = "Admin";
            // 
            // top10AsesoresConMásCotizacionesToolStripMenuItem
            // 
            this.top10AsesoresConMásCotizacionesToolStripMenuItem.Name = "top10AsesoresConMásCotizacionesToolStripMenuItem";
            this.top10AsesoresConMásCotizacionesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.top10AsesoresConMásCotizacionesToolStripMenuItem.Text = "Top 10 asesores con más cotizaciones";
            this.top10AsesoresConMásCotizacionesToolStripMenuItem.Click += new System.EventHandler(this.top10AsesoresConMásCotizacionesToolStripMenuItem_Click);
            // 
            // tipoDePlanElegidoPorCiudadToolStripMenuItem
            // 
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem.Name = "tipoDePlanElegidoPorCiudadToolStripMenuItem";
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem.Text = "Tipo de plan elegido por ciudad";
            this.tipoDePlanElegidoPorCiudadToolStripMenuItem.Click += new System.EventHandler(this.tipoDePlanElegidoPorCiudadToolStripMenuItem_Click);
            // 
            // SuperMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SuperMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Integral de Seguros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem cotizacionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUserName;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem top10AsesoresConMásCotizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDePlanElegidoPorCiudadToolStripMenuItem;
    }
}



