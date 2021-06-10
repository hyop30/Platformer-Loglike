using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private Animator animator;
    private Transform saveObject;

    int stack = 0;
    int flag = 0;

    [SerializeField]
    private GameObject savePrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        saveObject = GetComponent<Transform>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //저장 애니메이션
        if (Input.GetKey(KeyCode.E))
        {
            stack++;
            if(flag == 1)
            {
                animator.SetBool("isSave", true);
                flag = 0;
            }
            else
            {
                animator.SetBool("isSave", false);
                flag = 1;
            }   
        }
        else
        {
            stack = 0;
            animator.SetBool("isSave", false);
        }

        if (stack >= 250)
        {
            Instantiate(savePrefab, saveObject.position, saveObject.rotation);
            stack = 0;
        }
    }
}
