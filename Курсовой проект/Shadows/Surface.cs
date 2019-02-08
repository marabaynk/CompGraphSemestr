//Реализует классы CTop, CTriangle, CSurface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shadows
{

    /// <summary>
    /// Класс представления пикселя на экране
    /// </summary>
    class CPixel
    {
        /// <summary>
        /// <summary>
        /// Индекс цвета. -1 - фон
        /// </summary>
        internal int color;

        /// <summary>
        /// Яркости пикселя от каждого источника
        /// </summary>
        internal double[] brightness;

        /// <summary>
        /// Координаты пикселя
        /// </summary>
        internal double[] V;

        /// <summary>
        /// Создаёт пиксель с нулевыми полями
        /// </summary> и цветом фона
        internal CPixel()
        {
            color = -1;
            V = new double[3];
            brightness = new double[2];
        }

        /// <summary>
        /// Цвет и яркость пикселя поверхности
        /// </summary>
        internal Color Brightness
        {
            get
            {
                byte[] c = { 0, 0, 0 };
                int b = (int)(brightness[0] + brightness[1]);
                if (b > 255)
                    b = 255;
                c[color] = (byte)b;
                return Color.FromArgb(c[0], c[1], c[2]);
            }
        }
    }

    /// <summary>
    /// Описание вершины
    /// </summary>
    internal class CTop
    {
        /// <summary>
        /// Положение вершины в связанной с телом системе координат
        /// </summary>
        internal double[] position;

        /// <summary>
        /// Положение вершины после переноса и в дальнейшем перепроектирования
        /// </summary>
        internal double[] pos;

        /// <summary>
        /// Индекс цвета
        /// </summary>
        internal int color;

        /// <summary>
        /// Нормаль к поверхности вершины в связанной с телом системе координат
        /// </summary>
        internal double[] N;

        /// <summary>
        /// Яркости вершины от каждого источника
        /// </summary>
        internal double[] brightness;

        /// <summary>
        /// Направления на источники в системе координат сцены. Индекс 0 - индексы источников
        /// </summary>
        internal double[][] sources;

        /// <summary>
        /// Массив индексов источников, освещающих вершину
        /// </summary>
        internal CSource[] src = new CSource[2];

        /// <summary>
        /// Квадрат расстояния до источников
        /// </summary>
        internal double[] distance2;

        /// <summary>
        /// Очистить массив источников и яркости
        /// </summary>
        internal void Clear()
        {
            src[0] = src[1] = null;
            brightness[0] = brightness[1] = 0;
        }

        /// <summary>
        /// Создаёт вершина по его компонентам
        /// </summary>
        /// <param name="pX">X положения вершины в связанной системе координат</param>
        /// <param name="pY">Y положения вершины в связанной системе координат</param>
        /// <param name="pZ">Z положения вершины в связанной системе координат</param>
        /// <param name="nX">X нормали вершины в связанной системе координат</param>
        /// <param name="nY">Y нормали вершины в связанной системе координат</param>
        /// <param name="nZ">Z нормали вершины в связанной системе координат</param>
        /// <param name="color">Индекс цвета вершины</param>
        internal CTop(double pX, double pY, double pZ, double nX, double nY, double nZ, int color)
        {
            this.color = color;
            position = new double[3];
            position[0] = pX;
            position[1] = pY;
            position[2] = pZ;
            pos = new double[3];
            N = new double[3];
            N[0] = nX;
            N[1] = nY;
            N[2] = nZ;
            sources = new double[2][];
            brightness = new double[2];
            distance2 = new double[2];
        }

        /// <summary>
        /// Создаёт копию вершины
        /// </summary>
        /// <param name="src">Копируемая вершина</param>
        internal CTop(CTop src)
        {
            position = src.position.Clone() as double[];
            N = src.N.Clone() as double[];
            pos = src.pos.Clone() as double[];
            sources = new double[2][];
            brightness = src.brightness.Clone() as double[];
            distance2 = src.distance2.Clone() as double[];
        }

        /// <summary>
        /// Создаёт вершину с нулевыми компонентами для положения и нормы
        /// </summary>
        internal CTop()
        {
            position = new double[3];
            N = new double[3];
            pos = new double[3];
            sources = new double[2][];
            brightness = new double[2];
            distance2 = new double[2];
        }
    }

    /// <summary>
    /// Треугольник для отображения. Представлен 3 вершинами.
    /// </summary>
    internal class CTriangle
    {
        /// <summary>
        /// Индексы вершин треугольника в списке вершин поверхности
        /// </summary>
        internal int[] iTops;

        /// <summary>
        /// Квадрат до источников ближайшей к ним вершины
        /// </summary>
        internal double[] distance2;

        /// <summary>
        /// Поверхность, к которой относится треугольник
        /// </summary>
        internal CSurface surface;

        /// <summary>
        /// Создаёт треугольник с заданными вершинами
        /// </summary>
        /// <param name="top1">Вершина 1</param>
        /// <param name="top2">Вершина 2</param>
        /// <param name="top3">Вершина 3</param>
        /// <param name="surface">Поверхность, к которой относится треугольник</param>
        internal CTriangle(int top1, int top2, int top3, CSurface surface)
        {
            this.surface = surface;
            iTops = new int[3];
            iTops[0] = top1;
            iTops[1] = top2;
            iTops[2] = top3;
            distance2 = new double[2];
        }
    }

    /// <summary>
    /// Класс для представления поверхности
    /// </summary>
    internal class CSurface
    {
        /// <summary>
        /// Индекс цвета
        /// </summary>
        internal int color;

        /// <summary>
        /// Положение центра тела
        /// </summary>
        internal double[] position;

        /// <summary>
        /// Вершины треугольников, определяющие поверхность
        /// </summary>
        internal List<CTop> tops;

        /// <summary>
        /// Треугольники апроксимирующие поверхность
        /// </summary>
        internal List<CTriangle> triangles;

        /// <summary>
        /// Создаёт описание поверхности
        /// </summary>
        /// <param name="position">Положение центра</param>
        /// <param name="color">Индекс цвета</param>
        internal CSurface(double[] position, int color)
        {
            this.position = position;
            this.color = color;
            tops = new List<CTop>();
            triangles = new List<CTriangle>();
        }

        /// <summary>
        /// Добавляется треугольник с указанными существующими вершинами
        /// </summary>
        /// <param name="top1">Существующая вершина 1</param>
        /// <param name="top2">Существующая вершина 2</param>
        /// <param name="top3">Существующая вершина 3</param>
        internal void Add(int top1, int top2, int top3)
        {
            triangles.Add(new CTriangle(top1, top2, top3, this));
        }

        /// <summary>
        /// Создаёт поверхность тела, формирует основание цилиндра или конуса и записывает его в описание поверхности тела
        /// </summary>
        /// <param name="yBase">Координата y основания</param>
        /// <param name="step">Шаг</param>
        /// <param name="d">Диаметр круга</param>
        /// <param name="ny">Проекция нормали на ось Y</param>
        /// <returns>Возвращает индекс начала внешних треугольников последнего слоя</returns>
        protected List<int> CreateBaseRound(double yBase, double step, double d, double ny)
        {
            List<int> ret = new List<int>();
            CTop top = null;
            int nLayers = 2 * (int)(d / 2 / step);
            step = d / nLayers;
            double x = -d / 2;
            double r2 = (d + step) * (d + step) / 4;
            int iStart = this.tops.Count; //Количество вершин, уже находящихся на поверхности
            List<int> diameter = new List<int>(); //Индексы вершин по горизонтальному диаметру

            //Верхний полукруг
            int iL = iStart; //Начало предыдущегго слоя. В данном случае начало вершин
            x = -d / 2;
            diameter.Add(iStart);
            for (double z = 0; x * x + z * z < r2; z += step)
            {//Начальный слой
                top = new CTop(x, yBase, z, 0, ny, 0, color);
                ret.Add(this.tops.Count);
                this.tops.Add(top);
            }
            for (int nX = 0; nX < nLayers; nX++)
            {
                x += step;
                int iB = this.tops.Count; //Начало нового слоя
                diameter.Add(iB);
                top = new CTop(x, yBase, 0, 0, ny, 0, color); //Начальная вершина слоя
                this.tops.Add(top);
                bool b = true;
                for (double z = step; x * x + z * z < r2; z += step, iL++)
                {
                    if (x <= 0)
                    {
                        if (b)
                            this.Add(iL, this.tops.Count - 1, this.tops.Count);
                        else
                            ret.Add(this.tops.Count - 1);
                        b = iL < iB - 1;
                        if (b)
                            this.Add(iL, iL + 1, this.tops.Count);
                    }
                    else
                    {
                        this.Add(iL, iL + 1, this.tops.Count - 1);
                        this.Add(iL + 1, this.tops.Count - 1, this.tops.Count);
                    }
                    top = new CTop(x, yBase, z, 0, ny, 0, color);
                    this.tops.Add(top);
                }
                if (x > 0 && top.position[2] < this.tops[iB - 1].position[2])
                {
                    int iM;
                    for (iM = iB - 2; top.position[2] < this.tops[iM].position[2]; iM--)
                        ret.Add(iM);
                    this.Add(iM, iM + 1, this.tops.Count - 1);
                }
                ret.Add(this.tops.Count - 1);
                iL = iB;
            }

            //Нижний полукруг
            iL = this.tops.Count;
            int iD = diameter.Count - 1;
            x = d / 2;
            for (double z = -step; x * x + z * z < r2; z -= step)
            {//Начальный слой
                top = new CTop(x, yBase, z, 0, ny, 0, color);
                ret.Add(this.tops.Count);
                this.tops.Add(top);
            }
            for (int nX = 0; nX < nLayers; nX++)
            {
                int iP1 = diameter[iD];
                int iP = diameter[--iD];
                x -= step;
                int iB = this.tops.Count; //Начало нового слоя
                bool b = true;
                for (double z = -step; x * x + z * z < r2; z -= step, iL++)
                {
                    if (x >= 0)
                    {
                        if (b)
                            this.Add(iP, iP1, this.tops.Count);
                        else
                            ret.Add(this.tops.Count - 1);
                        b = iL < iB;
                        if (b)
                            this.Add(iP1, iL, this.tops.Count);
                    }
                    else
                    {
                        this.Add(iP, iL, iP1);
                        this.Add(iL, iP, this.tops.Count);
                    }
                    iP = this.tops.Count;
                    iP1 = iL;
                    top = new CTop(x, yBase, z, 0, ny, 0, color);
                    this.tops.Add(top);
                }
                if (x < 0 && top.position[2] > this.tops[iB - 1].position[2])
                {//Соединяем вершины для получения внешнего треугольника, если они не соединены
                    int iM;
                    for (iM = iB - 2; top.position[2] > this.tops[iM].position[2]; iM--)
                        ret.Add(iM);
                    this.Add(iM, iM + 1, this.tops.Count - 1);
                }
                ret.Add(this.tops.Count - 1);
                iL = iB;
            }

            return ret;
        }
    }

    /// <summary>
    /// Поверхность куба
    /// </summary>
    internal class CCube : CSurface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">Положение центра</param>
        /// <param name="color">Индекс цвета</param>
        /// <param name="d">Длина стороны</param>
        /// <param name="Nc">Количество разбиений ребра на части для получения треугольников</param>
        internal CCube(double[] position, int color, double d, int Nc): base(position, color)
        {
            CTop top;
            double h2s = - d / 2;
            double h2e = d / 2;
            double step = d / Nc; //Шаг
            for (int g = 0; g < 6; g++) //Цикл по граням
            {
                int k = g / 2; //Координата, в которой лежит плоскость
                int k1 = (k + 1) % 3; //2 другие координаты
                int k2 = (k1 + 1) % 3;

                //Начальный слой вершин
                int iLow = this.tops.Count; //Индекс 1-й образующей треугольник вершины нижнего слоя
                top = new CTop(); //Начальная вершина
                top.position[k] = (g & 1) == 0 ? h2e : h2s;
                top.position[k1] = h2s;
                top.position[k2] = h2s;
                top.N[k] = (g & 1) == 0 ? 1 : -1;
                this.tops.Add(top);
                for (int l = 0; l < Nc; l++)
                {
                    top = new CTop(top);
                    top.position[k2] += step;
                    this.tops.Add(top);
                }

                double b = h2s + step;
                for (int lb = 0; lb < Nc; lb++, b += step, iLow++)
                {
                    top = new CTop(); //Начальная вершина слоя
                    top.position[k] = (g & 1) == 0 ? h2e : h2s;
                    top.position[k1] = b;
                    top.position[k2] = h2s;
                    top.N[k] = (g & 1) == 0 ? 1 : -1;
                    this.tops.Add(top);
                    for (int lc = 0; lc < Nc; lc++, iLow++)
                    {
                        this.Add(iLow, iLow + 1, this.tops.Count - 1);
                        this.Add(iLow + 1, this.tops.Count - 1, this.tops.Count);
                        top = new CTop(top); //Очередная вершина слоя
                        top.position[k2] += step;
                        this.tops.Add(top);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Поверхность цилиндра
    /// </summary>
    internal class CCylinder : CSurface
    {
        /// <summary>
        /// Создаёт цилиндр с заданными параметрами
        /// </summary>
        /// <param name="position">Положение центра</param>
        /// <param name="color">Индекс цвета</param>
        /// <param name="d">Диаметр цилиндра</param>
        /// <param name="h">Высота цилиндра</param>
        /// <param name="step">Шаг разбиения на треугольники</param>
        internal CCylinder(double[] position, int color, double d, double h, double step): base(position, color)
        {
            CTop top, top1;
            double h2s = -h / 2; //Z-компонента нижнего основания
            int NLR = (int)(d / step); //Количество слоёв в круге
            double stepR = d / NLR; //Размер слоя в круге
            int NLY = (int)(h / step); //Количество слоёв в боковой поверхности
            double stepY = h / NLY; //Размер слоя в боковой поверхности

            List<int> BaseTops = CreateBaseRound(h2s, stepR, d, -1); //Создаёт нижнее основание цилиндра. Возвращает список индексов вершин внешнего контура основании цилиндра
            int nBase = this.triangles.Count; //Количество треугольников в основании цилиндра.

            //--------------Боковая поверхность цилиндра--------
            //Создадим нижний слой точек
            int iLow = this.tops.Count; //Начало вершин боковой части цилиндра
            foreach (int i in BaseTops)
            {
                top = this.tops[i]; //Текущая вершина внешней окружности основания
                double l = Math.Sqrt(top.position[0] * top.position[0] + top.position[2] * top.position[2]); //Проекция вектора из начала координат к вершине на плоскость xy
                top = new CTop(top); //Те же координаты, что и основания, но нормаль другая
                top.N[0] = top.position[0] / l;
                top.N[1] = 0;
                top.N[2] = top.position[2] / l;
                this.tops.Add(top);
            }
            int nHigh = this.tops.Count; //Конец вершин предыдущего уровня
            double y = h2s + stepY; //y - координата создаваемого слоя вершин
            for (int l = 0; l < NLY; l++, y += stepY)
            {//Цикл по всем слоям цилиндра
                top = new CTop(this.tops[iLow]); //Начальная точка вставляется в список, чтобы обеспечить корректность алгоритма
                top.position[1] = y;
                this.tops.Add(top);
                for (int i = iLow; i < nHigh - 1; i++)
                {//Создаём пары треугольников, образующих квадрат
                    this.Add(i, i + 1, this.tops.Count - 1);
                    top1 = new CTop(this.tops[i + 1]);
                    top1.position[1] = y;
                    this.Add(i + 1, this.tops.Count - 1, this.tops.Count);
                    this.tops.Add(top1);
                    top = top1;
                }
                this.Add(nHigh - 1, iLow, this.tops.Count - 1); //Последняя пара, замыкающая круг
                this.Add(iLow, this.tops.Count - 1, nHigh);
                iLow = nHigh; //Настройка нового цикла
                nHigh = this.tops.Count;
            }

            CreateBaseRound(h / 2, stepR, d, 1); //Верхний круг цилиндра
        }
    }

    /// <summary>
    /// Поверхность конуса
    /// </summary>
    internal class CConus : CSurface
    {
        /// <summary>
        /// Создаёт конус с заданными параметрами
        /// </summary>
        /// <param name="position">Положение центра</param>
        /// <param name="color">Индекс цвета</param>
        /// <param name="d">Диаметр основания конуса</param>
        /// <param name="h">Высота конуса</param>
        /// <param name="step">Шаг разбиения на треугольники</param>
        internal CConus(double[] position, int color, double d, double h, double step)
            : base(position, color)
        {
            CTop top;
            double h2s = -h / 2; //Y-компонента основания
            double h2e = -h2s; //Y-компонента вершины конуса
            int NL = (int)(d / step); //Количество слоёв круга
            double stepR = (d / NL); //Размер слоя круга
            List<int> ext = CreateBaseRound(h2s, stepR, d, -1); //Создать основание конуса. Определяем список вершин внешнего контура основания
            int nBaseTriangles = this.triangles.Count; //Количество треугольников в основании конуса
            int nBaseTops = this.tops.Count; //Количество вершин в основании конуса

            /* Принимаем, проекции треугольников, апроксимирующих боковую поверхность конуса, совпадают с треугольниками основания.
             * Если высота конуса превышает диаметр основания настолько, что боковые стороны треугольника можно разбить на несколько
             * размером не менее step, то треугольники разбиваются на несколько меньших */
            double L = Math.Sqrt(d * d / 4 + h * h); //Длина боковой стороны конуса
            double K = L / d * 2; //Коэффициент увеличения длины боковых сторон треугольника
            int nD = (int)K; //Количество разбиений боковых сторон
            double Dn = 1.0 / nD; //Обратная величина разбиения боковой стороны
            double Y = 1 / K; //Y - компонента нормали
            double nXZ = h / L; //Проекция нормали боковых вершин на плоскость XZ
            double stepY = h / NL; //Шаг разбиения боковой стороны по оси Y
            double y = h2s - stepY; //Текущее значение z для верхней вершины треугольников, начиная со второго уровня
            double C = h / d * 2; //Коэффициент соответствия z - координаты расстоянию от центра до проекции точки на основание

            //Проецируем вершины основания на боковую поверхность
            for (int i = 0; i < nBaseTops; i++)
            {
                top = new CTop(this.tops[i]);
                double l = Math.Sqrt(top.position[0] * top.position[0] + top.position[2] * top.position[2]); //Проекция вершины на основание
                top.position[1] = h2e - l * C;
                if (l > 0)
                { //Нормаль
                    top.N[0] = nXZ * top.position[0] / l;
                    top.N[1] = Y;
                    top.N[2] = nXZ * top.position[2] / l;
                }
                else
                    top.N[2] = 1; //Вершина в центре
                this.tops.Add(top);
            }

            //Дублируем треугольники, заменяя вершины основания на вершины боковой поверхности
            for (int i = 0; i < nBaseTriangles; i++)
            {
                CTriangle t = this.triangles[i];
                this.Add(t.iTops[0] + nBaseTops, t.iTops[1] + nBaseTops, t.iTops[2] + nBaseTops);
            }

            //Приводим нижний контур боковой стороны конуса к нижнему основанию
            for (int i = 0; i < ext.Count; i++)
                this.tops[ext[i] + nBaseTops].position[1] = h2s;

            //Убираем "сопли", свешивающиеся с основания
            for (int i = nBaseTops; i < this.tops.Count; i++)
                if (this.tops[i].position[1] < h2s)
                    this.tops[i].position[1] = h2s;
        }
    }

    /// <summary>
    /// Поверхность призмы
    /// </summary>
    internal class CPrizma : CSurface
    {
        /// <summary>
        /// Создаёт призму с заданными параметрами
        /// </summary>
        /// <param name="position">Положение центра</param>
        /// <param name="color">Индекс цвета</param>
        /// <param name="d">Длина ребра основания призмы</param>
        /// <param name="h">Высота призмы</param>
        /// <param name="NG">Количество граней призмы</param>
        internal CPrizma(double[] position, int color, double d, double h, int NG, double step)
            : base(position, color)
        {
            double h2s = -h / 2; //Y-компонента нижнего основания
            double h2e = -h2s; //Y-компонента верхнего
            double dAlpha = 2 * Math.PI / NG; //Угол поворота каждой грани относительно предыдущей
            double ca = Math.Cos(dAlpha);
            double sa = Math.Sin(dAlpha);
            double d2 = d / 2;
            int Nh = (int)(h / step); //Количество разбиений по высоте боковой поверхности
            double stepH = h / Nh; //Шаг по высоте
            int Nd = (int)(d / step); //Количество разбиений по горизонтали боковой поверхности
            double stepD = d / Nh; //Шаг по боаокой стороне

            //Основания
            double y = h2s; //y - компонента основания
            double ny = -1; //y - компонента нормали основания
            for (int bases = 0; bases < 2; bases++, y = h2e, ny = 1) //Цикл по основаниям
            {
                double[] pos1 = { d2, 0};
                int i0 = tops.Count; //Индекс центра основания
                tops.Add(new CTop(0, y, 0, 0, ny, 0, color)); //Центр основания
                int iS = tops.Count; //Индекс начальной вершины
                tops.Add(new CTop(d2, y, 0, 0, ny, 0, color)); //Начальная вершина основания
                for (int i = 0; i < NG - 1; i++)
                {
                    double[] pos2 = { pos1[0] * ca - pos1[1] * sa, pos1[1] * ca + pos1[0] * sa }; //Поворот грани
                    tops.Add(new CTop(pos2[0], y, pos2[1], 0, ny, 0, color));
                    Add(i0, tops.Count - 2, tops.Count - 1);
                    pos1 = pos2;
                }
                Add(i0, tops.Count - 1, iS); //Замыкающий треугольник
            }

            //Боковые поверхности
            double[] pos0 = {d2, 0};
            for (int i = 0; i < NG; i++)
            {
                int iT0 = tops.Count; //Нижний слой
                double[] pos2 = { pos0[0] * ca - pos0[1] * sa, pos0[1] * ca + pos0[0] * sa };
                double[] stepXZ = { (pos2[0] - pos0[0]) / Nd, (pos2[1] - pos0[1]) / Nd };
                double norm = Math.Sqrt(stepXZ[0] * stepXZ[0] + stepXZ[1] * stepXZ[1]);
                double[] n = { stepXZ[1] / norm, -stepXZ[0] / norm }; //Нормаль к поверхности
                double[] posXZ = pos0.Clone() as double[];
                for (int id = 0; id <= Nh; id++) //Нижний слой
                {
                    tops.Add(new CTop(posXZ[0], h2s, posXZ[1], n[0], 0, n[1], color));
                    posXZ[0] += stepXZ[0];
                    posXZ[1] += stepXZ[1];
                }
                double hs = h2s + stepH;
                int iT1 = tops.Count;
                for (int ih = 0; ih < Nh; ih++, hs += stepH)
                {
                    posXZ = pos0.Clone() as double[];
                    tops.Add(new CTop(posXZ[0], hs, posXZ[1], n[0], 0, n[1], color));
                    for (int id = 0; id < Nd; id++)
                    {
                        posXZ[0] += stepXZ[0];
                        posXZ[1] += stepXZ[1];
                        tops.Add(new CTop(posXZ[0], hs, posXZ[1], n[0], 0, n[1], color));
                        Add(iT0 + id, iT0 + id + 1, tops.Count - 2);
                        Add(iT0 + id + 1, tops.Count - 2, tops.Count - 1);
                    }
                }
                pos0 = pos2;
                iT0 = iT1;
            }
        }
    }
}
