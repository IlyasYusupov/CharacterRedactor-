namespace CharacterTeams
{
    partial class Form2
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
            this.lvCharacters = new System.Windows.Forms.ListView();
            this.CharacterName = new System.Windows.Forms.ColumnHeader();
            this.LVL = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvCharacters
            // 
            this.lvCharacters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CharacterName,
            this.LVL});
            this.lvCharacters.Location = new System.Drawing.Point(12, 27);
            this.lvCharacters.Name = "lvCharacters";
            this.lvCharacters.Size = new System.Drawing.Size(163, 214);
            this.lvCharacters.TabIndex = 0;
            this.lvCharacters.UseCompatibleStateImageBehavior = false;
            this.lvCharacters.View = System.Windows.Forms.View.Details;
            this.lvCharacters.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvCharacters_ItemSelectionChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select character";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCharacters);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvCharacters;
        private Label label1;
        private ColumnHeader CharacterName;
        private ColumnHeader LVL;
    }
}