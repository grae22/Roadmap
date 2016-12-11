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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.uiFileNew = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.uiFileLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.uiFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.uiFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.uiRemoveStrategy = new System.Windows.Forms.Button();
      this.uiAddStrategy = new System.Windows.Forms.Button();
      this.uiStrategies = new System.Windows.Forms.ListBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.uiGoalsClearSelection = new System.Windows.Forms.Button();
      this.uiRemoveGoal = new System.Windows.Forms.Button();
      this.uiAddGoal = new System.Windows.Forms.Button();
      this.uiGoals = new System.Windows.Forms.ListBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.uiRemoveRealisation = new System.Windows.Forms.Button();
      this.uiAddRealisation = new System.Windows.Forms.Button();
      this.uiRealisations = new System.Windows.Forms.ListBox();
      this.uiMainTabs = new System.Windows.Forms.TabControl();
      this.uiEntitiesTab = new System.Windows.Forms.TabPage();
      this.uiDiagramTab = new System.Windows.Forms.TabPage();
      this.uiDiagram = new System.Windows.Forms.PictureBox();
      this.menuStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.uiMainTabs.SuspendLayout();
      this.uiEntitiesTab.SuspendLayout();
      this.uiDiagramTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.uiDiagram)).BeginInit();
      this.SuspendLayout();
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
            this.uiFileNew,
            this.toolStripSeparator2,
            this.uiFileLoad,
            this.toolStripSeparator1,
            this.uiFileSave,
            this.uiFileSaveAs});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // uiFileNew
      // 
      this.uiFileNew.Name = "uiFileNew";
      this.uiFileNew.Size = new System.Drawing.Size(152, 22);
      this.uiFileNew.Text = "&New";
      this.uiFileNew.Click += new System.EventHandler(this.uiFileNew_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
      // 
      // uiFileLoad
      // 
      this.uiFileLoad.Name = "uiFileLoad";
      this.uiFileLoad.Size = new System.Drawing.Size(152, 22);
      this.uiFileLoad.Text = "&Load";
      this.uiFileLoad.Click += new System.EventHandler(this.uiFileLoad_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
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
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(905, 484);
      this.tableLayoutPanel1.TabIndex = 5;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.uiRemoveStrategy);
      this.groupBox2.Controls.Add(this.uiAddStrategy);
      this.groupBox2.Controls.Add(this.uiStrategies);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(304, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
      this.groupBox2.Size = new System.Drawing.Size(295, 478);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Strategies:";
      // 
      // uiRemoveStrategy
      // 
      this.uiRemoveStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiRemoveStrategy.Location = new System.Drawing.Point(252, 17);
      this.uiRemoveStrategy.Name = "uiRemoveStrategy";
      this.uiRemoveStrategy.Size = new System.Drawing.Size(34, 20);
      this.uiRemoveStrategy.TabIndex = 6;
      this.uiRemoveStrategy.Text = "-";
      this.uiRemoveStrategy.UseVisualStyleBackColor = true;
      this.uiRemoveStrategy.Click += new System.EventHandler(this.uiRemoveStrategy_Click);
      // 
      // uiAddStrategy
      // 
      this.uiAddStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiAddStrategy.Location = new System.Drawing.Point(212, 17);
      this.uiAddStrategy.Name = "uiAddStrategy";
      this.uiAddStrategy.Size = new System.Drawing.Size(34, 20);
      this.uiAddStrategy.TabIndex = 5;
      this.uiAddStrategy.Text = "+";
      this.uiAddStrategy.UseVisualStyleBackColor = true;
      this.uiAddStrategy.Click += new System.EventHandler(this.uiAddStrategy_Click);
      // 
      // uiStrategies
      // 
      this.uiStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiStrategies.FormattingEnabled = true;
      this.uiStrategies.HorizontalScrollbar = true;
      this.uiStrategies.IntegralHeight = false;
      this.uiStrategies.Location = new System.Drawing.Point(10, 43);
      this.uiStrategies.Name = "uiStrategies";
      this.uiStrategies.Size = new System.Drawing.Size(275, 425);
      this.uiStrategies.TabIndex = 1;
      this.uiStrategies.SelectedIndexChanged += new System.EventHandler(this.uiStrategies_SelectedIndexChanged);
      this.uiStrategies.DoubleClick += new System.EventHandler(this.uiStrategies_DoubleClick);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.uiGoalsClearSelection);
      this.groupBox1.Controls.Add(this.uiRemoveGoal);
      this.groupBox1.Controls.Add(this.uiAddGoal);
      this.groupBox1.Controls.Add(this.uiGoals);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
      this.groupBox1.Size = new System.Drawing.Size(295, 478);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Goals:";
      // 
      // uiGoalsClearSelection
      // 
      this.uiGoalsClearSelection.Location = new System.Drawing.Point(10, 17);
      this.uiGoalsClearSelection.Name = "uiGoalsClearSelection";
      this.uiGoalsClearSelection.Size = new System.Drawing.Size(34, 20);
      this.uiGoalsClearSelection.TabIndex = 5;
      this.uiGoalsClearSelection.Text = "x";
      this.uiGoalsClearSelection.UseVisualStyleBackColor = true;
      this.uiGoalsClearSelection.Click += new System.EventHandler(this.uiGoalsClearSelection_Click);
      // 
      // uiRemoveGoal
      // 
      this.uiRemoveGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiRemoveGoal.Location = new System.Drawing.Point(251, 17);
      this.uiRemoveGoal.Name = "uiRemoveGoal";
      this.uiRemoveGoal.Size = new System.Drawing.Size(34, 20);
      this.uiRemoveGoal.TabIndex = 4;
      this.uiRemoveGoal.Text = "-";
      this.uiRemoveGoal.UseVisualStyleBackColor = true;
      this.uiRemoveGoal.Click += new System.EventHandler(this.uiRemoveGoal_Click);
      // 
      // uiAddGoal
      // 
      this.uiAddGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiAddGoal.Location = new System.Drawing.Point(211, 17);
      this.uiAddGoal.Name = "uiAddGoal";
      this.uiAddGoal.Size = new System.Drawing.Size(34, 20);
      this.uiAddGoal.TabIndex = 3;
      this.uiAddGoal.Text = "+";
      this.uiAddGoal.UseVisualStyleBackColor = true;
      this.uiAddGoal.Click += new System.EventHandler(this.uiAddGoal_Click);
      // 
      // uiGoals
      // 
      this.uiGoals.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiGoals.FormattingEnabled = true;
      this.uiGoals.HorizontalScrollbar = true;
      this.uiGoals.IntegralHeight = false;
      this.uiGoals.Location = new System.Drawing.Point(10, 43);
      this.uiGoals.Name = "uiGoals";
      this.uiGoals.Size = new System.Drawing.Size(275, 425);
      this.uiGoals.TabIndex = 0;
      this.uiGoals.SelectedIndexChanged += new System.EventHandler(this.uiGoals_SelectedIndexChanged);
      this.uiGoals.DoubleClick += new System.EventHandler(this.uiGoals_DoubleClick);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.uiRemoveRealisation);
      this.groupBox3.Controls.Add(this.uiAddRealisation);
      this.groupBox3.Controls.Add(this.uiRealisations);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox3.Location = new System.Drawing.Point(605, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
      this.groupBox3.Size = new System.Drawing.Size(297, 478);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Realisations:";
      // 
      // uiRemoveRealisation
      // 
      this.uiRemoveRealisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiRemoveRealisation.Location = new System.Drawing.Point(253, 17);
      this.uiRemoveRealisation.Name = "uiRemoveRealisation";
      this.uiRemoveRealisation.Size = new System.Drawing.Size(34, 20);
      this.uiRemoveRealisation.TabIndex = 6;
      this.uiRemoveRealisation.Text = "-";
      this.uiRemoveRealisation.UseVisualStyleBackColor = true;
      this.uiRemoveRealisation.Click += new System.EventHandler(this.uiRemoveRealisation_Click);
      // 
      // uiAddRealisation
      // 
      this.uiAddRealisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.uiAddRealisation.Location = new System.Drawing.Point(213, 17);
      this.uiAddRealisation.Name = "uiAddRealisation";
      this.uiAddRealisation.Size = new System.Drawing.Size(34, 20);
      this.uiAddRealisation.TabIndex = 5;
      this.uiAddRealisation.Text = "+";
      this.uiAddRealisation.UseVisualStyleBackColor = true;
      this.uiAddRealisation.Click += new System.EventHandler(this.uiAddRealisation_Click);
      // 
      // uiRealisations
      // 
      this.uiRealisations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiRealisations.FormattingEnabled = true;
      this.uiRealisations.HorizontalScrollbar = true;
      this.uiRealisations.IntegralHeight = false;
      this.uiRealisations.Location = new System.Drawing.Point(10, 43);
      this.uiRealisations.Name = "uiRealisations";
      this.uiRealisations.Size = new System.Drawing.Size(277, 425);
      this.uiRealisations.TabIndex = 1;
      this.uiRealisations.DoubleClick += new System.EventHandler(this.uiRealisations_DoubleClick);
      // 
      // uiMainTabs
      // 
      this.uiMainTabs.Controls.Add(this.uiEntitiesTab);
      this.uiMainTabs.Controls.Add(this.uiDiagramTab);
      this.uiMainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiMainTabs.Location = new System.Drawing.Point(0, 24);
      this.uiMainTabs.Name = "uiMainTabs";
      this.uiMainTabs.SelectedIndex = 0;
      this.uiMainTabs.Size = new System.Drawing.Size(919, 516);
      this.uiMainTabs.TabIndex = 6;
      this.uiMainTabs.SelectedIndexChanged += new System.EventHandler(this.uiMainTabs_SelectedIndexChanged);
      // 
      // uiEntitiesTab
      // 
      this.uiEntitiesTab.Controls.Add(this.tableLayoutPanel1);
      this.uiEntitiesTab.Location = new System.Drawing.Point(4, 22);
      this.uiEntitiesTab.Name = "uiEntitiesTab";
      this.uiEntitiesTab.Padding = new System.Windows.Forms.Padding(3);
      this.uiEntitiesTab.Size = new System.Drawing.Size(911, 490);
      this.uiEntitiesTab.TabIndex = 0;
      this.uiEntitiesTab.Text = "Entities";
      this.uiEntitiesTab.UseVisualStyleBackColor = true;
      // 
      // uiDiagramTab
      // 
      this.uiDiagramTab.Controls.Add(this.uiDiagram);
      this.uiDiagramTab.Location = new System.Drawing.Point(4, 22);
      this.uiDiagramTab.Name = "uiDiagramTab";
      this.uiDiagramTab.Padding = new System.Windows.Forms.Padding(3);
      this.uiDiagramTab.Size = new System.Drawing.Size(911, 490);
      this.uiDiagramTab.TabIndex = 1;
      this.uiDiagramTab.Text = "Diagram";
      this.uiDiagramTab.UseVisualStyleBackColor = true;
      // 
      // uiDiagram
      // 
      this.uiDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiDiagram.Location = new System.Drawing.Point(3, 3);
      this.uiDiagram.Name = "uiDiagram";
      this.uiDiagram.Size = new System.Drawing.Size(905, 484);
      this.uiDiagram.TabIndex = 0;
      this.uiDiagram.TabStop = false;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(919, 540);
      this.Controls.Add(this.uiMainTabs);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Roadmap";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.Load += new System.EventHandler(this.Main_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.uiMainTabs.ResumeLayout(false);
      this.uiEntitiesTab.ResumeLayout(false);
      this.uiDiagramTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.uiDiagram)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem uiFileSave;
    private System.Windows.Forms.ToolStripMenuItem uiFileSaveAs;
    private System.Windows.Forms.ToolStripMenuItem uiFileLoad;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button uiGoalsClearSelection;
    private System.Windows.Forms.Button uiRemoveGoal;
    private System.Windows.Forms.Button uiAddGoal;
    private System.Windows.Forms.ListBox uiGoals;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button uiRemoveRealisation;
    private System.Windows.Forms.Button uiAddRealisation;
    private System.Windows.Forms.ListBox uiRealisations;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button uiRemoveStrategy;
    private System.Windows.Forms.Button uiAddStrategy;
    private System.Windows.Forms.ListBox uiStrategies;
    private System.Windows.Forms.ToolStripMenuItem uiFileNew;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.TabControl uiMainTabs;
    private System.Windows.Forms.TabPage uiEntitiesTab;
    private System.Windows.Forms.TabPage uiDiagramTab;
    private System.Windows.Forms.PictureBox uiDiagram;
  }
}

