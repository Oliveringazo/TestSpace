using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //[Header("Movement")]
    //[Tooltip("Base movement speed")]
    //public float baseSpeed = 10f;
    //[Tooltip("Base down movement speed")]
    //public float baseDownSpeed = 30f;

    public bool isAlive { get; set; }
    public bool hasChangedDirection;
    public bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        hasChangedDirection = false;
        movingRight = true;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    //void FixedUpdate()
    //{
    //    if (movingRight && transform.position.x < 8f)
    //    {
    //        transform.position += Vector3.right * baseSpeed * Time.deltaTime;
    //    } 
    //    else if (movingRight && transform.position.x > 8f)
    //    {
    //        movingRight = false;
    //        hasChangedDirection = true;
    //    }
    //    else if (!movingRight && transform.position.x > -8f)
    //    {

    //        transform.position += Vector3.left * baseSpeed * Time.deltaTime;
    //    }
    //    else if (!movingRight && transform.position.x < -8f)
    //    {
    //        movingRight = true;
    //        hasChangedDirection = true;
    //    }

    //    if (hasChangedDirection)
    //    {
    //        hasChangedDirection = false;
    //        transform.position += Vector3.down * baseDownSpeed * Time.deltaTime;
    //    }
    //}
}
