using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportWindow : MonoBehaviour {

    int currentPosition;
    float delay = 0.1f;
    public Text reportText;
    public int storyIndex = -1;
    [TextArea(3,10)]
    public string endOfBroadCastText = "That concludes today's broadcast.";
    string[] additionalLines;
    bool typing = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitNextStory()
    {
        //typing = !typing;

        if (ReportManager.Instance.dayReports.Count <= storyIndex && !typing)
        {
            ReportManager.Instance.EndDay();
            gameObject.SetActive(false);
            return;
        }

        if (typing)
        {
            if (ReportManager.Instance.dayReports.Count > storyIndex)
                reportText.text = ReportManager.Instance.dayReports[storyIndex].storyToReport;
            else
                reportText.text = endOfBroadCastText;
            typing = false;
        }
        else
        {
            typing = true;
            reportText.text = "";
            storyIndex++;
            StartCoroutine(TypeStory());
        }

        
    }

    public IEnumerator TypeStory()
    {
        
        if(ReportManager.Instance.dayReports.Count > storyIndex)
        {
            foreach (char letter in ReportManager.Instance.dayReports[storyIndex].storyToReport.ToCharArray())
            {
                if (!typing)
                {
                    Debug.Log("StopCoroutinedamnit");
                    yield break;
                }
                reportText.text += letter;
                //TODO do sound

                yield return new WaitForSeconds(delay);
            }
        } else
        {
            foreach (char letter in endOfBroadCastText.ToCharArray())
            {
                if (!typing)
                {
                    Debug.Log("StopCoroutinedamnit");
                    yield break;
                }
                reportText.text += letter;
                //TODO do sound

                yield return new WaitForSeconds(delay);
            }
        }
        typing = false;
    }
}
