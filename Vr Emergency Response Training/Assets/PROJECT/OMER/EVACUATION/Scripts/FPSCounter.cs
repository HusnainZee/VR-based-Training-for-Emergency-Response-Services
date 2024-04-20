using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private Dictionary<int, string> CachedNumberStrings = new();
    private int[] _frameRateSamples;
    private int _cacheNumbersAmount = 300;
    private int _averageFromAmount = 30;
    private int _averageCounter = 0;
    private int _currentAveraged;

    void Awake()
    {
        {
            for (int i = 0; i < _cacheNumbersAmount; i++)
            {
                CachedNumberStrings[i] = i.ToString();
            }
            _frameRateSamples = new int[_averageFromAmount];
        }
    }
    void Update()
    {
        var currentFrame = (int)Math.Round(1f / Time.smoothDeltaTime); 
        _frameRateSamples[_averageCounter] = currentFrame;

      
        var average = 0f;

        foreach (var frameRate in _frameRateSamples)
        {
            average += frameRate;
        }

        _currentAveraged = (int)Math.Round(average / _averageFromAmount);
        _averageCounter = (_averageCounter + 1) % _averageFromAmount;

        if (_currentAveraged < 30)
            _currentAveraged += 30;

        Text.text = "FPS: " + _currentAveraged switch
        {
            var x when x >= 0 && x < _cacheNumbersAmount => CachedNumberStrings[x],
            var x when x >= _cacheNumbersAmount => $"> {_cacheNumbersAmount}",
            var x when x < 0 => "< 0",
            _ => "?"
        };

            
    }
}