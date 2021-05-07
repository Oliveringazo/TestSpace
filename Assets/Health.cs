using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("General")]
    [Tooltip("Health points")]
    public int maxHealth = 1;
    [Tooltip("Invincibility frames")]
    public int invincibilityFrames = 1;
    [Tooltip("Points given on death")]
    public int PointsByDeath = 1;

    public int currentHealth { get; set; }
    public int currentInvincibility { get; set; }
    public bool invincible { get; set; }

    public bool isDead;
    private AudioSource m_DeathSound;
    private GameFlowManager m_GM;

    void Start()
    {
        m_DeathSound = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        currentHealth = maxHealth;
        invincible = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (invincible) return;
        currentHealth -= damage;

        
        if (currentHealth <= 0)
        {
            onDeath();
        }
    }

    public void onDeath()
    {
        if (!isDead)
        {
            isDead = true;
            //if (m_DeathSound) m_DeathSound.Play(); Sound is too long and i would need to set a trigger once is over to delete the object.

            m_GM = FindObjectOfType<GameFlowManager>();
            m_GM.addScore(PointsByDeath, transform.position.y);
            Destroy(gameObject);

        }
    }
}
