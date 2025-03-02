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
            private string[] Answers
            {
                get
                {
                    return new string[] {_animal, _charactertrait, _concept};
                }
            }
            public Response(string animal, string charactertrait, string concept)
            {
                _animal = animal;
                _charactertrait = charactertrait;
                _concept = concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                int count = 0;
                int ind = questionNumber - 1;
                foreach (var x in responses)
                {
                    if (x.Answers[ind] != "") count++;
                }
                return count;
            }
            public void Print()
            {
            }
        }
        public struct Research
        {
            private string _name;
            private Response[] _responses;
            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    if (_responses == null) { return null; }
                    var responses = new Response[_responses.Length];
                    Array.Copy(_responses, responses, _responses.Length);
                    return responses;
                }
            }
            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }
            public void Add(string[] answers)
            {
                if(_responses == null || answers == null) return;
                var result = new Response[_responses.Length + 1];
                Array.Copy(_responses, result, result.Length-1);
                string[] ans = new string[] {null, null, null};
                for (int i = 0; i < Math.Min(3, answers.Length); i++)
                {
                    ans[i] = answers[i];
                }
                Response R = new Response(ans[0], ans[1], ans[2]);
                result[result.Length-1] = R;
                _responses = result;
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses == null || question < 1 || question > 3) { return null; }
                if (question == 1)
                {
                    return _responses.GroupBy(x => x.Animal).Where(x => x.Key != null && x.Key.Length != null).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else if (question == 2)
                {
                    return _responses.GroupBy(x => x.CharacterTrait).Where(x => x.Key != null && x.Key.Length != null).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else if (question == 3)
                {
                    return _responses.GroupBy(x => x.Concept).Where(x => x.Key != null && x.Key.Length != null).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
                }
                else
                {
                    return null;
                }
            }
            public void Print()
            {
            }
        }
    }
}
