using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    Animator m_animator;
    private bool isNextToDoor;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        isNextToDoor = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isNextToDoor = false;
        Debug.Log("C'est ça casse-toi");
    }
    void OnTriggerEnter(Collider other)
    {
        isNextToDoor = true;
        Debug.Log("TOUCHE-MOI LA GROSSE PORTE");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Activate") && isNextToDoor == true)
        {
               
            m_animator.SetTrigger("OpenTrigger");

        }

    }
}
