using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        const int judges = 7;
        public struct Participant
        {
            //polya
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _current;

            //svoystva
            public string Name => _name;
            public string Surname => _surname;

            public double[] Marks
            {
                get
                {
                    if(_marks == null) {return null;}
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double[] Places
            {
                get
                {
                    if (_places == null) { return null; }
                    double[] copy = new double[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }
            public int Score
            {
                get
                {
                    if(_places == null) return 0;
                    int score = 0;
                    foreach (int x in _places)
                    {
                        score += x;
                    }
                    return score;
                }
            }
            private int Top
            {
                get
                {
                    if (_places == null) return 0;
                    int imin = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        if (_places[i] < _places[imin])
                        {
                            imin = i;
                        }
                    }
                    return _places[imin];
                }
            }
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    double s = 0;
                    foreach (double x in _marks)
                    {
                        s += x;
                    }
                    return s;
                }
            }
            //konstructor
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[judges];
                _places = new int[judges];
                _current = 0;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                    _places[i] = 0;
                }
            }
            //metody
            public void Evaluate(double result)
            {
                if (_marks == null || _current >= _marks.Length || result < 0 || result > 6) return;
                _marks[_current] = result;
                _current++;

            }
            public static void SetPlaces(Participant[] participants)
            {
                if(participants == null) return;

                for(int i = 0; i < judges; i++)
                {
                    var sortedparticipants = participants.OrderByDescending(p => p.Marks != null && i < p.Marks.Length ? p.Marks[i] : 0).ToArray();
                    for(int j = 0;  j < sortedparticipants.Length; j++)
                    {
                        sortedparticipants[j].FillArrayPlaces(i, j + 1);
                    }
                }

            }
            private void FillArrayPlaces(int i, int j)
            {
                if(_places == null || _places.Length ==  0 || i < 0 || i > judges || i > _places.Length ) return;
                _places[i] = j;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                Array.Sort(array, (a, b) =>
                {
                    if (a.Score == b.Score)
                    {
                        if (a.Top == b.Top)
                        {
                            double x = a.TotalMark - b.TotalMark;
                            if (x < 0) return 1;
                            else if (x > 0) return -1;
                            else return 0;
                        }
                        return a.Top - b.Top;
                    }
                    return a.Score - b.Score;
                });
            }
            public void Print()
            {
            }
        }
    }
}
