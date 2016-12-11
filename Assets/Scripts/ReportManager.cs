using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportManager : Utility.Singleton<ReportManager>
{
    public int[] numberOfStoryReports;
    public int totalDays;
    public int reportsPerDay;
    public int CurrentDay = 0;

    public GameObject MessagePanel;
    public GameObject OnAirPanel;

    void Awake()
    {
        numberOfStoryReports = new int[totalDays];
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool ReportStory(bool report, int day)
    {
        if(numberOfStoryReports[day] < reportsPerDay || !report)
        {
            if (report)
                numberOfStoryReports[day]++;
            else
                numberOfStoryReports[day]--;

            if(numberOfStoryReports[day] == reportsPerDay)
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

    }
    
}
