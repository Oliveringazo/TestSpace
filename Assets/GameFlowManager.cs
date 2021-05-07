using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{

    [Header("Extras")]
    [Tooltip("Proximity score bonus")]
    public bool BonusScore;
    [Tooltip("Upper margin (3x Score)")]
    public float UpperMargin;
    [Tooltip("Down margin (1x Score)")]
    public float DownMargin;

    private EnemySwarmManager m_Swarm;
    private SceneControllerWraper m_SceneManager;
    private SpriteRenderer m_Background;
    private Sprite m_BackgroundImage;
    private Canvas m_Canvas;
    private Text m_Text;
    private string scoreText;

    public bool gameIsEnding { get; private set; }
    public int currentLevel { get; private set; }
    public int currentScore { get; private set; }
    public int currentEnemiesRemaining { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_Swarm = GetComponentInChildren<EnemySwarmManager>();
        m_SceneManager = GetComponentInChildren<SceneControllerWraper>();
        currentLevel = SceneController.Level;
        currentScore = 0;
        currentLevel = m_SceneManager.GetCurrentLevel();
        gameIsEnding = false;
        currentEnemiesRemaining = 0;
        currentEnemiesRemaining = m_Swarm.totalEnemies;
        m_Swarm.AdjustSpeedByLevel(currentLevel);

        m_Canvas = GetComponentInChildren<Canvas>();
        m_Text = GetComponentInChildren<Text>();
        scoreText = "Score: 0";
        m_Text.text = scoreText;

        m_Background = GetComponentInChildren<SpriteRenderer>();
        if(currentLevel == 1)
        {
            m_Background.sprite = Resources.Load<Sprite>("Backgrounds/gridLevel");
        }
        else
        {
            m_Background.sprite = Resources.Load<Sprite>("Backgrounds/brickLevel");
        }

        if(UpperMargin  <= DownMargin)
        {
            UpperMargin = -1;
            DownMargin = 1;
        }
    }

    public void OnDeath()
    {
        gameIsEnding = true;
        m_SceneManager.SaveScore(currentScore);
        m_SceneManager.GoToGameOver();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int points, float proximity)
    {
        int pointsGained = points;
        if (BonusScore)
        {
            int multiplier = 1;
            if(proximity > UpperMargin)
            {
                multiplier = 3;
            }
            else if(proximity > DownMargin)
            {
                multiplier = 2;
            }
            pointsGained *= multiplier;
        }
        currentScore += pointsGained;
        currentEnemiesRemaining--;
        scoreText = "Score " + currentScore;
        m_Text.text = scoreText;
        if (currentEnemiesRemaining <=0 )
        {
            gameIsEnding = true;
            m_SceneManager.SaveScore(currentScore);
            m_SceneManager.GoToGameOver();
        }

    }
}
