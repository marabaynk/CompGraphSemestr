using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shadows
{
    public partial class FormPrizma : Form
    {
        /// <summary>
        /// Положение объекта
        /// </summary>
        internal double[] position;

        /// <summary>
        /// Индекс цвета в RGB
        /// </summary>
        internal int color;

        /// <summary>
        /// Диаметр
        /// </summary>
        internal double D;

        /// <summary>
        /// Высота
        /// </summary>
        internal double H;

        /// <summary>
        /// Количество граней призмы
        /// </summary>
        internal int N;

        public FormPrizma()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Завершение редактирования и выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            position = new double[3];
            position[0] = ShadowsForm.GetNumber(textX);
            if (double.IsNaN(position[0]))
                return;
            position[1] = ShadowsForm.GetNumber(textY);
            if (double.IsNaN(position[1]))
                return;
            position[2] = ShadowsForm.GetNumber(textZ);
            if (double.IsNaN(position[2]))
                return;
            D = ShadowsForm.GetNumber(textD);
            if (double.IsNaN(position[0]))
                return;
            H = ShadowsForm.GetNumber(textH);
            if (double.IsNaN(position[0]))
                return;
            N = comboN.SelectedIndex + 3;
            color = comboColor.SelectedIndex;
            Close();
        }
    }
}
