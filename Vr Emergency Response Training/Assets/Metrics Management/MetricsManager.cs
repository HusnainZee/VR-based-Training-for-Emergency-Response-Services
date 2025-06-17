using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MetricsManager : MonoBehaviour
{
    public static MetricsManager instance;
    
    Dictionary<string, float> MetricMap;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MetricMap = new Dictionary<string, float>();
    }

    public void SetMetric(string metric, float value)
    {
        MetricMap[metric] = value;
    }

    public void AddToMetric(string metric, float value)
    {
        if (!MetricMap.ContainsKey(metric))
        {
            SetMetric(metric, value);
            return;
        }

        MetricMap[metric] += value;
    }


    public string GetMetricsAsString()
    {
        string metricsStr = "Metrics\n";
        foreach (var metric in MetricMap)
        {
            string metricName = metric.Key.ToString();
            string metricValue = metric.Value.ToString();
            metricsStr += metricName + ": " + metricValue + "\n";
        }

        return metricsStr;
    }




}
