using System;

namespace GradeCalculator
{
    public class Course
    {
        private double _maths;
        private double _english;
        private double _science;
        private double _biology;
        private double _history;

        public double Maths
        {
            get { return _maths; }
            set
            {
                ValidateMark(value, "Maths");
                _maths = value;
            }
        }

        public double English
        {
            get { return _english; }
            set
            {
                ValidateMark(value, "English");
                _english = value;
            }
        }
        public double Science
        {
            get { return _science; }
            set
            {
                ValidateMark(value, "Science");
                _science = value;
            }
        }
        public double Biology
        {
            get { return _biology; }
            set
            {
                ValidateMark(value, "Biology");
                _biology = value;
            }
        }
        public double History
        {
            get { return _history; }
            set
            {
                ValidateMark(value, "History");
                _history = value;
            }
        }

        public static string Grade(double mark)
        {
            if(mark > 100 || mark < 0)
            {
                return "Invalid Mark";
            }
            else if (mark >= 90)
            {
                return "A";
            }
            else if (mark >= 80)
            {
                return "B";
            }
            else if (mark >= 70)
            {
                return "C";
            }
            else if (mark >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        public double Total()
        {
            double total = this._maths + this._english + this._science + this._biology + this._history;

            return total;
        }
        public double  Average()
        {
            double total = this._maths + this._english + this._science + this._biology + this._history;

            return total / 5;
        }

        // checking the validity of marks (cannot be negative or above 100) 
        private static void ValidateMark(double value, string subject)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(subject, $"{subject} cannot be negative or greater than 100. You entered {value}.");
            }
        }
    }
}