using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class EmailStory : Story {

    public GameObject Subject;
    public Image ReportIndicator;
    

	// Use this for initialization
	void Start () {
        Subject.SetActive(false);

        if (!CheckDependancies())
        {
            gameObject.SetActive(false);
        }
        
        if (Report)
            ReportIndicator.color = Color.green;
        else
            ReportIndicator.color = Color.grey;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnable()
    {
        gameObject.SetActive(CheckDependancies());
        Subject.SetActive(false);
    }

    public void ToggleStory()
    {
        Subject.SetActive(!Subject.activeSelf);
    }

    public override void HandleReporting()
    {
        if (Report)
            ReportIndicator.color = Color.green;
        else
            ReportIndicator.color = Color.grey;
    }
}
