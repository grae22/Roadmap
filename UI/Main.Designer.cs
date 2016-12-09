namespace Roadmapp.UI
{
  partial class Main
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.uiGoals = new System.Windows.Forms.ListBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.uiStrategies = new System.Windows.Forms.ListBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.uiRealisations = new System.Windows.Forms.ListBox();
      this.uiAddEntity = new System.Windows.Forms.Button();
      this.uiRemoveEntity = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.uiFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.uiFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.uiFileLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.flowLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.flowLayoutPanel1.Controls.Add(this.groupBox1);
      this.flowLayoutPanel1.Controls.Add(this.groupBox2);
      this.flowLayoutPanel1.Controls.Add(this.groupBox3);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(895, 455);
      this.flowLayoutPanel1.TabIndex = 1;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.uiGoals);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
      this.groupBox1.Size = new System.Drawing.Size(292, 452);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Goals:";
      // 
      // uiGoals
      // 
      this.uiGoals.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiGoals.FormattingEnabled = true;
      this.uiGoals.IntegralHeight = false;
      this.uiGoals.Location = new System.Drawing.Point(10, 23);
      this.uiGoals.Name = "uiGoals";
      this.uiGoals.Size = new System.Drawing.Size(272, 419);
      this.uiGoals.TabIndex = 0;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.uiStrategies);
      this.groupBox2.Location = new System.Drawing.Point(301, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
      this.groupBox2.Size = new System.Drawing.Size(292, 451);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Strategies:";
      // 
      // uiStrategies
      // 
      this.uiStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiStrategies.FormattingEnabled = true;
      this.uiStrategies.IntegralHeight = false;
      this.uiStrategies.Location = new System.Drawing.Point(10, 23);
      this.uiStrategies.Name = "uiStrategies";
      this.uiStrategies.Size = new System.Drawing.Size(272, 418);
      this.uiStrategies.TabIndex = 1;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.uiRealisations);
      this.groupBox3.Location = new System.Drawing.Point(599, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
      this.groupBox3.Size = new System.Drawing.Size(292, 451);
      this.groupBox3.TabIndex = 5;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Realisations:";
      // 
      // uiRealisations
      // 
      this.uiRealisations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiRealisations.FormattingEnabled = true;
      this.uiRealisations.IntegralHeight = false;
      this.uiRealisations.Location = new System.Drawing.Point(10, 23);
      this.uiRealisations.Name = "uiRealisations";
      this.uiRealisations.Size = new System.Drawing.Size(272, 418);
      this.uiRealisations.TabIndex = 1;
      // 
      // uiAddEntity
      // 
      this.uiAddEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiAddEntity.Location = new System.Drawing.Point(12, 494);
      this.uiAddEntity.Name = "uiAddEntity";
      this.uiAddEntity.Size = new System.Drawing.Size(75, 23);
      this.uiAddEntity.TabIndex = 2;
      this.uiAddEntity.Text = "Add";
      this.uiAddEntity.UseVisualStyleBackColor = true;
      this.uiAddEntity.Click += new System.EventHandler(this.uiAddEntity_Click);
      // 
      // uiRemoveEntity
      // 
      this.uiRemoveEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiRemoveEntity.Location = new System.Drawing.Point(93, 494);
      this.uiRemoveEntity.Name = "uiRemoveEntity";
      this.uiRemoveEntity.Size = new System.Drawing.Size(75, 23);
      this.uiRemoveEntity.TabIndex = 3;
      this.uiRemoveEntity.Text = "Remove";
      this.uiRemoveEntity.UseVisualStyleBackColor = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(919, 24);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiFileLoad,
            this.uiFileSave,
            this.uiFileSaveAs});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // uiFileSave
      // 
      this.uiFileSave.Name = "uiFileSave";
      this.uiFileSave.Size = new System.Drawing.Size(152, 22);
      this.uiFileSave.Text = "&Save";
      this.uiFileSave.Click += new System.EventHandler(this.uiFileSave_Click);
      // 
      // uiFileSaveAs
      // 
      this.uiFileSaveAs.Name = "uiFileSaveAs";
      this.uiFileSaveAs.Size = new System.Drawing.Size(152, 22);
      this.uiFileSaveAs.Text = "Save &As...";
      this.uiFileSaveAs.Click += new System.EventHandler(this.uiFileSaveAs_Click);
      // 
      // uiFileLoad
      // 
      this.uiFileLoad.Name = "uiFileLoad";
      this.uiFileLoad.Size = new System.Drawing.Size(152, 22);
      this.uiFileLoad.Text = "&Load";
      this.uiFileLoad.Click += new System.EventHandler(this.uiFileLoad_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(919, 531);
      this.Controls.Add(this.uiRemoveEntity);
      this.Controls.Add(this.uiAddEntity);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Roadmap";
      this.Load += new System.EventHandler(this.Main_Load);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button uiAddEntity;
    private System.Windows.Forms.Button uiRemoveEntity;
    private System.Windows.Forms.ListBox uiGoals;
    private System.Windows.Forms.ListBox uiStrategies;
    private System.Windows.Forms.ListBox uiRealisations;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem uiFileSave;
    private System.Windows.Forms.ToolStripMenuItem uiFileSaveAs;
    private System.Windows.Forms.ToolStripMenuItem uiFileLoad;
  }
}

