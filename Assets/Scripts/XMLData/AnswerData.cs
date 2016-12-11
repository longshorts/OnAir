using System.Xml.Serialization;
using System.Collections.Generic;

namespace XMLData
{
    public class AnswerData
    {
        public string AnswerBody;
        public string UseItem;
        public int Score;
        [XmlElement("SubQuizData")]
        public QuizData SubQuizData = new QuizData();

        public AnswerData()
        {
            AnswerBody = "Default AnswerData";
            UseItem = false.ToString();
            Score = 0;
            SubQuizData = null;
        }

        public AnswerData(string answerBody)
        {
            AnswerBody = answerBody;
            UseItem = false.ToString();
            Score = 0;
            SubQuizData = null;
        }

        public AnswerData(string answerBody, bool collectItem, int score)
        {
            AnswerBody = answerBody;
            UseItem = collectItem.ToString();
            Score = score;
            SubQuizData = null;
        }
    }
}

