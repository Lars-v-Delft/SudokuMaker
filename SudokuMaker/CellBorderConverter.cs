using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SudokuMaker
{
    public class CellBorderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int y = (int)values[0];
            int x = (int)values[1];

            double thick = 1;
            double thin = .4;

            Thickness thickness = new Thickness(thin, thin, thin, thin);

            if (y == 0)
                thickness.Top = thick * 2;
            else if (y % 3 == 0)
                thickness.Top = thick;

            if (y == 8)
                thickness.Bottom = thick * 2;
            else if (y % 3 == 2)
                thickness.Bottom = thick;

            if (x == 0)
                thickness.Left = thick * 2;
            else if (x % 3 == 0)
                thickness.Left = thick;

            if (x == 8)
                thickness.Right = thick * 2;
            else if (x % 3 == 2)
                thickness.Right = thick;

            return thickness;

            //if (y % 3 == 0 && x % 3 == 0) // topleft
            //    return new Thickness(thick, thick, thin, thin);
            //if (y % 3 == 0 && x % 3 == 1) // topmiddle
            //    return new Thickness(thin, thick, thin, thin);
            //if (y % 3 == 0 && x % 3 == 2) // toprigth
            //    return new Thickness(thin, thick, thick, thin);

            //if (y % 3 == 1 && x % 3 == 0) // middleleft
            //    return new Thickness(thick, thin, thin, thin);
            //if (y % 3 == 1 && x % 3 == 1) // middlemiddle
            //    return new Thickness(thin, thin, thin, thin);
            //if (y % 3 == 1 && x % 3 == 2) // middlerigth
            //    return new Thickness(thin, thin, thick, thin);

            //if (y % 3 == 2 && x % 3 == 0) // bottomleft
            //    return new Thickness(thick, thin, thin, thick);
            //if (y % 3 == 2 && x % 3 == 1) // bottommiddle
            //    return new Thickness(thin, thin, thin, thick);
            //if (y % 3 == 2 && x % 3 == 2) // bottomrigth
            //    return new Thickness(thin, thin, thick, thick);

            //int index = (int)values;

            //if (index % 3 == 0) // left
            //return new Thickness(2, 0, 0, 0);
            //if (index % 3 == 1) // center
            //    return new Thickness(1, 0, 1, 0);
            //if (index % 3 == 2) // rigth
            //    return new Thickness(0, 0, 2, 0);

            //throw new Exception("This should be impossible");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
