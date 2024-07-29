using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    [SerializeField]
    float life;

    [SerializeField]
    KeyCode attackKey;

    [SerializeField]
    Subject enemy;

    [SerializeField]
    float damage;

    public event Action<float> ThingHappened;

    [SerializeField]
    Animator animator;

    public void NotifyObservers()
    {
        Debug.Log("Subject " + gameObject.name + " does thing");
        ThingHappened?.Invoke(life);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void DealDamage()
    {
        enemy?.ReceiveDamage(damage);
    }

    public void ReceiveDamage(float damage)
    {
        life -= damage;
        NotifyObservers();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && enemy != null)
        {
            Attack();
        }
    }
}
