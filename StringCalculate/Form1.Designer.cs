namespace StringCalculate
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbResult = new System.Windows.Forms.TextBox();
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.поверхВсехОконToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelTBWindow = new System.Windows.Forms.Panel();
            this.tbExpression = new System.Windows.Forms.TextBox();
            this.pnBtnFuncPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.PanelTBWindow.SuspendLayout();
            this.pnBtnFuncPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbResult.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.tbResult.Location = new System.Drawing.Point(8, 38);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbResult.Size = new System.Drawing.Size(491, 24);
            this.tbResult.TabIndex = 2;
            this.tbResult.TabStop = false;
            this.tbResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PanelTitle
            // 
            this.PanelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.PanelTitle.ContextMenuStrip = this.contextMenuStrip1;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(509, 13);
            this.PanelTitle.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поверхВсехОконToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 48);
            // 
            // поверхВсехОконToolStripMenuItem
            // 
            this.поверхВсехОконToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.поверхВсехОконToolStripMenuItem.Name = "поверхВсехОконToolStripMenuItem";
            this.поверхВсехОконToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.поверхВсехОконToolStripMenuItem.Text = "Поверх всех окон";
            this.поверхВсехОконToolStripMenuItem.CheckedChanged += new System.EventHandler(this.поверхВсехОконToolStripMenuItem_CheckedChanged);
            this.поверхВсехОконToolStripMenuItem.Click += new System.EventHandler(this.поверхВсехОконToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.закрытьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // PanelTBWindow
            // 
            this.PanelTBWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTBWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PanelTBWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTBWindow.Controls.Add(this.tbExpression);
            this.PanelTBWindow.Controls.Add(this.tbResult);
            this.PanelTBWindow.Location = new System.Drawing.Point(0, 12);
            this.PanelTBWindow.Name = "PanelTBWindow";
            this.PanelTBWindow.Size = new System.Drawing.Size(509, 73);
            this.PanelTBWindow.TabIndex = 19;
            // 
            // tbExpression
            // 
            this.tbExpression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.tbExpression.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.tbExpression.Location = new System.Drawing.Point(8, 6);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(493, 33);
            this.tbExpression.TabIndex = 22;
            this.tbExpression.TextChanged += new System.EventHandler(this.tbExpression_TextChanged);
            // 
            // pnBtnFuncPanel
            // 
            this.pnBtnFuncPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBtnFuncPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnBtnFuncPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBtnFuncPanel.Controls.Add(this.button1);
            this.pnBtnFuncPanel.Location = new System.Drawing.Point(0, 84);
            this.pnBtnFuncPanel.Name = "pnBtnFuncPanel";
            this.pnBtnFuncPanel.Size = new System.Drawing.Size(509, 43);
            this.pnBtnFuncPanel.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(223, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 222;
            this.button1.TabStop = false;
            this.button1.Text = "Sin";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(509, 236);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.PanelTBWindow);
            this.Controls.Add(this.pnBtnFuncPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "Калькулятор";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.PanelTBWindow.ResumeLayout(false);
            this.PanelTBWindow.PerformLayout();
            this.pnBtnFuncPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Panel PanelTitle;
        private System.Windows.Forms.Panel pnBtnFuncPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Panel PanelTBWindow;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.ToolStripMenuItem поверхВсехОконToolStripMenuItem;
    }
}

