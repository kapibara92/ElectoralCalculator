using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace test
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("disallowed")]
    public class Persons
    {
        [XmlElement("person")]
        public PersonXML[] PersonsData { get; set; }
    }
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("candidates")]
    public class Candidates
    {
        [XmlElement("candidate")]
        public CandidateXML[] CandidatesData { get; set;  }
    }
    public class ConnectSerwer
    {
        public  void GetPersonUnAuthorizedData( Action<Persons> successAction, Action<Exception> errorAction)
        {
            HttpWebRequest request=connectUrl("http://webtask.future-processing.com:8069/blocked");
            try
            {
                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Persons));
                        Persons persons = (Persons)serializer.Deserialize(reader);
                        reader.Close();
                        successAction(persons);
                    }
                }

            }
            catch (HttpListenerException ex)
            {
                errorAction(ex);
            }
        }
        public void GetCandidatesData(Action<Candidates> successAction, Action<Exception> errorAction)
        {
            HttpWebRequest request = connectUrl("http://webtask.future-processing.com:8069/candidates");
            try
            {
                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Candidates));
                        Candidates candidates = (Candidates)serializer.Deserialize(reader);
                        reader.Close();
                        successAction(candidates);
                    }
                }
            }
            catch (HttpListenerException ex)
            {
                errorAction(ex);
            }
        }
        private HttpWebRequest connectUrl(string uri)
        {
            StringBuilder url = new StringBuilder();
            url.Append(uri);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url.ToString());
            request.Timeout = 30000;
            request.KeepAlive = false;
            request.Accept = "application/xml";
            return request;
        }
    }
}
