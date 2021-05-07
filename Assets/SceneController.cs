using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static int Level { get; private set; }
    public static int Score { get; private set; }

    public static void GoToTitleScreen()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public static void GoToLevelOne()
    {
        Level = 1;
        SceneManager.LoadScene("GameScene");
    }

    public static void GoToLevelTwo()
    {
        Level = 2;
        SceneManager.LoadScene("GameScene");
    }


    public static void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }


    public static void SaveScore(int score)
    {
        Score = score;
    }

    public static void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
