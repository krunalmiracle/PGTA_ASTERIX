
namespace DecerixUPC
{
    partial class DecodeFile
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
            this.AsterixFileHex = new System.Windows.Forms.TextBox();
            this.FieldType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataItems)).BeginInit();
            this.SuspendLayout();
            // 
            // loadFile
            // 
            this.loadFile.BackColor = System.Drawing.Color.LightSeaGreen;
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
            this.DataBlock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBlock.GridColor = System.Drawing.Color.LightSeaGreen;
            this.DataBlock.Location = new System.Drawing.Point(29, 203);
            this.DataBlock.Margin = new System.Windows.Forms.Padding(10);
            this.DataBlock.Name = "DataBlock";
            this.DataBlock.RowHeadersWidth = 62;
            this.DataBlock.RowTemplate.Height = 28;
            this.DataBlock.Size = new System.Drawing.Size(538, 183);
            this.DataBlock.TabIndex = 2;
            this.DataBlock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBlock_CellContentClick);
            // 
            // DataRecord
            // 
            this.DataRecord.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataRecord.GridColor = System.Drawing.Color.LightSeaGreen;
            this.DataRecord.Location = new System.Drawing.Point(586, 203);
            this.DataRecord.Name = "DataRecord";
            this.DataRecord.RowHeadersWidth = 62;
            this.DataRecord.RowTemplate.Height = 28;
            this.DataRecord.Size = new System.Drawing.Size(737, 183);
            this.DataRecord.TabIndex = 3;
            this.DataRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataRecord_CellContentClick);
            // 
            // DataItems
            // 
            this.DataItems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataItems.GridColor = System.Drawing.Color.LightSeaGreen;
            this.DataItems.Location = new System.Drawing.Point(29, 407);
            this.DataItems.Name = "DataItems";
            this.DataItems.RowHeadersWidth = 62;
            this.DataItems.RowTemplate.Height = 28;
            this.DataItems.Size = new System.Drawing.Size(782, 342);
            this.DataItems.TabIndex = 4;
            this.DataItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataItems_CellContentClick);
            // 
            // AsterixFileHex
            // 
            this.AsterixFileHex.ForeColor = System.Drawing.Color.Black;
            this.AsterixFileHex.Location = new System.Drawing.Point(296, 42);
            this.AsterixFileHex.Multiline = true;
            this.AsterixFileHex.Name = "AsterixFileHex";
            this.AsterixFileHex.Size = new System.Drawing.Size(1027, 130);
            this.AsterixFileHex.TabIndex = 6;
            // 
            // FieldType
            // 
            this.FieldType.Location = new System.Drawing.Point(849, 407);
            this.FieldType.Multiline = true;
            this.FieldType.Name = "FieldType";
            this.FieldType.Size = new System.Drawing.Size(474, 342);
            this.FieldType.TabIndex = 7;
            // 
            // DecodeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1367, 770);
            this.Controls.Add(this.FieldType);
            this.Controls.Add(this.AsterixFileHex);
            this.Controls.Add(this.DataItems);
            this.Controls.Add(this.DataRecord);
            this.Controls.Add(this.DataBlock);
            this.Controls.Add(this.loadFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DecodeFile";
            this.Text = "UPC DECERIX";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.TextBox AsterixFileHex;
        private System.Windows.Forms.TextBox FieldType;
    }
}

