using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Microphone : MonoBehaviour, IPointerClickHandler
{

    public Text OnAirText;

    public void OnPointerClick(PointerEventData eventData)
    {
        string numberOfStoriesText;
        if(ReportManager.Instance.dayReports.Count < ReportManager.Instance.reportsPerDay)
        {
            numberOfStoriesText = "You have selected " + ReportManager.Instance.dayReports.Count + " stories to report today. ";
        }
        else if(ReportManager.Instance.dayReports.Count == ReportManager.Instance.reportsPerDay)
        {
            numberOfStoriesText = "You've selected the maximum number of stories you can report today. ";
        }
        else
        {
            numberOfStoriesText = "You've selected too many stories report today. (Nice one on breaking the game! :P) ";
        }
        OnAirText.text = numberOfStoriesText + "Do you want to go On Air?";
        OnAirText.transform.parent.gameObject.SetActive(true);
    }
}
