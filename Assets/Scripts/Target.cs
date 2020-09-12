
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public float deathability = -100f;
    Rigidbody corpse;
    Collider body;

    private void Start()
    {
        corpse = GetComponent<Rigidbody>();
        body = GetComponent<Collider>();
        setRigidBodyState(true);
        setColliderState(false);
    }

    public void TakeDamage (Vector3 direction, float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
          Die();
          corpse.AddForce(direction * deathability, ForceMode.Impulse);
          Debug.Log(direction * deathability);
        }

    }

    public void Die()
    {
        GetComponent<Animator>().enabled=false;
        setRigidBodyState(false);
        setColliderState(true);
        
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

       // corpse.isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        body.enabled = !state;
    }

}
