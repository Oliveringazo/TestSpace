using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public Health m_Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        m_Health = GetComponentInParent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
    }

    public void InflictDamage(int damage)
    {
        m_Health.TakeDamage(damage);
    }
}
