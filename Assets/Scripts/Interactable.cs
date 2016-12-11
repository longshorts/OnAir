using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class Interactable : MonoBehaviour, IPointerClickHandler {

    public GameObject storyParent;
    public List<Story> StoryDependancies;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(CheckDependancies());

        if (storyParent.transform.childCount != ReportManager.Instance.totalDays)
            Debug.Log("Interactable " + name + " does not contain the required number of story windows");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //storyWindows[ReportManager.Instance.CurrentDay].SetActive(true);
        storyParent.transform.GetChild(ReportManager.Instance.CurrentDay).gameObject.SetActive(true);
    }

    public bool CheckDependancies()
    {
        foreach (Story s in StoryDependancies)
        {
            if (!s.Report) return false;
        }
        return true;
    }

    public void HandleNewDay()
    {
        Debug.Log("Handling new day: " + name);
        gameObject.SetActive(CheckDependancies());
    }
}
