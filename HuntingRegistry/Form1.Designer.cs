namespace HuntingRegistry
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label countLabel;
            System.Windows.Forms.Label dayLabel;
            System.Windows.Forms.Label seasonLabel;
            System.Windows.Forms.Label sexLabel;
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.animalsDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.animalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.seasonTextBox = new System.Windows.Forms.TextBox();
            this.sexTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            nameLabel = new System.Windows.Forms.Label();
            countLabel = new System.Windows.Forms.Label();
            dayLabel = new System.Windows.Forms.Label();
            seasonLabel = new System.Windows.Forms.Label();
            sexLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.animalsDocumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(8, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Location = new System.Drawing.Point(27, 53);
            countLabel.Name = "countLabel";
            countLabel.Size = new System.Drawing.Size(38, 13);
            countLabel.TabIndex = 2;
            countLabel.Text = "Count:";
            // 
            // dayLabel
            // 
            dayLabel.AutoSize = true;
            dayLabel.Location = new System.Drawing.Point(36, 75);
            dayLabel.Name = "dayLabel";
            dayLabel.Size = new System.Drawing.Size(29, 13);
            dayLabel.TabIndex = 4;
            dayLabel.Text = "Day:";
            // 
            // seasonLabel
            // 
            seasonLabel.AutoSize = true;
            seasonLabel.Location = new System.Drawing.Point(19, 101);
            seasonLabel.Name = "seasonLabel";
            seasonLabel.Size = new System.Drawing.Size(46, 13);
            seasonLabel.TabIndex = 6;
            seasonLabel.Text = "Season:";
            // 
            // sexLabel
            // 
            sexLabel.AutoSize = true;
            sexLabel.Location = new System.Drawing.Point(37, 127);
            sexLabel.Name = "sexLabel";
            sexLabel.Size = new System.Drawing.Size(28, 13);
            sexLabel.TabIndex = 8;
            sexLabel.Text = "Sex:";
            // 
            // nameComboBox
            // 
            this.nameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalsDocumentBindingSource, "Animal.Name", true));
            this.nameComboBox.DataSource = this.animalBindingSource;
            this.nameComboBox.DisplayMember = "Name";
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(52, 12);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(121, 21);
            this.nameComboBox.TabIndex = 1;
            this.nameComboBox.ValueMember = "Id";
            // 
            // animalsDocumentBindingSource
            // 
            this.animalsDocumentBindingSource.DataSource = typeof(HuntingRegistry.Models.AnimalsDocument);
            // 
            // animalBindingSource
            // 
            this.animalBindingSource.DataSource = typeof(HuntingRegistry.Models.Animal);
            this.animalBindingSource.CurrentChanged += new System.EventHandler(this.animalBindingSource_CurrentChanged);
            // 
            // countTextBox
            // 
            this.countTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalsDocumentBindingSource, "Count", true));
            this.countTextBox.Location = new System.Drawing.Point(71, 50);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(100, 20);
            this.countTextBox.TabIndex = 3;
            // 
            // dayTextBox
            // 
            this.dayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalsDocumentBindingSource, "Day", true));
            this.dayTextBox.Location = new System.Drawing.Point(71, 72);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(100, 20);
            this.dayTextBox.TabIndex = 5;
            // 
            // seasonTextBox
            // 
            this.seasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalsDocumentBindingSource, "Season", true));
            this.seasonTextBox.Location = new System.Drawing.Point(71, 98);
            this.seasonTextBox.Name = "seasonTextBox";
            this.seasonTextBox.Size = new System.Drawing.Size(100, 20);
            this.seasonTextBox.TabIndex = 7;
            // 
            // sexTextBox
            // 
            this.sexTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalsDocumentBindingSource, "Sex", true));
            this.sexTextBox.Location = new System.Drawing.Point(71, 124);
            this.sexTextBox.Name = "sexTextBox";
            this.sexTextBox.Size = new System.Drawing.Size(100, 20);
            this.sexTextBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 281);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(sexLabel);
            this.Controls.Add(this.sexTextBox);
            this.Controls.Add(seasonLabel);
            this.Controls.Add(this.seasonTextBox);
            this.Controls.Add(dayLabel);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(countLabel);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameComboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.animalsDocumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource animalsDocumentBindingSource;
        private System.Windows.Forms.BindingSource animalBindingSource;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.TextBox seasonTextBox;
        private System.Windows.Forms.TextBox sexTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}