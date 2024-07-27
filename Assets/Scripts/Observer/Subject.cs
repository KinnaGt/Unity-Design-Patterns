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

    public void DoThing()
    {
        Debug.Log("Subject" + gameObject.name + "does thing");
        ThingHappened?.Invoke(life);
    }

    void Attack()
    {
        enemy?.ReceiveDamage(damage);
    }

    void ReceiveDamage(float damage)
    {
        life -= damage;
        DoThing();
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
