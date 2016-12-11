using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Story : MonoBehaviour
{

    public bool Report = false;
    public List<Story> StoryDependancies;

    [TextArea(3,10)]
    public string storyToReport;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleReporting()
    {
        Report = !Report;
        if (ReportManager.Instance.ReportStory(this, ReportManager.Instance.CurrentDay))
        {
            HandleReporting();
        }
        else
        {
            Report = !Report;
        }


    }

    

    public bool CheckDependancies()
    {
        foreach (Story s in StoryDependancies)
        {
            if (!s.Report) return false;
        }
        return true;
    }

    public abstract void HandleReporting();
}
