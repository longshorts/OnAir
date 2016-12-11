using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportManager : Utility.Singleton<ReportManager>
{
    //public int[] numberOfStoryReports;
    public int totalDays;
    public int reportsPerDay;
    public int CurrentDay = 0;

    public List<Story> dayReports;

    public GameObject MessagePanel;
    public GameObject OnAirPanel;

    public Animation SceneTransition;

    public List<Interactable> interactables;


    void Awake()
    {
        //numberOfStoryReports = new int[totalDays];
        dayReports = new List<Story>();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool ReportStory(Story story, int day)
    {

        if(dayReports.Count < reportsPerDay || !story.Report)
        {
            if (story.Report)
            {
                //numberOfStoryReports[day]++;
                dayReports.Add(story);
            }
            else
            {
                //numberOfStoryReports[day]--;
                dayReports.Remove(story);
            }

            if (dayReports.Count == reportsPerDay)
            {
                OnAirPanel.SetActive(true);
                OnAirPanel.transform.GetChild(0).GetComponent<Text>().text = "You've selected the maximum number of stories you can report today. Do you want to go On Air?";
            }
            return true;
        }
        else
        {
            Debug.Log("Too many reports for day: " + day);
            MessagePanel.SetActive(false);
            MessagePanel.SetActive(true);
            MessagePanel.GetComponentInChildren<Text>().text = "Cannot report more than " + reportsPerDay + " reports for today. Deselect some reports first.";

            return false;
        }
        Debug.Log("DayReports:" + dayReports.Count);
    }

    public void EndDay()
    {
        Debug.Log("Ending day");
        SceneTransition.Play();
        dayReports.Clear();
        CurrentDay++;
        foreach(Interactable i in interactables)
        {
            i.Invoke("HandleNewDay", 2.0f);
        }
    }
    
}
