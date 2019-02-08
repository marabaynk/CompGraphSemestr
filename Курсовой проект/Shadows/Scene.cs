using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shadows
{

    /// <summary>
    /// Описание сцены
    /// </summary>
    internal class CScene
    {
        /// <summary>
        /// Список моделей
        /// </summary>
        internal List<CSurface> cSurfaces;

        /// <summary>
        /// Источники света. Максимум 2.
        /// </summary>
        internal CSource[] sources;

        /// <summary>
        /// Положение камеры
        /// </summary>
        internal double[] Camera;

        /// <summary>
        /// Создаёт сцену
        /// </summary>
        /// <param name="C">Положение камеры</param>
        internal CScene()
        {
            cSurfaces = new List<CSurface>();
            sources = new CSource[2];
            Camera = new double[3];
        }

        /// <summary>
        /// Очищает массивы источников и яркость всх вершин
        /// </summary>
        internal void ClearTops()
        {
            foreach (CSurface surface in cSurfaces)
                foreach (CTop top in surface.tops)
                    top.Clear();
        }

        /// <summary>
        /// Перемещение вершин на вектор тела
        /// </summary>
        internal void Move()
        {
            foreach (CSurface surface in cSurfaces)
                foreach (CTop top in surface.tops)
                    for (int i = 0; i < 3; i++)
                        top.pos[i] = top.position[i] + surface.position[i];
        }

        /// <summary>
        /// Определяет детерминант матицы, образованной векторами v1, v2, v3
        /// </summary>
        /// <param name="v1">Вектор 1</param>
        /// <param name="v2">Вектор 2</param>
        /// <param name="v3">Вектор 3</param>
        /// <returns>Детерминант вектора</returns>
        static private double Det(double[] v1, double[] v2, double[] v3)
        {
            return v1[0] * (v2[1] * v3[2] - v2[2] * v3[1]) +
                v1[1] * (v2[2] * v3[0] - v2[0] * v3[2]) +
                v1[2] * (v2[0] * v3[1] - v2[1] * v3[0]);
        }

        /// <summary>
        /// Определить затенение пикселя p треугольником с вершинами t1, t2, 3
        /// </summary>
        /// <param name="pi">Координаты источника относительно пикселя, затенение которой проверяется</param>
        /// <param name="t1">Координаты источника относительно вершины треугольника 1</param>
        /// <param name="t2">Координаты источника относительно вершины треугольника 2</param>
        /// <param name="t3">Координаты источника относительно вершины треугольника 3</param>
        /// <returns>true, если затенён. false, если не затенён</returns>
        static private bool Shading(double[] pi, double[] t1, double[] t2, double[] t3)
        {
            double[] p = {pi[0] + (pi[0] > 0.5 ? -1 : pi[0] < -0.5 ? 1 : 0), //Приближаем на пиксель к источнику
                pi[1] + (pi[1] > 0.5 ? -1 : pi[1] < -0.5 ? 1 : 0),
                pi[2] + (pi[2] > 0.5 ? -1 : pi[2] < -0.5 ? 1 : 0)};
            //Определить пересечение вектора источника с плоскостью треугольника
            double[] l2 = { t3[0] - t1[0], t3[1] - t1[1], t3[2] - t1[2] };
            double[] l3 = { t2[0] - t1[0], t2[1] - t1[1], t2[2] - t1[2] };
            double[] v0 = { l2[0], l3[0], -p[0] };
            double[] v1 = { l2[1], l3[1], -p[1] };
            double[] v2 = { l2[2], l3[2], -p[2] };
            double D = Det(v0, v1, v2);
            if (Math.Abs(D) < 1)
                return false; //Вырожденный треугольник
            v0[2] = -t1[0];
            v1[2] = -t1[1];
            v2[2] = -t1[2];
            double a = Det(v0, v1, v2) / D;
            if (a < 0 || a > 1)
                return false; //вершина перед треугольником или треугольник перед источником
            double[] pt = { a * p[0], a * p[1], a * p[2] }; //Пересечения вектора источника с плоскостью треугольника

            //Расчёт нахождения pt внутри треугольника
            double[] dp = { pt[0] - t1[0], pt[1] - t1[1], pt[2] - t1[2] };
            double[] dt = { t2[0] - t3[0], t2[1] - t3[1], t2[2] - t3[2] };
            double[] tau = { t2[0] - t1[0], t2[1] - t1[1], t2[2] - t1[2] };
            double[] de = { 0, 0, 0 };
            D = 0;
            int k = 0; //Индекс начальной координаты лучшего варианта
            int i1; //Следующая координата
            for (int i = 0; i < 3; i++)
            {
                i1 = (i + 1) % 3;
                de[i] = dp[i] * dt[i1] - dp[i1] * dt[i];
                if (Math.Abs(de[i]) > D)
                {
                    D = Math.Abs(de[i]);
                    k = i;
                }
            }
            i1 = (k + 1) % 3;
            a = (tau[k] * dt[i1] - tau[i1] * dt[k]) / de[k];
            if (a < 1)
                return false;
            double b = (dp[k] * tau[i1] - dp[i1] * tau[k]) / de[k];
            return b > 0 && b < 1;
        }

        /// <summary>
        /// Проверяем затенённость пикселя каким-либо треугольником
        /// </summary>
        /// <param name="top">Вершина, затенённость которой проверяется</param>
        /// <param name="iS">Индекс источника света</param>
        /// <param name="A">Матрица перехода из системы координат сцены в систему координат камеры</param>
        private void DetermShading(CPixel px, int iS, double[,] A)
        {
            double[] v = new double[3]; //Координаты вектора от пикселя к источнику света в С. К. сцены
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    v[i] += px.V[j] * A[j, i];
            for (int i = 0; i < 3; i++)
                v[i] = sources[iS].position[i] - v[i];
            foreach (CSurface surface in cSurfaces)
                foreach (CTriangle t in surface.triangles)
                    if (t.distance2[iS] < v[0] * v[0] + v[1] * v[1] + v[2] * v[2])
                    {//Поиск треугольника, заслоняющего вершину. Сразу же отбрасываются треугольники, отстоящие от источника дальше, чем пиксель.
                        int[] iTops = t.iTops; //Индексы вершин треугольника
                        if (Shading(v, t.surface.tops[iTops[0]].sources[iS],
                        t.surface.tops[iTops[1]].sources[iS], t.surface.tops[iTops[2]].sources[iS]))
                        {
                            px.brightness[iS] = 0;
                            return;
                        }
                    }
        }

        /// <summary>
        /// Определяет наличие освещённости вершин заданными источниками без учёта затенения
        /// </summary>
        internal void DefineSources()
        {
            //Определим источники, освещающие каждую вершину. 
            for (int i = 0; i < 2; i++)
                if (sources[i] != null)
                    foreach (CSurface surface in cSurfaces)
                        foreach (CTop top in surface.tops)
                        {
                            double[] v = {sources[i].position[0] - top.pos[0],
                                    sources[i].position[1] - top.pos[1], sources[i].position[2] - top.pos[2]};
                            top.sources[i] = v;
                            double nv = v[0] * top.N[0] + v[1] * top.N[1] + v[2] * top.N[2];
                            if (nv > 0)
                                top.src[i] = sources[i];
                            top.distance2[i] = v[0] * v[0] + v[1] * v[1] + v[2] * v[2];
                        }

            //Определим distance2 для треугольников
            foreach (CSurface surface in cSurfaces)
                foreach (CTriangle t in surface.triangles)
                    for (int iS = 0; iS < 2; iS++) //Цикл по источникам
                    {
                        t.distance2[iS] = surface.tops[t.iTops[0]].distance2[iS];
                        for (int i = 1; i < 3; i++)
                            if (t.distance2[iS] > surface.tops[t.iTops[i]].distance2[iS])
                                t.distance2[iS] = surface.tops[t.iTops[i]].distance2[iS];
                    }
        }

        /// <summary>
        /// Определяет освещённость вершин и направления на источник
        /// </summary>
        internal void DefineBrightness()
        {
            for (int i = 0; i < 2; i++)
                if (sources[i] != null)
                    foreach (CSurface surface in cSurfaces)
                        foreach (CTop top in surface.tops)
                            if (top.src[i] != null)
                            {
                                double[] v = {sources[i].position[0] - top.pos[0], sources[i].position[1] - top.pos[1], sources[i].position[2] - top.pos[2] };
                                top.sources[i] = v;
                                double v2 = sources[i].type == eSource.eDotted ? v[0] * v[0] + v[1] * v[1] + v[2] * v[2]
                                    : (v[0] - sources[i].size) * (v[0] - sources[i].size) + (v[1] - sources[i].size) * (v[1] - sources[i].size) + (v[2] - sources[i].size) * (v[2] - sources[i].size); //Источник неточечный
                                double mv = Math.Sqrt(v2);
                                double nv = v[0] * top.N[0] + v[1] * top.N[1] + v[2] * top.N[2];
                                if (nv > 0)
                                    top.brightness[i] = nv / mv / v2;
                            }
        }

        /// <summary>
        /// Умножение матрицы на вектор
        /// </summary>
        /// <param name="M">Матрица</param>
        /// <param name="V">Вектор</param>
        /// <returns>Результат умножения</returns>
        static private double[] Times(double[,] M, double[] V)
        {
            double[] res = new double[3]; //Результат умножения
            for (int i = 0; i < 3; i++)
            {
                double d = 0;
                for (int l = 0; l < 3; l++)
                    d += M[i, l] * V[l];
                res[i] = d;
            }
            return res;
        }

        /// <summary>
        /// Создаёт область пикселей, определяет затенённость треугольниками, нормализует яркость
        /// </summary>
        /// <param name="A">Матрица перепроектирования в систему координат, связанную с камерой</param>
        internal void MakeMap(double[,] A, CPixel[,] region)
        {
            foreach (CSurface surface in cSurfaces)
                foreach (CTriangle t in surface.triangles)
                {
                    double[][] position = new double[3][]; //Координаты вершин треугольника в связанной с камерой системой координат
                    for (int i = 0; i < 3; i++)
                        position[i] = Times(A, surface.tops[t.iTops[i]].pos);

                    //Формирует область пикселей
                    int[] iY = { t.iTops[0], t.iTops[1], t.iTops[2] }; //Индексы вершин в порядке уменьшения компоненты Y
                    int[] iP = { 0, 1, 2 };

                    //Расположить вершины в порядке уменьшения координаты Y
                    int k;
                    if (position[0][1] < position[1][1])
                    {
                        k = iY[1];
                        iY[1] = iY[0];
                        iY[0] = k;
                        iP[0] = 1;
                        iP[1] = 0;
                    }
                    if (position[iP[1]][1] < position[iP[2]][1])
                    {
                        k = iY[2];
                        iY[2] = iY[1];
                        iY[1] = k;
                        k = iP[2];
                        iP[2] = iP[1];
                        iP[1] = k;
                    }
                    if (position[iP[0]][1] < position[iP[1]][1])
                    {
                        k = iY[1];
                        iY[1] = iY[0];
                        iY[0] = k;
                        k = iP[1];
                        iP[1] = iP[0];
                        iP[0] = k;
                    }

                    //Вычисление яркости пикселей, входящих в поверхность тела
                    int y0 = region.GetLength(1) / 2; //Смещение 0 оси y относительно верхнего края картинки
                    int x0 = region.GetLength(0) / 2; //Смещение 0 оси x относительно левого края картинки
                    int ye = region.GetLength(1) - y0; //Смещение нижнего края картинки относительно начала координат
                    int xe = region.GetLength(0) - x0; //Смещение правого края картинки относительно начала координат
                    double dy1 = position[iP[1]][1] - position[iP[0]][1];
                    double dy2 = position[iP[2]][1] - position[iP[0]][1];
                    double k1 = dy1 > -0.01 ? 0 : (position[iP[1]][0] - position[iP[0]][0]) / dy1;
                    double k2 = dy2 > -0.01 ? 0 : (position[iP[2]][0] - position[iP[0]][0]) / dy2;
                    double xa = position[iP[0]][0];
                    double yk = position[iP[1]][1];
                    double yb = position[iP[0]][1];
                    if (yb < -y0 + 1) //Ограничение по верхней границе области
                        yb = -y0 + 1;
                    if (yb >= ye) //Ограничение по нижней границе
                        yb = ye - 1;
                    if (yk > ye - 1) //Ограничение по нижней границе
                        yk = ye - 1;
                    if (yk < -y0 + 1) //Ограничение по верхней границе области
                        yk = -y0 + 1;
                    for (double y = yb; y >= yk; y -= 1)
                    {
                        double[] brightnessS = new double[2]; //Яркости начальной точки линии
                        for (int i = 0; i < 2; i++)
                            brightnessS[i] = dy1 > -0.01 ? t.surface.tops[iY[0]].brightness[i] //Когда вся линия расположена по горизонтали
                                : t.surface.tops[iY[0]].brightness[i] + (t.surface.tops[iY[1]].brightness[i] - t.surface.tops[iY[0]].brightness[i]) / dy1 * (y - position[iP[0]][1]);
                        double[] brightnessF = new double[2]; //Яркости конечной точки линии
                        for (int i = 0; i < 2; i++)
                            brightnessF[i] = dy2 > -0.01 ? t.surface.tops[iY[2]].brightness[i] //Когда вся линия расположена по горизонтали
                                : t.surface.tops[iY[0]].brightness[i] + (t.surface.tops[iY[2]].brightness[i] - t.surface.tops[iY[0]].brightness[i]) / dy2 * (y - position[iP[0]][1]);
                        double xsd = xa + k1 * (y - position[iP[0]][1]);
                        double xfd = xa + k2 * (y - position[iP[0]][1]);
                        double zb = dy1 > -0.01 ? position[iP[0]][2] //Когда вся линия расположена по горизонтали
                            : position[iP[0]][2] + (position[iP[1]][2] - position[iP[0]][2]) / dy1 * (y - position[iP[0]][1]);
                        double ze = dy2 > -0.01 ? position[iP[2]][2] //Когда вся линия расположена по горизонтали
                            : position[iP[0]][2] + (position[iP[2]][2] - position[iP[0]][2]) / dy2 * (y - position[iP[0]][1]);
                        if (xsd > xfd)
                        {//Поменять местами, чтобы xs была всегда меньше xf
                            double xm = xsd;
                            xsd = xfd;
                            xfd = xm;
                            for (int i = 0; i < 2; i++)
                            {
                                double b = brightnessS[i];
                                brightnessS[i] = brightnessF[i];
                                brightnessF[i] = b;
                            }
                            double d = zb;
                            zb = ze;
                            ze = d;
                        }
                        double dx = xfd - xsd;
                        if (dx < 1)
                            dx = 1;
                        double[] grad = { (brightnessF[0] - brightnessS[0]) / dx, (brightnessF[1] - brightnessS[1]) / dx }; //Градиент яркости по горизонтали
                        double gradZ = (ze - zb) / dx;
                        xfd += 0.5;
                        int xs = (int)xsd;
                        int xf = (int)Math.Round(xfd);
                        if (xs < -x0) //Ограничение по левой границе
                        {
                            brightnessS[0] += (-x0 - xs) * grad[0];
                            brightnessS[1] += (-x0 - xs) * grad[1];
                            zb += (-x0 - xs) * gradZ;
                            xs = -x0;
                        }
                        if (xf >= xe) //Ограничение по правой границе
                        {
                            brightnessF[0] -= (xf - xe) * grad[0];
                            brightnessF[1] -= (xf - xe) * grad[1];
                            ze -= (xf - xe) * gradZ;
                            xf = xe - 1;
                        }
                        int iy = (int)Math.Round(y);
                        while (xs <= xf)
                        {
                            CPixel px = region[xs + x0, y0 - iy];
                            if (px == null || px.V[2] < zb)
                            {
                                if (px == null)
                                    region[xs + x0, y0 - iy] = px = new CPixel();
                                px.color = t.surface.color;
                                px.V[0] = xsd;
                                px.V[1] = y;
                                px.V[2] = zb;
                                px.brightness = brightnessS.Clone() as double[];
                            }
                            brightnessS[0] += grad[0];
                            brightnessS[1] += grad[1];
                            zb += gradZ;
                            xs++;
                            xsd += 1;
                        }
                    }

                    double dy3 = position[iP[1]][1] - position[iP[2]][1];
                    double k3 = dy3 < 1 ? 0 : (position[iP[1]][0] - position[iP[2]][0]) / dy3;
                    dy2 = position[iP[0]][1] - position[iP[2]][1];
                    k2 = dy2 < 1 ? 0 : (position[iP[0]][0] - position[iP[2]][0]) / dy2;
                    xa = position[iP[2]][0];
                    yb = position[iP[1]][1];
                    yk = position[iP[2]][1];
                    if (yb < -y0 + 1) //Ограничение по верхней границе области
                        yb = -y0 + 1;
                    if (yb >= ye) //Ограничение по нижней границе
                        yb = ye - 1;
                    if (yk > ye - 1) //Ограничение по нижней границе
                        yk = ye - 1;
                    if (yk < -y0 + 1) //Ограничение по верхней границе области
                        yk = -y0 + 1;
                    for (double y = yb; y >= yk; y -= 1)
                    {
                        double[] brightnessS = new double[2]; //Яркости начальной точки линии
                        for (int i = 0; i < 2; i++)
                            brightnessS[i] = dy3 < 1 ? t.surface.tops[iY[0]].brightness[i] //Когда вся линия расположена по горизонтали
                                : t.surface.tops[iY[2]].brightness[i] + (t.surface.tops[iY[1]].brightness[i] - t.surface.tops[iY[2]].brightness[i]) / dy3 * (y - position[iP[2]][1]);
                        double[] brightnessF = new double[2]; //Яркости конечной точки линии
                        for (int i = 0; i < 2; i++)
                            brightnessF[i] = dy2 < 1 ? t.surface.tops[iY[2]].brightness[i] //Когда вся линия расположена по горизонтали
                                : t.surface.tops[iY[2]].brightness[i] + (t.surface.tops[iY[0]].brightness[i] - t.surface.tops[iY[2]].brightness[i]) / dy2 * (y - position[iP[2]][1]);
                        double zb = dy3 < 1 ? position[iP[0]][2] //Когда вся линия расположена по горизонтали
                            : position[iP[2]][2] + (position[iP[1]][2] - position[iP[2]][2]) / dy3 * (y - position[iP[2]][1]);
                        double ze = dy2 < 1 ? position[iP[2]][2] //Когда вся линия расположена по горизонтали
                            : position[iP[2]][2] + (position[iP[0]][2] - position[iP[2]][2]) / dy2 * (y - position[iP[2]][1]);
                        double xsd = xa + k3 * (y - position[iP[2]][1]);
                        double xfd = xa + k2 * (y - position[iP[2]][1]);
                        if (xsd > xfd)
                        {//Поменять местами, чтобы xs была всегда меньше xf
                            double xm = xsd;
                            xsd = xfd;
                            xfd = xm;
                            for (int i = 0; i < 2; i++)
                            {
                                double b = brightnessS[i];
                                brightnessS[i] = brightnessF[i];
                                brightnessF[i] = b;
                            }
                            double d = zb;
                            zb = ze;
                            ze = d;
                        }
                        double dx = xfd - xsd;
                        if (dx < 1)
                            dx = 1;
                        double[] grad = { (brightnessF[0] - brightnessS[0]) / dx, (brightnessF[1] - brightnessS[1]) / dx }; //Градиент яркости по горизонтали
                        double gradZ = (ze - zb) / dx;
                        xfd += 0.5;
                        int xs = (int)xsd;
                        int xf = (int)Math.Round(xfd);
                        if (xs < -x0) //Ограничение по левой границе
                        {
                            brightnessS[0] += (-x0 - xs) * grad[0];
                            brightnessS[1] += (-x0 - xs) * grad[1];
                            zb += (-x0 - xs) * gradZ;
                            xs = -x0;
                        }
                        if (xf >= xe) //Ограничение по правой границе
                        {
                            brightnessF[0] -= (xf - xe) * grad[0];
                            brightnessF[1] -= (xf - xe) * grad[1];
                            ze -= (xf - xe) * gradZ;
                            xf = xe - 1;
                        }
                        int iy = (int)Math.Round(y);
                        while (xs <= xf)
                        {
                            CPixel px = region[xs + x0, y0 - iy];
                            if (px == null || px.V[2] < zb)
                            {
                                if (px == null)
                                    region[xs + x0, y0 - iy] = px = new CPixel();
                                px.V[0] = xsd;
                                px.V[1] = y;
                                px.V[2] = zb;
                                px.color = t.surface.color;
                                px.brightness = brightnessS.Clone() as double[];
                            }
                            brightnessS[0] += grad[0];
                            brightnessS[1] += grad[1];
                            zb += gradZ;
                            xs++;
                            xsd += 1;
                        }
                    }
                }

            //Определить затенённость пикселей
            for (int iS = 0; iS < 2; iS++) //По источникам
                if (sources[iS] != null)
                    for (int x = 0; x < region.GetLength(0); x++)
                        for (int y = 0; y < region.GetLength(1); y++)
                            if (region[x, y] != null)
                                DetermShading(region[x, y], iS, A);

            //Нормализовать яркости
            const double MinBodyBrightness = 64; //Минимальная яркость
            double MaxBrightness = 0;
            for (int x = 0; x < region.GetLength(0); x++)
                for (int y = 0; y < region.GetLength(1); y++)
                    if (region[x, y] != null)
                    {
                        double br = region[x, y].brightness[0] + region[x, y].brightness[1];
                        if (br > MaxBrightness)
                            MaxBrightness = br;
                    }
            double kb = MaxBrightness == 0 ? 0 : (255 - MinBodyBrightness) / MaxBrightness;
            for (int x = 0; x < region.GetLength(0); x++)
                for (int y = 0; y < region.GetLength(1); y++)
                    if (region[x, y] != null)
                        for (int iS = 0; iS < 2; iS++)
                            region[x, y].brightness[iS] = MinBodyBrightness + kb * region[x, y].brightness[iS];
        }
    }
}
