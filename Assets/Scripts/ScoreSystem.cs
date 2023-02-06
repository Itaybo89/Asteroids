using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreFactor;
    private float score;
    private bool shouldCount = true;

    void Update()
    {
        if (!shouldCount) { return; }
        
        score += Time.deltaTime * scoreFactor;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }

    public void StartTimer()
    {
        shouldCount = true;
    }
}
