using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLData
{
    public class QuizData
    {

        [XmlAttribute("id")]
        public string Id;
        public string Title;
        public string Body;

        [XmlArray("Answers"), XmlArrayItem("AnswerData")]
        public List<AnswerData> Answers = new List<AnswerData>();

        /// <summary>
        /// Works out the max score from this point within the quiz branch
        /// </summary>
        /// <returns>maximum possible score</returns>
        public int MaxScore()
        {
            int max = 0;
            foreach (AnswerData answer in Answers)
            {
                int subQuizScore = 0;
                if (answer.SubQuizData != null)
                {
                    subQuizScore = answer.SubQuizData.MaxScore();
                }
                    
                max = (answer.Score + subQuizScore > max) ? answer.Score + subQuizScore : max;
            }
            return max;
        }

        public bool HasID(string otherID)
        {
            return (Id == otherID);
        }
    }
}

