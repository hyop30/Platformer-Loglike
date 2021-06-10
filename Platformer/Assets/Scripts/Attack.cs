using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        //공격 애니메이션
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
        }
        else if (!Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", false);
        }
    }
}
