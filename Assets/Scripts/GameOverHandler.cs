using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{  
    [SerializeField] private GameObject Player;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AstreoidSpawner astreoidSpawner;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text gameOverScore;

    public void EndGame()
    {
        astreoidSpawner.enabled = false;
        int finalScore = scoreSystem.EndTimer();
        gameOverScore.text = $"Ze Yotze \n {finalScore}";
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();
        Player.transform.position = Vector3.zero;
        Player.SetActive(true);
        astreoidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
}
