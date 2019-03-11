namespace Lab2
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
            this.ChildGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insert_Button = new System.Windows.Forms.Button();
            this.delete_Button = new System.Windows.Forms.Button();
            this.update_Button = new System.Windows.Forms.Button();
            this.populate_Button = new System.Windows.Forms.Button();
            this.generate_Button = new System.Windows.Forms.Button();
            this.ParentGridView = new System.Windows.Forms.DataGridView();
            this.select_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChildGridView
            // 
            this.ChildGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildGridView.Location = new System.Drawing.Point(514, 66);
            this.ChildGridView.Name = "ChildGridView";
            this.ChildGridView.RowTemplate.Height = 24;
            this.ChildGridView.Size = new System.Drawing.Size(520, 522);
            this.ChildGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1050, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 522);
            this.panel1.TabIndex = 1;
            // 
            // insert_Button
            // 
            this.insert_Button.Location = new System.Drawing.Point(1260, 289);
            this.insert_Button.Name = "insert_Button";
            this.insert_Button.Size = new System.Drawing.Size(137, 47);
            this.insert_Button.TabIndex = 2;
            this.insert_Button.Text = "Insert";
            this.insert_Button.UseVisualStyleBackColor = true;
            this.insert_Button.Click += new System.EventHandler(this.insert_Button_Click);
            // 
            // delete_Button
            // 
            this.delete_Button.Location = new System.Drawing.Point(1260, 371);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(137, 47);
            this.delete_Button.TabIndex = 3;
            this.delete_Button.Text = "Delete";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Click += new System.EventHandler(this.delete_Button_Click);
            // 
            // update_Button
            // 
            this.update_Button.Location = new System.Drawing.Point(1260, 450);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(137, 47);
            this.update_Button.TabIndex = 4;
            this.update_Button.Text = "Update";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Click += new System.EventHandler(this.update_Button_Click);
            // 
            // populate_Button
            // 
            this.populate_Button.Location = new System.Drawing.Point(61, 12);
            this.populate_Button.Name = "populate_Button";
            this.populate_Button.Size = new System.Drawing.Size(157, 48);
            this.populate_Button.TabIndex = 5;
            this.populate_Button.Text = "Populate";
            this.populate_Button.UseVisualStyleBackColor = true;
            this.populate_Button.Click += new System.EventHandler(this.populate_Button_Click);
            // 
            // generate_Button
            // 
            this.generate_Button.Location = new System.Drawing.Point(1076, 12);
            this.generate_Button.Name = "generate_Button";
            this.generate_Button.Size = new System.Drawing.Size(135, 48);
            this.generate_Button.TabIndex = 6;
            this.generate_Button.Text = "Generate TextBoxes";
            this.generate_Button.UseVisualStyleBackColor = true;
            this.generate_Button.Click += new System.EventHandler(this.generate_Button_Click);
            // 
            // ParentGridView
            // 
            this.ParentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParentGridView.Location = new System.Drawing.Point(12, 66);
            this.ParentGridView.Name = "ParentGridView";
            this.ParentGridView.RowTemplate.Height = 24;
            this.ParentGridView.Size = new System.Drawing.Size(496, 522);
            this.ParentGridView.TabIndex = 7;
            // 
            // select_Button
            // 
            this.select_Button.Location = new System.Drawing.Point(514, 12);
            this.select_Button.Name = "select_Button";
            this.select_Button.Size = new System.Drawing.Size(156, 48);
            this.select_Button.TabIndex = 8;
            this.select_Button.Text = "Select";
            this.select_Button.UseVisualStyleBackColor = true;
            this.select_Button.Click += new System.EventHandler(this.select_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1423, 600);
            this.Controls.Add(this.select_Button);
            this.Controls.Add(this.ParentGridView);
            this.Controls.Add(this.generate_Button);
            this.Controls.Add(this.populate_Button);
            this.Controls.Add(this.update_Button);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.insert_Button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ChildGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ChildGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button insert_Button;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button update_Button;
        private System.Windows.Forms.Button populate_Button;
        private System.Windows.Forms.Button generate_Button;
        private System.Windows.Forms.DataGridView ParentGridView;
        private System.Windows.Forms.Button select_Button;
    }
}

