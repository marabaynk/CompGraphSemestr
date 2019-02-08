//Реализует класс источника
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shadows
{

    /// <summary>
    /// Источник света
    /// </summary>
    internal enum eSource
    {
        /// <summary>
        /// Точечный
        /// </summary>
        eDotted,

        /// <summary>
        /// Неточечный разбиением
        /// </summary>
        eNonDotted,

        /// <summary>
        /// Неточечный ближайший
        /// </summary>
        eNearest

    }

    /// <summary>
    /// Источник света
    /// </summary>
    internal class CSource
    {
        /// <summary>
        /// Тип источника
        /// </summary>
        internal eSource type;

        /// <summary>
        /// Размер источника
        /// </summary>
        internal double size;

        /// <summary>
        /// Положение источника света
        /// </summary>
        internal double[] position;

        /// <summary>
        /// Создаёт источник света
        /// </summary>
        /// <param name="type">Тип источника</param>
        /// <param name="x">x - компонента</param>
        /// <param name="y">y - компонента</param>
        /// <param name="z">z - компонента</param>
        internal CSource(eSource type, double x, double y, double z, double size)
        {
            this.type = type;
            position = new double[3];
            position[0] = x;
            position[1] = y;
            position[2] = z;
            this.size = size;
        }
    }
}
