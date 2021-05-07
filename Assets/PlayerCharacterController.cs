using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Shooting")]
    [Tooltip("Projectile Prefab")]
    public Projectile m_projectile_prefab;
    [Tooltip("Time in between shots")]
    public float fireRate = 0.5f;

    [Header("Movement")]
    [Tooltip("Max movement speed")]
    public float maxSpeed = 10f;
    [Tooltip("Acceleration")]
    public float accelerationSpeed = 10f;


    public Vector2 m_CharacterVelocity { get; set; }

    private AudioSource m_ShotSound;
    private PlayerInputHandler m_InputHandler;
    private Rigidbody2D m_RigidBody2D;
    private bool m_wantsToShoot;
    private GameFlowManager m_GM;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        m_ShotSound = GetComponent<AudioSource>();
        m_InputHandler = GetComponent < PlayerInputHandler >();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_wantsToShoot = false;
        nextFire = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        HandleCharacterMovement();
        HandleShooting(m_InputHandler.GetFireInputDown(), m_InputHandler.GetFireInputHeld(),  m_InputHandler.GetFireInputReleased());
    }

    void FixUpdate()
    {
       
    }

    void HandleCharacterMovement()
    {
        Vector2 targetVelocity = m_InputHandler.GetMoveInput().normalized * accelerationSpeed * maxSpeed;
        m_CharacterVelocity = Vector2.Lerp(m_CharacterVelocity, targetVelocity, Time.deltaTime);
        m_RigidBody2D.velocity = m_CharacterVelocity; 
    }

     public bool HandleShooting(bool inputDown, bool inputHeld, bool inputUp)
    {
        //Here would be the logic for different weapons
        m_wantsToShoot = inputDown || inputHeld;

        if (m_wantsToShoot)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                return Shooting();

            }
        }
        return false;
    }

    public bool Shooting()
    {
        m_ShotSound.Play();
        Projectile projectile_shot = Instantiate(m_projectile_prefab, transform);
        projectile_shot.OnShoot();
        m_wantsToShoot = false;
        return true; 
    }

    void OnTriggerEnter2D(Collider2D object_collided)
    {
        if (object_collided.tag == "Enemy")
        {
            Destroy(gameObject);
            m_GM = FindObjectOfType<GameFlowManager>();
            m_GM.OnDeath();

        }
    }

}
