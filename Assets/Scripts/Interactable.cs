using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Interactable : MonoBehaviour, IPointerClickHandler {

    public GameObject[] storyWindows;

    // Use this for initialization
    void Start () {
        if (storyWindows.Length != ReportManager.Instance.totalDays)
            Debug.Log("Interactable " + name + " does not contain the required number of story windows");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        storyWindows[ReportManager.Instance.CurrentDay].SetActive(true);
    }
}
