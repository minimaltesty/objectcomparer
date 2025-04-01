namespace SIT.Components.ObjectComparer.UI.WinForms {
    partial class ConfigurationForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label metadataRetrievalOptionsLabel;
            System.Windows.Forms.Label getMemberBindingFlagsLabel;
            this.bsConfiguration = new System.Windows.Forms.BindingSource(this.components);
            this.classDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classDescriptionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.propertiesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metadataRetrievalOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.getMemberBindingFlagsListBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            metadataRetrievalOptionsLabel = new System.Windows.Forms.Label();
            getMemberBindingFlagsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDescriptionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metadataRetrievalOptionsLabel
            // 
            metadataRetrievalOptionsLabel.AutoSize = true;
            metadataRetrievalOptionsLabel.Location = new System.Drawing.Point(11, 22);
            metadataRetrievalOptionsLabel.Name = "metadataRetrievalOptionsLabel";
            metadataRetrievalOptionsLabel.Size = new System.Drawing.Size(139, 13);
            metadataRetrievalOptionsLabel.TabIndex = 4;
            metadataRetrievalOptionsLabel.Text = "Metadata Retrieval Options:";
            // 
            // getMemberBindingFlagsLabel
            // 
            getMemberBindingFlagsLabel.AutoSize = true;
            getMemberBindingFlagsLabel.Location = new System.Drawing.Point(4, 56);
            getMemberBindingFlagsLabel.Name = "getMemberBindingFlagsLabel";
            getMemberBindingFlagsLabel.Size = new System.Drawing.Size(134, 13);
            getMemberBindingFlagsLabel.TabIndex = 5;
            getMemberBindingFlagsLabel.Text = "Get Member Binding Flags:";
            // 
            // bsConfiguration
            // 
            this.bsConfiguration.DataSource = typeof(SIT.Components.ObjectComparer.Configuration);
            // 
            // classDescriptionsBindingSource
            // 
            this.classDescriptionsBindingSource.DataMember = "ClassDescriptions";
            this.classDescriptionsBindingSource.DataSource = this.bsConfiguration;
            // 
            // classDescriptionsDataGridView
            // 
            this.classDescriptionsDataGridView.AutoGenerateColumns = false;
            this.classDescriptionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.classDescriptionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.classDescriptionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classDescriptionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.classDescriptionsDataGridView.DataSource = this.classDescriptionsBindingSource;
            this.classDescriptionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classDescriptionsDataGridView.Location = new System.Drawing.Point(0, 16);
            this.classDescriptionsDataGridView.Name = "classDescriptionsDataGridView";
            this.classDescriptionsDataGridView.Size = new System.Drawing.Size(466, 352);
            this.classDescriptionsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdPropertyName";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdPropertyName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn2.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DisplayName";
            this.dataGridViewTextBoxColumn3.HeaderText = "DisplayName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // propertiesBindingSource
            // 
            this.propertiesBindingSource.DataMember = "Properties";
            this.propertiesBindingSource.DataSource = this.classDescriptionsBindingSource;
            // 
            // propertiesDataGridView
            // 
            this.propertiesDataGridView.AutoGenerateColumns = false;
            this.propertiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.propertiesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.propertiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.propertiesDataGridView.DataSource = this.propertiesBindingSource;
            this.propertiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesDataGridView.Location = new System.Drawing.Point(0, 16);
            this.propertiesDataGridView.Name = "propertiesDataGridView";
            this.propertiesDataGridView.Size = new System.Drawing.Size(437, 352);
            this.propertiesDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DeclaringClassDescription";
            this.dataGridViewTextBoxColumn4.HeaderText = "DeclaringClassDescription";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn6.HeaderText = "TypeName";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "TypeIsEnumerable";
            this.dataGridViewCheckBoxColumn1.HeaderText = "TypeIsEnumerable";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "TypeIsString";
            this.dataGridViewCheckBoxColumn2.HeaderText = "TypeIsString";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "HasIndexParameters";
            this.dataGridViewCheckBoxColumn3.HeaderText = "HasIndexParameters";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MemberInfo";
            this.dataGridViewTextBoxColumn7.HeaderText = "MemberInfo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn8.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DisplayName";
            this.dataGridViewTextBoxColumn9.HeaderText = "DisplayName";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class descriptions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Class members";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.classDescriptionsDataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertiesDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(909, 368);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // metadataRetrievalOptionsComboBox
            // 
            this.metadataRetrievalOptionsComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConfiguration, "MetadataRetrievalOptions", true));
            this.metadataRetrievalOptionsComboBox.FormattingEnabled = true;
            this.metadataRetrievalOptionsComboBox.Location = new System.Drawing.Point(156, 19);
            this.metadataRetrievalOptionsComboBox.Name = "metadataRetrievalOptionsComboBox";
            this.metadataRetrievalOptionsComboBox.Size = new System.Drawing.Size(121, 21);
            this.metadataRetrievalOptionsComboBox.TabIndex = 5;
            // 
            // getMemberBindingFlagsListBox
            // 
            this.getMemberBindingFlagsListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsConfiguration, "GetMemberBindingFlags", true));
            this.getMemberBindingFlagsListBox.FormattingEnabled = true;
            this.getMemberBindingFlagsListBox.Location = new System.Drawing.Point(157, 56);
            this.getMemberBindingFlagsListBox.Name = "getMemberBindingFlagsListBox";
            this.getMemberBindingFlagsListBox.Size = new System.Drawing.Size(177, 95);
            this.getMemberBindingFlagsListBox.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 400);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metadataRetrievalOptionsComboBox);
            this.tabPage1.Controls.Add(getMemberBindingFlagsLabel);
            this.tabPage1.Controls.Add(metadataRetrievalOptionsLabel);
            this.tabPage1.Controls.Add(this.getMemberBindingFlagsListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Common";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Types";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 512);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigurationForm";
            this.Text = "ConfigurationForm";
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDescriptionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsConfiguration;
        private System.Windows.Forms.BindingSource classDescriptionsBindingSource;
        private System.Windows.Forms.DataGridView classDescriptionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource propertiesBindingSource;
        private System.Windows.Forms.DataGridView propertiesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox metadataRetrievalOptionsComboBox;
        private System.Windows.Forms.ListBox getMemberBindingFlagsListBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}