using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerWraper : MonoBehaviour
{
    public void GoToLevelOne()
    {
        SceneController.GoToLevelOne();
    }

    public void GoToLevelTwo()
    {
        SceneController.GoToLevelTwo();
    }

    public void GoToCredits()
    {
        SceneController.GoToCredits();
    }

    public void GoToGameOver()
    {
        SceneController.GoToGameOver();
    }

    public void GoToTitleScreen()
    {
        SceneController.GoToTitleScreen();
    }

    public int GetCurrentLevel()
    {
        return SceneController.Level;
    }

    public int GetCurrentScore()
    {
        return SceneController.Score;
    }

    public void SaveScore(int score)
    {
        SceneController.SaveScore(score);
    }

}
