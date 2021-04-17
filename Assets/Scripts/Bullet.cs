using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public float damage = 10f;
    public GameObject destination;
    bool HasAim { get { return destination != null; } }
    private void Update()
    {
        Fly();
    }
    public void Fly()
    {
        if (HasAim)
        {
            try
            {
                Vector3 deltaPosition = (destination.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, deltaPosition);
                transform.position += deltaPosition * Time.deltaTime * speed;
                if (CollidesWithObject())
                    Hit();
            }
            catch (Exception)
            {
                Destroy(gameObject);
            }
        }
        else Destroy(gameObject);
    }
    public void SetDestination(GameObject target)
    {
        destination = target;
    }
    private bool CollidesWithObject()
    {
        return Vector3.Distance(transform.position, destination.transform.position) < 0.2f;
    }
    public void Hit()
    {
        destination.GetComponent<EnemyStats>().ReceiveDamage(damage);
        Destroy(gameObject);
    }
}
