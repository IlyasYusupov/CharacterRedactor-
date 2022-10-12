namespace CharacterTeams
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView2 = new System.Windows.Forms.ListView();
            this.CharName = new System.Windows.Forms.ColumnHeader();
            this.CharLVL = new System.Windows.Forms.ColumnHeader();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvCharacters = new System.Windows.Forms.ListView();
            this.CharacterName = new System.Windows.Forms.ColumnHeader();
            this.LVL = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CharName,
            this.CharLVL});
            this.listView2.Location = new System.Drawing.Point(509, 65);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(153, 224);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView2_ItemSelectionChanged);
            this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView2_DragDrop);
            this.listView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // CharName
            // 
            this.CharName.Text = "Name";
            this.CharName.Width = 100;
            // 
            // CharLVL
            // 
            this.CharLVL.Text = "LVL";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(12, 12);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 3;
            this.btnAuto.Text = "Auto input";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Red team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Blue team";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select character";
            // 
            // lvCharacters
            // 
            this.lvCharacters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CharacterName,
            this.LVL});
            this.lvCharacters.Location = new System.Drawing.Point(259, 65);
            this.lvCharacters.Name = "lvCharacters";
            this.lvCharacters.Size = new System.Drawing.Size(165, 224);
            this.lvCharacters.TabIndex = 6;
            this.lvCharacters.UseCompatibleStateImageBehavior = false;
            this.lvCharacters.View = System.Windows.Forms.View.Details;
            this.lvCharacters.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvCharacters_ItemSelectionChanged);
            this.lvCharacters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCharacters_MouseDown);
            this.lvCharacters.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvCharacters_MouseMove);
            // 
            // CharacterName
            // 
            this.CharacterName.Text = "Name";
            this.CharacterName.Width = 100;
            // 
            // LVL
            // 
            this.LVL.Text = "LVL";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(12, 65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(153, 224);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "LVL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 311);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvCharacters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.listView2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView listView2;
        private Button btnAuto;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView lvCharacters;
        private ColumnHeader CharacterName;
        private ColumnHeader LVL;
        private ColumnHeader CharName;
        private ColumnHeader CharLVL;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}