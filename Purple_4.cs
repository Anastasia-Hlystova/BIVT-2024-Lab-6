using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _flag;
            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
                _flag = false;
            }
            public void Run(double time)
            {
                if (time < 0 || _flag) return;
                _time = time;
                _flag = true;
            }
            public void Print() 
            {
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) { return null; }
                    var sportsmen = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                    return sportsmen;
                }
            }
            public Group (string name)
            {
                 _name = name;
                 _sportsmen = new Sportsman[0];
            }
            public Group(Group n)
            {
                _name = n.Name;
                if (n.Sportsmen != null)
                {
                    _sportsmen = new Sportsman[n.Sportsmen.Length];
                    Array.Copy(n.Sportsmen, _sportsmen, n.Sportsmen.Length);
                }
                else
                {
                    _sportsmen = new Sportsman[0];
                }
            }
            public void Add(Sportsman man)
            {
                if (_sportsmen == null) return;
                var sportsmen = new Sportsman[_sportsmen.Length + 1];
                Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                sportsmen[sportsmen.Length-1] = man;
                _sportsmen = sportsmen;

            }
            public void Add(Sportsman []men)
            {
                if (_sportsmen == null || men == null) return;
                var sportsmen = new Sportsman[_sportsmen.Length + men.Length];
                Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                Array.ConstrainedCopy(men, 0, sportsmen, _sportsmen.Length, men.Length);
                _sportsmen = sportsmen;
            }
            public void Add(Group m)
            {
                if(_sportsmen == null || m.Sportsmen == null) return;
                Add(m.Sportsmen);
            }
            public void Sort()
            {
                if (_sportsmen == null) return;
                //_sportsmen = _sportsmen.OrderBy(p => p.Time).ToArray();
                Array.Sort(_sportsmen, (x, y) =>
                {
                    if (x.Time < y.Time) return -1;
                    else if (x.Time > y.Time) return 1;
                    else return 0;
                });
            }
            public static Group Merge( Group group1, Group group2)
            {
                var merged = new Group("Финалисты");
                var g1 = group1._sportsmen;
                var g2 = group2._sportsmen;
                if (g1 == null) g1 = new Sportsman[0];
                if (g2 == null) g2 = new Sportsman[0];
                merged._sportsmen = new Sportsman[g1.Length + g2.Length];
                int i = 0, j = 0, ind = 0;
                while (i < g1.Length && j < g2.Length)
                {
                    if (g1[i].Time <= g2[j].Time)
                    {
                        merged._sportsmen[ind++] = g1[i++];
                    }
                    else
                    {
                        merged._sportsmen[ind++] = g2[j++];
                    }
                }
                while(i < g1.Length)
                {
                    merged._sportsmen[ind++] = g1[i++];
                }
                while (j < g2.Length)
                {
                    merged._sportsmen[ind++] = g2[j++];
                }
                return merged;
            }
            public void Print()
            {
            }
        }
    }
}
