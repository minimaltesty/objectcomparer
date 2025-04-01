namespace SampleApp.Source.Forms {
    partial class OrderDetailsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label displaynameLabel;
            System.Windows.Forms.Label firstnameLabel;
            System.Windows.Forms.Label lastnameLabel;
            System.Windows.Forms.Label numberLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label streetLabel;
            System.Windows.Forms.Label zipLabel;
            System.Windows.Forms.Label numberLabel1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailsForm));
            this.displaynameTextBox = new System.Windows.Forms.TextBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox1 = new System.Windows.Forms.TextBox();
            this.positionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDiff = new System.Windows.Forms.Button();
            this.Head = new System.Windows.Forms.GroupBox();
            this.btnDeepCopy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadConfiguration = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            displaynameLabel = new System.Windows.Forms.Label();
            firstnameLabel = new System.Windows.Forms.Label();
            lastnameLabel = new System.Windows.Forms.Label();
            numberLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            streetLabel = new System.Windows.Forms.Label();
            zipLabel = new System.Windows.Forms.Label();
            numberLabel1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).BeginInit();
            this.Head.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // displaynameLabel
            // 
            displaynameLabel.AutoSize = true;
            displaynameLabel.Location = new System.Drawing.Point(9, 96);
            displaynameLabel.Name = "displaynameLabel";
            displaynameLabel.Size = new System.Drawing.Size(35, 13);
            displaynameLabel.TabIndex = 1;
            displaynameLabel.Text = "Name";
            // 
            // firstnameLabel
            // 
            firstnameLabel.AutoSize = true;
            firstnameLabel.Location = new System.Drawing.Point(168, 70);
            firstnameLabel.Name = "firstnameLabel";
            firstnameLabel.Size = new System.Drawing.Size(52, 13);
            firstnameLabel.TabIndex = 3;
            firstnameLabel.Text = "Firstname";
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Location = new System.Drawing.Point(168, 96);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new System.Drawing.Size(53, 13);
            lastnameLabel.TabIndex = 5;
            lastnameLabel.Text = "Lastname";
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Location = new System.Drawing.Point(9, 71);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(24, 13);
            numberLabel.TabIndex = 7;
            numberLabel.Text = "No.";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(463, 70);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(24, 13);
            cityLabel.TabIndex = 9;
            cityLabel.Text = "City";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new System.Drawing.Point(358, 96);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new System.Drawing.Size(35, 13);
            streetLabel.TabIndex = 11;
            streetLabel.Text = "Street";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Location = new System.Drawing.Point(358, 70);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new System.Drawing.Size(22, 13);
            zipLabel.TabIndex = 13;
            zipLabel.Text = "Zip";
            // 
            // numberLabel1
            // 
            numberLabel1.AutoSize = true;
            numberLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numberLabel1.Location = new System.Drawing.Point(9, 22);
            numberLabel1.Name = "numberLabel1";
            numberLabel1.Size = new System.Drawing.Size(59, 13);
            numberLabel1.TabIndex = 15;
            numberLabel1.Text = "Order No.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(9, 48);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 14);
            label3.TabIndex = 17;
            label3.Text = "Customer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(358, 48);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(117, 14);
            label4.TabIndex = 18;
            label4.Text = "Customer address";
            // 
            // displaynameTextBox
            // 
            this.displaynameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Displayname", true));
            this.displaynameTextBox.Location = new System.Drawing.Point(50, 93);
            this.displaynameTextBox.Name = "displaynameTextBox";
            this.displaynameTextBox.Size = new System.Drawing.Size(100, 20);
            this.displaynameTextBox.TabIndex = 2;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(SampleApp.Source.BusinessObjects.Customer);
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(SampleApp.Source.BusinessObjects.Order);
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Firstname", true));
            this.firstnameTextBox.Location = new System.Drawing.Point(226, 67);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(115, 20);
            this.firstnameTextBox.TabIndex = 4;
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Lastname", true));
            this.lastnameTextBox.Location = new System.Drawing.Point(227, 93);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(114, 20);
            this.lastnameTextBox.TabIndex = 6;
            // 
            // numberTextBox
            // 
            this.numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Number", true));
            this.numberTextBox.Location = new System.Drawing.Point(50, 68);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox.TabIndex = 8;
            // 
            // cityTextBox
            // 
            this.cityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "City", true));
            this.cityTextBox.Location = new System.Drawing.Point(493, 68);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(115, 20);
            this.cityTextBox.TabIndex = 10;
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataSource = typeof(SampleApp.Source.BusinessObjects.Address);
            // 
            // streetTextBox
            // 
            this.streetTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "Street", true));
            this.streetTextBox.Location = new System.Drawing.Point(399, 93);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(209, 20);
            this.streetTextBox.TabIndex = 12;
            // 
            // zipTextBox
            // 
            this.zipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "Zip", true));
            this.zipTextBox.Location = new System.Drawing.Point(399, 67);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(58, 20);
            this.zipTextBox.TabIndex = 14;
            // 
            // numberTextBox1
            // 
            this.numberTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Number", true));
            this.numberTextBox1.Location = new System.Drawing.Point(74, 19);
            this.numberTextBox1.Name = "numberTextBox1";
            this.numberTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox1.TabIndex = 16;
            // 
            // positionsDataGridView
            // 
            this.positionsDataGridView.AutoGenerateColumns = false;
            this.positionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.positionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.positionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.positionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.positionsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.positionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.positionsDataGridView.DataSource = this.positionsBindingSource;
            this.positionsDataGridView.Location = new System.Drawing.Point(12, 255);
            this.positionsDataGridView.Name = "positionsDataGridView";
            this.positionsDataGridView.RowHeadersWidth = 30;
            this.positionsDataGridView.Size = new System.Drawing.Size(614, 155);
            this.positionsDataGridView.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderId";
            this.dataGridViewTextBoxColumn2.HeaderText = "OrderId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn3.HeaderText = "Number";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderIndex";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderIndex";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn5.HeaderText = "Text";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // positionsBindingSource
            // 
            this.positionsBindingSource.DataMember = "Positions";
            this.positionsBindingSource.DataSource = this.orderBindingSource;
            // 
            // btnDiff
            // 
            this.btnDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiff.Location = new System.Drawing.Point(12, 416);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(113, 47);
            this.btnDiff.TabIndex = 18;
            this.btnDiff.Text = "Show changes";
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // Head
            // 
            this.Head.Controls.Add(label4);
            this.Head.Controls.Add(label3);
            this.Head.Controls.Add(this.numberTextBox1);
            this.Head.Controls.Add(numberLabel1);
            this.Head.Controls.Add(this.numberTextBox);
            this.Head.Controls.Add(zipLabel);
            this.Head.Controls.Add(numberLabel);
            this.Head.Controls.Add(this.zipTextBox);
            this.Head.Controls.Add(this.displaynameTextBox);
            this.Head.Controls.Add(streetLabel);
            this.Head.Controls.Add(displaynameLabel);
            this.Head.Controls.Add(this.streetTextBox);
            this.Head.Controls.Add(this.firstnameTextBox);
            this.Head.Controls.Add(cityLabel);
            this.Head.Controls.Add(firstnameLabel);
            this.Head.Controls.Add(this.cityTextBox);
            this.Head.Controls.Add(this.lastnameTextBox);
            this.Head.Controls.Add(lastnameLabel);
            this.Head.Location = new System.Drawing.Point(12, 122);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(614, 127);
            this.Head.TabIndex = 19;
            this.Head.TabStop = false;
            this.Head.Text = "Head";
            // 
            // btnDeepCopy
            // 
            this.btnDeepCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeepCopy.Location = new System.Drawing.Point(131, 416);
            this.btnDeepCopy.Name = "btnDeepCopy";
            this.btnDeepCopy.Size = new System.Drawing.Size(119, 47);
            this.btnDeepCopy.TabIndex = 20;
            this.btnDeepCopy.Text = "Create DeepCopy";
            this.btnDeepCopy.UseVisualStyleBackColor = true;
            this.btnDeepCopy.Click += new System.EventHandler(this.btnDeepCopy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(632, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 370);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trace";
            this.groupBox1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(282, 349);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 116);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Try it ...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::SampleApp.Properties.Resources._109_AllAnnotations_Info_256;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadConfiguration
            // 
            this.btnLoadConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadConfiguration.Location = new System.Drawing.Point(394, 416);
            this.btnLoadConfiguration.Name = "btnLoadConfiguration";
            this.btnLoadConfiguration.Size = new System.Drawing.Size(113, 47);
            this.btnLoadConfiguration.TabIndex = 23;
            this.btnLoadConfiguration.Text = "Load Configuration";
            this.btnLoadConfiguration.UseVisualStyleBackColor = true;
            this.btnLoadConfiguration.Click += new System.EventHandler(this.btnLoadConfiguration_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(513, 416);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 47);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 483);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoadConfiguration);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeepCopy);
            this.Controls.Add(this.Head);
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.positionsDataGridView);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderDetailsForm";
            this.Shown += new System.EventHandler(this.OrderDetailsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).EndInit();
            this.Head.ResumeLayout(false);
            this.Head.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.TextBox displaynameTextBox;
        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.TextBox numberTextBox1;
        private System.Windows.Forms.BindingSource positionsBindingSource;
        private System.Windows.Forms.DataGridView positionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnDiff;
        private System.Windows.Forms.GroupBox Head;
        private System.Windows.Forms.Button btnDeepCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private System.Windows.Forms.Button btnLoadConfiguration;
        private System.Windows.Forms.Button btnReset;
    }
}