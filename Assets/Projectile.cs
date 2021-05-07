using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject owner { get; private set; }
    public Vector2 initialPosition { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixUpdate()
    {
      //  m_RigidBody2D.y += velocity * Time.deltaTime;
    }

    public void OnShoot()
    {
        
       // m_RigidBody2D = GetComponent<Rigidbody2D>();
       // initialPosition = transform.position;
      //  velocity = transform.y * bulletSpeed;

    }
}
