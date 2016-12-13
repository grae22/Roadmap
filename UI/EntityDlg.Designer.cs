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
      this.uiValuePoints = new System.Windows.Forms.TextBox();
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
      this.label6 = new System.Windows.Forms.Label();
      this.uiEffortPoints = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.uiPriorityPoints = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.uiPriorityPoints);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.uiEffortPoints);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.uiValuePoints);
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
      this.groupBox1.Size = new System.Drawing.Size(459, 482);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(50, 450);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(37, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Value:";
      // 
      // uiValuePoints
      // 
      this.uiValuePoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiValuePoints.Location = new System.Drawing.Point(106, 447);
      this.uiValuePoints.Name = "uiValuePoints";
      this.uiValuePoints.Size = new System.Drawing.Size(48, 20);
      this.uiValuePoints.TabIndex = 4;
      this.uiValuePoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
      this.uiDependencies.Size = new System.Drawing.Size(335, 239);
      this.uiDependencies.TabIndex = 3;
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
      this.uiDescription.Size = new System.Drawing.Size(335, 124);
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
      this.uiType.TabIndex = 0;
      this.uiType.SelectedIndexChanged += new System.EventHandler(this.uiType_SelectedIndexChanged);
      // 
      // uiTitle
      // 
      this.uiTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.uiTitle.Location = new System.Drawing.Point(106, 46);
      this.uiTitle.Name = "uiTitle";
      this.uiTitle.Size = new System.Drawing.Size(335, 20);
      this.uiTitle.TabIndex = 1;
      // 
      // uiCancel
      // 
      this.uiCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.uiCancel.Location = new System.Drawing.Point(394, 507);
      this.uiCancel.Name = "uiCancel";
      this.uiCancel.Size = new System.Drawing.Size(75, 23);
      this.uiCancel.TabIndex = 8;
      this.uiCancel.Text = "Cancel";
      this.uiCancel.UseVisualStyleBackColor = true;
      // 
      // uiOk
      // 
      this.uiOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiOk.Location = new System.Drawing.Point(313, 507);
      this.uiOk.Name = "uiOk";
      this.uiOk.Size = new System.Drawing.Size(75, 23);
      this.uiOk.TabIndex = 7;
      this.uiOk.Text = "OK";
      this.uiOk.UseVisualStyleBackColor = true;
      this.uiOk.Click += new System.EventHandler(this.uiOk_Click);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(170, 450);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(35, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Effort:";
      // 
      // uiEffortPoints
      // 
      this.uiEffortPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiEffortPoints.Location = new System.Drawing.Point(211, 447);
      this.uiEffortPoints.Name = "uiEffortPoints";
      this.uiEffortPoints.Size = new System.Drawing.Size(48, 20);
      this.uiEffortPoints.TabIndex = 5;
      this.uiEffortPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(274, 450);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "Priority:";
      // 
      // uiPriorityPoints
      // 
      this.uiPriorityPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.uiPriorityPoints.Location = new System.Drawing.Point(321, 447);
      this.uiPriorityPoints.Name = "uiPriorityPoints";
      this.uiPriorityPoints.Size = new System.Drawing.Size(48, 20);
      this.uiPriorityPoints.TabIndex = 6;
      this.uiPriorityPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // EntityDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.uiCancel;
      this.ClientSize = new System.Drawing.Size(479, 542);
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
    private System.Windows.Forms.TextBox uiValuePoints;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox uiPriorityPoints;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox uiEffortPoints;
  }
}