using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class ProjectileBasic : MonoBehaviour
{
    [Header("General")]
    [Tooltip("Bullet Speed")]
    public float bulletSpeed = 10f;
    [Tooltip("Damage")]
    public int damage = 1;
    [Tooltip("Life time")]
    public float maxLifeTime = 10f;

    private Vector2 velocity;
    Projectile m_ProjectilePrefab;
    Rigidbody2D m_Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        m_ProjectilePrefab = GetComponent<Projectile>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    //void Update()
    //{

    //    m_Rigidbody2D.velocity = Vector2.up * bulletSpeed * Time.deltaTime;
    //}

    void FixedUpdate()
    {

        m_Rigidbody2D.velocity = Vector2.up * bulletSpeed * Time.deltaTime;
        //transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    }

    void OnShoot()
    {

    }

    void OnTriggerEnter2D(Collider2D object_collided)
    {
        if (object_collided.tag == "Enemy")
        {
            Damageable m_damageable = object_collided.GetComponent<Damageable>();
            m_damageable.InflictDamage(damage);
            Destroy(gameObject);
        }
    }
}