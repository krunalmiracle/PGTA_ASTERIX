
namespace DecerixUPC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadFile = new System.Windows.Forms.Button();
            this.DataBlock = new System.Windows.Forms.DataGridView();
            this.DataRecord = new System.Windows.Forms.DataGridView();
            this.DataItems = new System.Windows.Forms.DataGridView();
            this.ItemDetails = new System.Windows.Forms.ListBox();
            this.AsterixFileHex = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataItems)).BeginInit();
            this.SuspendLayout();
            // 
            // loadFile
            // 
            this.loadFile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.loadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadFile.Location = new System.Drawing.Point(29, 61);
            this.loadFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(218, 88);
            this.loadFile.TabIndex = 0;
            this.loadFile.Text = " Load File";
            this.loadFile.UseVisualStyleBackColor = false;
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // DataBlock
            // 
            this.DataBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBlock.Location = new System.Drawing.Point(29, 193);
            this.DataBlock.Name = "DataBlock";
            this.DataBlock.RowHeadersWidth = 62;
            this.DataBlock.RowTemplate.Height = 28;
            this.DataBlock.Size = new System.Drawing.Size(1294, 96);
            this.DataBlock.TabIndex = 2;
            // 
            // DataRecord
            // 
            this.DataRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataRecord.Location = new System.Drawing.Point(29, 308);
            this.DataRecord.Name = "DataRecord";
            this.DataRecord.RowHeadersWidth = 62;
            this.DataRecord.RowTemplate.Height = 28;
            this.DataRecord.Size = new System.Drawing.Size(1294, 81);
            this.DataRecord.TabIndex = 3;
            // 
            // DataItems
            // 
            this.DataItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataItems.Location = new System.Drawing.Point(29, 407);
            this.DataItems.Name = "DataItems";
            this.DataItems.RowHeadersWidth = 62;
            this.DataItems.RowTemplate.Height = 28;
            this.DataItems.Size = new System.Drawing.Size(680, 351);
            this.DataItems.TabIndex = 4;
            // 
            // ItemDetails
            // 
            this.ItemDetails.FormattingEnabled = true;
            this.ItemDetails.ItemHeight = 20;
            this.ItemDetails.Location = new System.Drawing.Point(738, 407);
            this.ItemDetails.Name = "ItemDetails";
            this.ItemDetails.Size = new System.Drawing.Size(585, 284);
            this.ItemDetails.TabIndex = 5;
            // 
            // AsterixFileHex
            // 
            this.AsterixFileHex.Location = new System.Drawing.Point(296, 42);
            this.AsterixFileHex.Multiline = true;
            this.AsterixFileHex.Name = "AsterixFileHex";
            this.AsterixFileHex.Size = new System.Drawing.Size(1027, 130);
            this.AsterixFileHex.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1367, 770);
            this.Controls.Add(this.AsterixFileHex);
            this.Controls.Add(this.ItemDetails);
            this.Controls.Add(this.DataItems);
            this.Controls.Add(this.DataRecord);
            this.Controls.Add(this.DataBlock);
            this.Controls.Add(this.loadFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.DataGridView DataBlock;
        private System.Windows.Forms.DataGridView DataRecord;
        private System.Windows.Forms.DataGridView DataItems;
        private System.Windows.Forms.ListBox ItemDetails;
        private System.Windows.Forms.TextBox AsterixFileHex;
    }
}

