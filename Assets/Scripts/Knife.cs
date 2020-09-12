
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float damage = 10f;
    public float range = 5f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    private bool stabRight=true;

    Animator m_animator;

    public Camera fpsCam;
    public GameObject bloodEffect;

    private float nextTimeToFire = 0f;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && stabRight == true)
        {
            nextTimeToFire = Time.time + 0.60f;
            //Stab();
            m_animator.SetTrigger("Cut");
            
        }

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToFire && stabRight == true)
        {
            nextTimeToFire = Time.time + 1f;
            //Stab();
            m_animator.SetTrigger("Stab");

        }

    }


    void Stab()
    {
        Vector3 hitDirection = fpsCam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, hitDirection, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(fpsCam.transform.forward, damage);
            }

            hitDirection = fpsCam.transform.forward;

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.collider.tag == "Enemy")
            {
                GameObject bloodGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloodGO, 2f);
            }

        }

    }
}
