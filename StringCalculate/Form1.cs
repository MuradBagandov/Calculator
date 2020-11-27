using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Numerics;

namespace StringCalculate
{
    public partial class Form1 : Form
    {
        #region Импорт API Windows
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;
        #endregion

        bool pnBtnFuncPanelvar = false;
        bool pnBtnFuncPanelisChanged = false;
        bool isClosed = false;
        bool isShow = true;
        public Form1()
        {
            InitializeComponent();

            tbExpression.GotFocus += (s, e) => { InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US")); };
            PanelTitle.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
            };

            tbExpression.KeyPress += (s, e) =>
            {
                if (e.KeyChar == ' ' || e.KeyChar >= 'а' && e.KeyChar <= 'я' || e.KeyChar >= 'А' && e.KeyChar <= 'Я') e.Handled = true;
            };
            tbExpression.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Space)
                    EffectAppearanceAsync(pnBtnFuncPanelvar == true ? false : true);
            };

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //string testStr = @"-2+2-((2+2*2)^(2-2))";
            //sw.Start();
            //for (int i = 0; i < 100000; i++)
            //    CalculateRPN.CalcalateExpression(testStr, out bool err);
            //sw.Stop();
            //MessageBox.Show(sw.ElapsedMilliseconds.ToString());

            List<string> ListElements = new List<string>();
            List<Button> ListBtnElements = new List<Button>();

            foreach (string item in CalculateRPN.PrefixFunctions.Keys)
                ListElements.Add(item);

            foreach (string item in CalculateRPN.MathConsts.Keys)
                ListElements.Add(item);

            int rowCount = 0, columnCount = 0;
            int countLeft = 0, countTop = 0;

            int countElement = ListElements.Count();

            columnCount = (int)Math.Floor((double)pnBtnFuncPanel.Width / (button1.Width + 2));
            rowCount = (int)Math.Ceiling((double)countElement / columnCount);
            if (columnCount > countElement) columnCount = countElement;

            int indentLeft = (int)Math.Round((pnBtnFuncPanel.Width / (button1.Width + 2f) - columnCount) * button1.Width);
            indentLeft = (int)Math.Round((indentLeft - 8f) / columnCount);
            button1.Width += indentLeft;

            pnBtnFuncPanel.Height = rowCount * (button1.Height + 2) + 8;
            pnBtnFuncPanel.Top = pnBtnFuncPanel.Top - pnBtnFuncPanel.Height;

            this.Height = pnBtnFuncPanel.Height + PanelTitle.Height + PanelTBWindow.Height;

            foreach (string str in ListElements)
            {

                ListBtnElements.Add(new Button());
                int sCount = ListBtnElements.Count - 1;

                if (countLeft == columnCount) { countLeft = 0; countTop += 1; }

                ListBtnElements[sCount].Left = button1.Left;
                ListBtnElements[sCount].Top = button1.Top;
                ListBtnElements[sCount].Width = button1.Width;
                ListBtnElements[sCount].Height = button1.Height;
                ListBtnElements[sCount].BackColor = button1.BackColor;
                ListBtnElements[sCount].FlatStyle = button1.FlatStyle;
                ListBtnElements[sCount].ForeColor = button1.ForeColor;
                ListBtnElements[sCount].FlatAppearance.BorderSize = button1.FlatAppearance.BorderSize;
                ListBtnElements[sCount].FlatAppearance.BorderColor = button1.FlatAppearance.BorderColor;
                ListBtnElements[sCount].Font = button1.Font;
                ListBtnElements[sCount].Text = str;
                ListBtnElements[sCount].Name = "Function";

                ListBtnElements[sCount].Left = countLeft * (ListBtnElements[0].Width + 2) + 5;
                ListBtnElements[sCount].Top = countTop * (ListBtnElements[0].Height + 2) + 4;
                countLeft += 1;

                if (CalculateRPN.MathConsts.ContainsKey(str))
                {
                    ListBtnElements[sCount].Name = "Const";
                    ListBtnElements[sCount].ForeColor = PanelTitle.BackColor;
                }

                ListBtnElements[sCount].MouseDown += (s, a) => { BtnClick(ListBtnElements[sCount], a.Button == MouseButtons.Left ? true : false); };
                ListBtnElements[sCount].KeyDown += (s, a) => { if (a.KeyCode == Keys.Space) BtnClick(ListBtnElements[sCount], true); };
                pnBtnFuncPanel.Controls.Add(ListBtnElements[sCount]);
            }

            void BtnClick(Button btn, bool TypeAdd)
            {
                if (btn.Name == "Function")
                {
                    if (TypeAdd)
                    {
                        tbExpression.SelectedText = btn.Text + "()";
                        tbExpression.SelectionStart -= 1;
                    }
                    else
                    {
                        string tmp = tbExpression.SelectedText;
                        tbExpression.SelectedText = btn.Text + "(" + tmp + ")";
                        tbExpression.SelectionStart -= 1;
                    }
                }
                else
                    tbExpression.SelectedText = btn.Text;
                tbExpression.Focus();
            }
            EffectAppearanceFormAsync();

        }

        private void tbExpression_TextChanged(object sender, EventArgs e)
        {
            double result = CalculateRPN.CalcalateExpression(tbExpression.Text, out bool isErr);

            if (tbExpression.TextLength > 0)
                tbResult.Text = isErr == true ? "Неккоректный ввод " : 
                    double.IsInfinity(result) == true ? "\u221E " : 
                    Math.Abs(result) > 999999999999999 ? result.ToString() + " " : 
                    result.ToString("#,0.###############") + " ";
            else
                tbResult.Text = "";
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e) { isClosed = true;  Close();  }

        async public void EffectAppearanceFormAsync()
        {
            for (double i = 0; i <= 1; i += 0.05)
            {
                Opacity = i;
                await Task.Delay(20);
            }
        }
        async public void EffectAppearanceAsync(bool isShow)
        {
            if (pnBtnFuncPanelisChanged) return;
            pnBtnFuncPanelisChanged = true;
            if (isShow)
            {
                while (pnBtnFuncPanel.Top < 84)
                {
                    if (84 - pnBtnFuncPanel.Top < 4)
                        pnBtnFuncPanel.Top += 84 - pnBtnFuncPanel.Top;
                    else
                        pnBtnFuncPanel.Top += 4;
                    await Task.Delay(1);
                }
                pnBtnFuncPanelvar = true;
            }
            else
            {
                while (84 - pnBtnFuncPanel.Height < pnBtnFuncPanel.Top)
                {
                    pnBtnFuncPanel.Top -= 4;
                    await Task.Delay(1);
                }
                pnBtnFuncPanelvar = false;
            }
            pnBtnFuncPanelisChanged = false;
        }

        private void поверхВсехОконToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = поверхВсехОконToolStripMenuItem.Checked;
        }

        private void поверхВсехОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            поверхВсехОконToolStripMenuItem.Checked = поверхВсехОконToolStripMenuItem.Checked == true? false:true;
        }
    }
}
