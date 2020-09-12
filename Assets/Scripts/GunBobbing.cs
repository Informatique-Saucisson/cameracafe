using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBobbing : MonoBehaviour
{

    Animator m_animator;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x >0 | z > 0)
        {
            isWalking = true;
        }

        if (x == 0 && z == 0)
        {
            isWalking = false;
        }

        if (isWalking == true)
        {
            m_animator.SetBool("isWalking", true);
        }

        if (isWalking == false)
        {
            m_animator.SetBool("isWalking", false);
        }
        
    }
}
