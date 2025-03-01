using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _current;
            //свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] copy1 = new double[_coefs.Length];
                    Array.Copy(_coefs, copy1, _coefs.Length);
                    return copy1;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copy2 = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy2, _marks.Length);
                    return copy2;
                }
            }
            public double TotalScore
            {
                get
                {
                    if(_marks == null || _coefs == null) return 0;
                    double result = 0;
                    for(int i = 0; i < _marks.GetLength(0); i++)
                    {
                        result += OneJumpScore(i);
                    }
                    
                    return result;
                }

            }
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                _marks = new int[4, 7];
                _current = 0;

                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = 2.5;
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }

                }
            }
            //методы
            private double OneJumpScore(int index)
            {
                if(_marks == null || _coefs == null) return 0;
                double score = 0;
                int[] marks = new int[_marks.GetLength(1)];
                for(int i = 0; i < _marks.GetLength(1); i++)
                {
                    marks[i] = _marks[index, i];
                }
                int imax = 0;
                int imin = 0;
                for(int i = 0; i < marks.Length; i++)
                {
                    if(marks[i] > marks[imax])
                    {
                        imax = i;
                    }
                    if(marks[i] < marks[imin])
                    {
                        imin = i;
                    }
                }
                score = (marks.Sum() - marks[imax] - marks[imin]) * _coefs[index];
                return score;
            }
            public void SetCriterias(double[] coefs)
            {
                if(_coefs == null || coefs == null || _coefs.Length != coefs.Length) return;
                for (int i = 0; i < coefs.Length; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            public void Jump(int[] marks)
            {
                if (_marks == null || marks == null || _current >= _marks.GetLength(0) || _marks.GetLength(1) != marks.Length) return;
                for(int j = 0; j < _marks.GetLength(1); j++)
                {
                    _marks[_current, j] = marks[j];
                }
                    _current++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].TotalScore > array[i].TotalScore)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Participant temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }
            public void Print()
            {
            }
        }
    }
}
