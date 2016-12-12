namespace Roadmapp.UI
{
  partial class EntityDlg
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.uiPoints = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.uiDependencies = new System.Windows.Forms.CheckedListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.uiDescription = new System.Windows.Forms.TextBox();
      this.uiType = new System.Windows.Forms.ComboBox();
      this.uiTitle = new System.Windows.Forms.TextBox();
      this.uiCancel = new System.Windows.Forms.Button();
      this.uiOk = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.uiPoints);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.uiDependencies);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.uiDescription);
      this.groupBox1.Controls.Add(this.uiType);
      this.groupBox1.Controls.Add(this.uiTitle);
      this.groupBox1.Location = new System.Drawing.Point(10, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(349, 417);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(48, 385);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(39, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Points:";
      // 
      // uiPoints
      // 
      this.uiPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiPoints.Location = new System.Drawing.Point(106, 382);
      this.uiPoints.Name = "uiPoints";
      this.uiPoints.Size = new System.Drawing.Size(48, 20);
      this.uiPoints.TabIndex = 8;
      this.uiPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(8, 202);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Dependencies:";
      // 
      // uiDependencies
      // 
      this.uiDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiDependencies.CheckOnClick = true;
      this.uiDependencies.FormattingEnabled = true;
      this.uiDependencies.IntegralHeight = false;
      this.uiDependencies.Location = new System.Drawing.Point(106, 202);
      this.uiDependencies.Name = "uiDependencies";
      this.uiDependencies.Size = new System.Drawing.Size(225, 174);
      this.uiDependencies.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(24, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Description:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(57, 49);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Title:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(53, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Type:";
      // 
      // uiDescription
      // 
      this.uiDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiDescription.Location = new System.Drawing.Point(106, 72);
      this.uiDescription.Multiline = true;
      this.uiDescription.Name = "uiDescription";
      this.uiDescription.Size = new System.Drawing.Size(225, 124);
      this.uiDescription.TabIndex = 2;
      // 
      // uiType
      // 
      this.uiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.uiType.Enabled = false;
      this.uiType.FormattingEnabled = true;
      this.uiType.Location = new System.Drawing.Point(106, 19);
      this.uiType.Name = "uiType";
      this.uiType.Size = new System.Drawing.Size(121, 21);
      this.uiType.TabIndex = 1;
      this.uiType.SelectedIndexChanged += new System.EventHandler(this.uiType_SelectedIndexChanged);
      // 
      // uiTitle
      // 
      this.uiTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiTitle.Location = new System.Drawing.Point(106, 46);
      this.uiTitle.Name = "uiTitle";
      this.uiTitle.Size = new System.Drawing.Size(225, 20);
      this.uiTitle.TabIndex = 0;
      // 
      // uiCancel
      // 
      this.uiCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.uiCancel.Location = new System.Drawing.Point(284, 442);
      this.uiCancel.Name = "uiCancel";
      this.uiCancel.Size = new System.Drawing.Size(75, 23);
      this.uiCancel.TabIndex = 1;
      this.uiCancel.Text = "Cancel";
      this.uiCancel.UseVisualStyleBackColor = true;
      // 
      // uiOk
      // 
      this.uiOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiOk.Location = new System.Drawing.Point(203, 442);
      this.uiOk.Name = "uiOk";
      this.uiOk.Size = new System.Drawing.Size(75, 23);
      this.uiOk.TabIndex = 2;
      this.uiOk.Text = "OK";
      this.uiOk.UseVisualStyleBackColor = true;
      this.uiOk.Click += new System.EventHandler(this.uiOk_Click);
      // 
      // EntityDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.uiCancel;
      this.ClientSize = new System.Drawing.Size(369, 477);
      this.ControlBox = false;
      this.Controls.Add(this.uiOk);
      this.Controls.Add(this.uiCancel);
      this.Controls.Add(this.groupBox1);
      this.Name = "EntityDlg";
      this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 50);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Entity Properties";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntityDlg_FormClosing);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox uiDescription;
    private System.Windows.Forms.ComboBox uiType;
    private System.Windows.Forms.TextBox uiTitle;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button uiCancel;
    private System.Windows.Forms.Button uiOk;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckedListBox uiDependencies;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox uiPoints;
  }
}