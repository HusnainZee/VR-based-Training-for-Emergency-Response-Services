using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using TMPro;

public class PlayerWaypointHandler : MonoBehaviour
{
    [SerializeField] Transform guideArrow;
    [SerializeField] GameObject FinishPanel;
    [SerializeField] TextMeshProUGUI Stats;

    float startTime;

    int numberOfWaypoints;
    int activeIndex;

    List<Transform> waypoints;
    private void Start()
    {
        waypoints = new List<Transform>();
        activeIndex = 0;
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(false);
            waypoints.Add(t);
            numberOfWaypoints++;
        }

        waypoints[activeIndex].gameObject.SetActive(true);
        startTime = Time.time;

    }

    private void Update()
    {
        guideArrow.LookAt(waypoints[activeIndex].transform);
    }

    public void ActivateNext()
    {
        if(activeIndex + 1 < numberOfWaypoints)
        {
            activeIndex++;
            waypoints[activeIndex - 1].gameObject.SetActive(false);
            waypoints[activeIndex].gameObject.SetActive(true);

        }
        else
        {
            waypoints[activeIndex].gameObject.SetActive(false);
            FinishPanel.SetActive(true);
            DisplayStats();
        }
        
        
    }

    void DisplayStats()
    {

        guideArrow.gameObject.SetActive(false);

        float endTime = Time.time;
        float timeTaken = endTime - startTime;

        MetricsManager.instance.SetMetric("Time Taken (Seconds)", timeTaken);

        string stats = MetricsManager.instance.GetMetricsAsString();

        Stats.text = stats;

    }
}
