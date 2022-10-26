
namespace LAB02_Install_o_tron
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UI_tool_load = new System.Windows.Forms.ToolStripButton();
            this.UI_btn_analize = new System.Windows.Forms.ToolStripButton();
            this.UI_cBox_Raw = new System.Windows.Forms.ToolStripComboBox();
            this.UI_cBox_package = new System.Windows.Forms.ToolStripComboBox();
            this.UI_dataGridView = new System.Windows.Forms.DataGridView();
            this.UI_lbl_drag = new System.Windows.Forms.Label();
            this.UI_sLbl_load = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_lbl_install = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_cLbl_uninstall = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_analzeTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_tool_load,
            this.UI_btn_analize,
            this.UI_cBox_Raw,
            this.UI_cBox_package});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1397, 63);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UI_tool_load
            // 
            this.UI_tool_load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_tool_load.Image = ((System.Drawing.Image)(resources.GetObject("UI_tool_load.Image")));
            this.UI_tool_load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_tool_load.Name = "UI_tool_load";
            this.UI_tool_load.Size = new System.Drawing.Size(185, 58);
            this.UI_tool_load.Text = "Load File";
            // 
            // UI_btn_analize
            // 
            this.UI_btn_analize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_btn_analize.Image = ((System.Drawing.Image)(resources.GetObject("UI_btn_analize.Image")));
            this.UI_btn_analize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_btn_analize.Name = "UI_btn_analize";
            this.UI_btn_analize.Size = new System.Drawing.Size(164, 58);
            this.UI_btn_analize.Text = "Analyze";
            // 
            // UI_cBox_Raw
            // 
            this.UI_cBox_Raw.AutoSize = false;
            this.UI_cBox_Raw.DropDownWidth = 200;
            this.UI_cBox_Raw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UI_cBox_Raw.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.UI_cBox_Raw.Name = "UI_cBox_Raw";
            this.UI_cBox_Raw.Size = new System.Drawing.Size(250, 62);
            this.UI_cBox_Raw.Text = "Raw Access";
            // 
            // UI_cBox_package
            // 
            this.UI_cBox_package.AutoSize = false;
            this.UI_cBox_package.DropDownWidth = 200;
            this.UI_cBox_package.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UI_cBox_package.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.UI_cBox_package.Name = "UI_cBox_package";
            this.UI_cBox_package.Size = new System.Drawing.Size(400, 62);
            this.UI_cBox_package.Text = "All Packages(Load)";
            // 
            // UI_dataGridView
            // 
            this.UI_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_dataGridView.Location = new System.Drawing.Point(12, 180);
            this.UI_dataGridView.Name = "UI_dataGridView";
            this.UI_dataGridView.RowHeadersWidth = 62;
            this.UI_dataGridView.RowTemplate.Height = 28;
            this.UI_dataGridView.Size = new System.Drawing.Size(1363, 423);
            this.UI_dataGridView.TabIndex = 1;
            // 
            // UI_lbl_drag
            // 
            this.UI_lbl_drag.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.UI_lbl_drag.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.UI_lbl_drag.Location = new System.Drawing.Point(12, 95);
            this.UI_lbl_drag.Name = "UI_lbl_drag";
            this.UI_lbl_drag.Size = new System.Drawing.Size(1353, 66);
            this.UI_lbl_drag.TabIndex = 2;
            this.UI_lbl_drag.Text = "Drop Files Here";
            this.UI_lbl_drag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_sLbl_load
            // 
            this.UI_sLbl_load.BackColor = System.Drawing.SystemColors.Highlight;
            this.UI_sLbl_load.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UI_sLbl_load.Name = "UI_sLbl_load";
            this.UI_sLbl_load.Size = new System.Drawing.Size(186, 32);
            this.UI_sLbl_load.Text = "Package Loaded";
            // 
            // UI_lbl_install
            // 
            this.UI_lbl_install.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.UI_lbl_install.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UI_lbl_install.Name = "UI_lbl_install";
            this.UI_lbl_install.Size = new System.Drawing.Size(225, 32);
            this.UI_lbl_install.Text = "Packages Installable";
            // 
            // UI_cLbl_uninstall
            // 
            this.UI_cLbl_uninstall.BackColor = System.Drawing.Color.IndianRed;
            this.UI_cLbl_uninstall.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UI_cLbl_uninstall.Name = "UI_cLbl_uninstall";
            this.UI_cLbl_uninstall.Size = new System.Drawing.Size(245, 32);
            this.UI_cLbl_uninstall.Text = "Package Uninstallable";
            // 
            // UI_analzeTime
            // 
            this.UI_analzeTime.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.UI_analzeTime.Name = "UI_analzeTime";
            this.UI_analzeTime.Size = new System.Drawing.Size(202, 32);
            this.UI_analzeTime.Text = "Analze Time <Not Run>";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_sLbl_load,
            this.UI_lbl_install,
            this.UI_cLbl_uninstall,
            this.UI_analzeTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1397, 39);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 693);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.UI_lbl_drag);
            this.Controls.Add(this.UI_dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UI_tool_load;
        private System.Windows.Forms.ToolStripButton UI_btn_analize;
        private System.Windows.Forms.ToolStripComboBox UI_cBox_Raw;
        private System.Windows.Forms.ToolStripComboBox UI_cBox_package;
        private System.Windows.Forms.DataGridView UI_dataGridView;
        private System.Windows.Forms.Label UI_lbl_drag;
        private System.Windows.Forms.ToolStripStatusLabel UI_sLbl_load;
        private System.Windows.Forms.ToolStripStatusLabel UI_lbl_install;
        private System.Windows.Forms.ToolStripStatusLabel UI_cLbl_uninstall;
        private System.Windows.Forms.ToolStripStatusLabel UI_analzeTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

