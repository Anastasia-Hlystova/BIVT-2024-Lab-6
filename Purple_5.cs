using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _charactertrait;
            private string _concept;
            public string Animal => _animal;
            public string CharacterTrait => _charactertrait;
            public string Concept => _concept;

            public Response(string animal, string charactertrait, string concept)
            {
                _animal = animal;
                _charactertrait = charactertrait;
                _concept = concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || responses.Length == 0 || questionNumber < 1 || questionNumber > 3) return 0;
                int count = 0;
                if (questionNumber == 1)
                {
                    var current = this.Animal;
                    if (current != null)
                    {
                        foreach (var x in responses)
                        {
                            if (x.Animal == current)
                            {
                                count++;
                            }
                        }
                    }
                    
                }
                else if (questionNumber == 2)
                {
                    var current = this.CharacterTrait;
                    if (current != null)
                    {
                        foreach (var x in responses)
                        {
                            if (x.CharacterTrait == current)
                            {
                                count++;
                            }
                        }
                    }
                }
                else if (questionNumber == 3)
                {
                    var current = this.Concept;
                    if (current != null)
                    {
                        foreach (var x in responses)
                        {
                            if (x.Concept == current)
                            {
                                count++;
                            }
                        }
                    }
                }
                return count;
            }
            public void Print()
            {
                Console.WriteLine(_animal + " " + _charactertrait + " " + _concept);
            }
        }
        public struct Research
        {
            private string _name;
            private Response[] _responses;
            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }
            public void Add(string[] answers)
            {
                if(_responses == null || answers == null) return;
                
                string[] ans = new string[] {null, null, null};
                for (int i = 0; i < Math.Min(3, answers.Length); i++)
                {
                    ans[i] = answers[i];
                }
                var result = new Response[_responses.Length + 1];
                Array.Copy(_responses, result, result.Length-1);
                Response R = new Response(ans[0], ans[1], ans[2]);
                result[result.Length-1] = R;
                _responses = result;
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses == null || question < 1 || question > 3) { return null; }
                if (question == 1)
                {
                    return _responses.GroupBy(x => x.Animal).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else if (question == 2)
                {
                    return _responses.GroupBy(x => x.CharacterTrait).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else if (question == 3)
                {
                    return _responses.GroupBy(x => x.Concept).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else
                {
                    return null;
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                foreach (var r in _responses)
                    r.Print();
            }
        }
    }
}
