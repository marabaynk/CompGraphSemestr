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
    public partial class ShadowsForm : Form
    {
        /// <summary>
        /// Строки для ввода положения камеры
        /// </summary>
        TextBox[] textCameraPos;

        /// <summary>
        /// Строки для ввода положения источника 1
        /// </summary>
        TextBox[] textSource1Pos;

        /// <summary>
        /// Строки для ввода положения источника 2
        /// </summary>
        TextBox[] textSource2Pos;

        /// <summary>
        /// Инициализация компонентов формы
        /// </summary>
        public ShadowsForm()
        {
            InitializeComponent();
            scene = new CScene();
            textCameraPos = new TextBox[3];
            textCameraPos[0] = textCameraX;
            textCameraPos[1] = textCameraY;
            textCameraPos[2] = textCameraZ;
            textSource1Pos = new TextBox[3];
            textSource1Pos[0] = textSource1X;
            textSource1Pos[1] = textSource1Y;
            textSource1Pos[2] = textSource1Z;
            textSource2Pos = new TextBox[3];
            textSource2Pos[0] = textSource2X;
            textSource2Pos[1] = textSource2Y;
            textSource2Pos[2] = textSource2Z;
        }

        /// <summary>
        /// Функция переводит текст в число. Если текст не является числом, то функция выводит
        /// сообщение об этом, выбирает для редактирования элемент с некорректным текстом. 
        /// </summary>
        /// <param name="box">Элемент с текстом для перевода в число</param>
        /// <returns>Число из текста. Если текст не представляет число, то функция возвращает NaN (не число)</returns>
        static internal double GetNumber(TextBoxBase box)
        {
            double ret; //Возвращаемое значение
            if (double.TryParse(box.Text, out ret))
                return ret;
            box.Focus();
            MessageBox.Show("Некорректно задано число.");
            return double.NaN;
        }

        /// <summary>
        /// Сцена
        /// </summary>
        CScene scene;

        /// <summary>
        /// Создаёт новую пустую сцену
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новаяСценаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new CScene();
        }

        /// <summary>
        /// Удалить последнее вставленное тело
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scene.cSurfaces.Count > 0)
                scene.cSurfaces.RemoveAt(scene.cSurfaces.Count - 1);
            MessageBox.Show("Удалена последняя модель");
        }

        /// <summary>
        /// Добавить в сцену цилиндр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void цилиндрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCylinder d = new FormCylinder();
            if (d.ShowDialog() == DialogResult.OK)
            {
                double step;
                if (double.TryParse(comboStep.Text, out step))
                    scene.cSurfaces.Add(new CCylinder(d.position, d.color, d.D, d.H, step));
                else MessageBox.Show("Некоректно задан шаг разбиения.");
            }
        }

        /// <summary>
        /// Добавить в сцену конус
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void конусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConus d = new FormConus();
            if (d.ShowDialog() == DialogResult.OK)
            {
                double step;
                if (double.TryParse(comboStep.Text, out step))
                    scene.cSurfaces.Add(new CConus(d.position, d.color, d.D, d.H, step));
                else MessageBox.Show("Некоректно задан шаг разбиения.");
            }
        }

        /// <summary>
        /// Добавить в сцену куб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void кубToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCube d = new FormCube();
            if (d.ShowDialog() == DialogResult.OK)
            {
                double step;
                if (double.TryParse(comboStep.Text, out step))
                    scene.cSurfaces.Add(new CCube(d.position, d.color, d.D, (int)(d.D / step)));
                else MessageBox.Show("Некоректно задан шаг разбиения.");
            }
        }

        /// <summary>
        /// Добавить в сцену призму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void призмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrizma d = new FormPrizma();
            if (d.ShowDialog() == DialogResult.OK)
            {
                double step;
                if (double.TryParse(comboStep.Text, out step))
                    scene.cSurfaces.Add(new CPrizma(d.position, d.color, d.D, d.H, d.N, step));
                else MessageBox.Show("Некоректно задан шаг разбиения.");
            }
        }

        /// <summary>
        /// Провести расчёт и отобразить на экране сцену
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShow_Click_1(object sender, EventArgs e)
        {
            //Считать параметры из формы
            for (int i = 0; i < 3; i++)
            {
                scene.Camera[i] = GetNumber(textCameraPos[i]);
                if (double.IsNaN(scene.Camera[i]))
                    return;
            }
            eSource tSource = (eSource)comboSource1.SelectedIndex; //Тип источника
            double[] source = new double[3]; //Положение источника
            double SourceSize = GetNumber(textSource1Size);
            if (double.IsNaN(SourceSize))
                return;
            for (int i = 0; i < 3; i++)
            {
                source[i] = GetNumber(textSource1Pos[i]);
                if (double.IsNaN(source[i]))
                    return;
            }
            scene.sources[0] = new CSource(tSource, source[0], source[1], source[2], SourceSize);
            if (checkSources.Checked)
            {
                tSource = (eSource)comboSource2.SelectedIndex; //Тип источника
                for (int i = 0; i < 3; i++)
                {
                    source[i] = GetNumber(textSource2Pos[i]);
                    if (double.IsNaN(source[i]))
                        return;
                }
                SourceSize = GetNumber(textSource2Size);
                if (double.IsNaN(SourceSize))
                    return;
                scene.sources[1] = new CSource(tSource, source[0], source[1], source[2], SourceSize);
            }
            else scene.sources[1] = null; //Второго источника нет

            long start = DateTime.Now.Ticks;
            //Определить освещённость вершин
            scene.ClearTops();
            scene.Move();
            scene.DefineSources();
            scene.DefineBrightness();

            //Определить матрицу перепроектирования вершин в систему координат, связанную с камерой
            double[,] A = new double[3, 3]; //Матрица, расчитанная по направлению на камеру
            double l = Math.Sqrt(scene.Camera[0] * scene.Camera[0] + scene.Camera[1] * scene.Camera[1] + scene.Camera[2] * scene.Camera[2]);
            if (l == 0)
            {
                MessageBox.Show("Камера находится в центре сцены");
                return;
            }
            for (int i = 0; i < 3; i++)
                A[2, i] = scene.Camera[i] / l;
            if (Math.Abs(scene.Camera[1]) > Math.Abs(scene.Camera[0]))
            {
                A[0, 0] = 1 - A[2, 0] * A[2, 0];
                A[0, 1] = -A[2, 0] * A[2, 1];
                A[0, 2] = -A[2, 0] * A[2, 2];
                l = Math.Sqrt(A[0, 0] * A[0, 0] + A[0, 1] * A[0, 1] + A[0, 2] * A[0, 2]);
                A[0, 0] /= l;
                A[0, 1] /= l;
                A[0, 2] /= l;
                A[1, 0] = A[0, 2] * A[2, 1] - A[0, 1] * A[2, 2];
                A[1, 1] = A[0, 0] * A[2, 2] - A[0, 2] * A[2, 0];
                A[1, 2] = A[0, 1] * A[2, 0] - A[0, 0] * A[2, 1];
            }
            else
            {
                A[1, 0] = -A[2, 0] * A[2, 1];
                A[1, 1] = 1 - A[2, 1] * A[2, 1];
                A[1, 2] = -A[2, 1] * A[2, 2];
                l = Math.Sqrt(A[1, 0] * A[1, 0] + A[1, 1] * A[1, 1] + A[1, 2] * A[1, 2]);
                A[1, 0] /= l;
                A[1, 1] /= l;
                A[1, 2] /= l;
                A[0, 0] = A[1, 1] * A[2, 2] - A[1, 2] * A[2, 1];
                A[0, 1] = A[1, 2] * A[2, 0] - A[1, 0] * A[2, 2];
                A[0, 2] = A[1, 0] * A[2, 1] - A[1, 1] * A[2, 0];
            }

            CPixel[,] region = new CPixel[picture.Size.Width, picture.Size.Height];
            scene.MakeMap(A, region);

            //Формирование и вывод картинки
            Bitmap map = new Bitmap(region.GetLength(0), region.GetLength(1));
            for (int x = 0; x < map.Width; x++)
                for (int y = 0; y < map.Height; y++)
                    if (region[x, y] != null)
                        map.SetPixel(x, y, region[x, y].Brightness);
                    else map.SetPixel(x, y, Color.White);
            picture.Image = map;

            //Результаты тайминга в статусную строку
            long DrawInterval = DateTime.Now.Ticks - start; //Продолжительность расчёта и построения картинки в тиках по 0.0001 мс
            statusLabel.Text = " Время выполнения=" + ((DrawInterval + 500) / 10000).ToString() + " мс";
        }
    }
}
 