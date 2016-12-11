using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Assertions;

namespace XMLData
{
    [XmlRoot("QuizCollection")]
    public class QuizDataContainer
    {
        [XmlArray("Quizzes"), XmlArrayItem("QuizData")]
        public List<QuizData> quizzes = new List<QuizData>();

        public static QuizDataContainer Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuizDataContainer));
            Assert.IsNotNull(serializer, "Serializer is null");
            FileStream stream = new FileStream(path, FileMode.Open);
            Assert.IsNotNull(stream, "Stream is null");
            QuizDataContainer dataContainer = serializer.Deserialize(stream) as QuizDataContainer;
            stream.Close();
            return dataContainer;
        }

        /// <summary>
        /// Load the XML data stored as a text file, which can be then refered to as a TextAsset
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static QuizDataContainer LoadTxt(string path)
        {
            TextAsset asset = Resources.Load<TextAsset>(path);
            Assert.IsNotNull(asset, "asset is null");
            Stream s = new MemoryStream(asset.bytes);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(QuizDataContainer));
            Assert.IsNotNull(xmlSerializer, "Serializer is null");
            StreamReader sr = new StreamReader(s);
            Assert.IsNotNull(sr, "Stream is null");
            QuizDataContainer dataContainer = xmlSerializer.Deserialize(sr) as QuizDataContainer;
            Assert.IsNotNull(dataContainer, "DataContainer is null");
            s.Close();
            sr.Close();
            return dataContainer;
        }
    }
}

