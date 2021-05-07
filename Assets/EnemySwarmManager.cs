using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwarmManager : MonoBehaviour
{ 
    [Header("Enemy numbers")]
    [Tooltip("Enemies per row")]
    public int enemiesPerRow= 4;
    [Tooltip("Number of rows (min 3)")]
    public int rowNumbers = 3;
    [Tooltip("Number of red enemies")]
    public int redEnemiesQty = 3;
    [Tooltip("Number of blue enemies")]
    public int blueEnemiesQty = 3;


    [Header("Enemy types")]
    [Tooltip("Green Enemy Prefab")]
    public GameObject m_green_prefab;
    [Tooltip("Blue Enemy Prefab")]
    public GameObject m_blue_prefab;
    [Tooltip("Red Enemy Prefab")]
    public GameObject m_red_prefab;

    [Header("Enemies Movement")]
    [Tooltip("Base movement speed")]
    public float baseSpeed = 10f;
    [Tooltip("Base down movement speed")]
    public float baseDownSpeed = 30f;

    [Header("Distance")]
    [Tooltip("Gap between enemies on x")]
    public int enemiesGapX = 10;
    [Tooltip("Gap between enemies on Y")]
    public int enemiesGapY = 10;
    [Tooltip("Starting point on y")]
    public int startingPointOnY = -4;

    public bool hasChangedDirection;
    public bool movingRight;

    public int totalEnemies { get; private set; }

    public GameObject[,] m_enemies_grid;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = baseSpeed;
        hasChangedDirection = false;
        movingRight = true;
        totalEnemies = rowNumbers * enemiesPerRow;
        m_enemies_grid = new GameObject[rowNumbers, enemiesPerRow];
        for (int i = 0; i< rowNumbers; i++)
        {
            Debug.Log("Index " +i);

            for (int j = 0; j < enemiesPerRow; j++)
            {
                Debug.Log("Enemy " + j);
                if(redEnemiesQty > 0 || blueEnemiesQty > 0)
                {
                    if(redEnemiesQty > 0)
                    {
                        m_enemies_grid[i, j] = Instantiate(m_red_prefab, transform);
                        redEnemiesQty--;
                    }
                    else
                    {
                        m_enemies_grid[i, j] = Instantiate(m_blue_prefab, transform);
                        blueEnemiesQty--;
                    }
                }
                else
                {

                    m_enemies_grid[i, j] = Instantiate(m_green_prefab, transform);
                }
                
                m_enemies_grid[i, j].transform.position = (Vector3.left * enemiesGapX * j) + (Vector3.down * (enemiesGapY * i + startingPointOnY)  );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustSpeedByLevel(int currentLevel)
    {
        Debug.Log("Current Level  "+ currentLevel);
        currentSpeed = baseSpeed * (float)currentLevel;
    }

    void FixedUpdate()
    {
        if (movingRight && transform.position.x < 6f)
        {
            transform.position += Vector3.right * currentSpeed * Time.deltaTime;
        }
        else if (movingRight && transform.position.x > 6f)
        {
            movingRight = false;
            hasChangedDirection = true;
        }
        else if (!movingRight && transform.position.x > 0f)
        {

            transform.position += Vector3.left * currentSpeed * Time.deltaTime;
        }
        else if (!movingRight && transform.position.x <  0f)
        {
            movingRight = true;
            hasChangedDirection = true;
        }

        if (hasChangedDirection)
        {
            hasChangedDirection = false;
            transform.position += Vector3.down * baseDownSpeed * Time.deltaTime;
        }
    }

}
