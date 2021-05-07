using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private SceneControllerWraper m_SceneManager;
    private Canvas m_Canvas;
    private Text[] m_Texts;
    private string scoreText;

    // Start is called before the first frame update
    void Start()
    {
        m_SceneManager = GetComponentInChildren<SceneControllerWraper>();
        m_Canvas = GetComponentInChildren<Canvas>();
        m_Texts = GetComponentsInChildren<Text>();
        scoreText = "Score: " + m_SceneManager.GetCurrentScore();
        m_Texts[1].text = scoreText;

    }
}
