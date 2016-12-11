using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Story : MonoBehaviour
{

    public bool Report = false;
    public List<Story> StoryDependancies;

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
        if (ReportManager.Instance.ReportStory(!Report, ReportManager.Instance.CurrentDay))
        {
            Report = !Report;
            HandleReporting();
        }
        // Report = !Report;


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
