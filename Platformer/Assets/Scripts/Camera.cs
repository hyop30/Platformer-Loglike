using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    private Transform tr;

    static float slowup = 0f;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {

    }

    void LateUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        if (y == 1 && x == 0 && Movement2D.isGroundedInfo == true)
        {
            if (slowup <= 2.6f)
                slowup += 0.01f;
            tr.position = new Vector3(target.position.x + .05f, target.position.y + slowup, target.position.z - 6.56f);
        }
        else if(y == 0 && slowup > 0.6f)
        {
            slowup -= 0.01f;
            tr.position = new Vector3(target.position.x + .05f, target.position.y + slowup, target.position.z - 6.56f);
        }
        else if(y == -1 && x == 0 && Movement2D.isGroundedInfo == true)
        {
            if (slowup >= -1.4f)
                slowup -= 0.01f;
            tr.position = new Vector3(target.position.x + .05f, target.position.y + slowup, target.position.z - 6.56f);
        }
        else if (y == 0 && slowup < 0.6f)
        {
            slowup += 0.01f;
            tr.position = new Vector3(target.position.x + .05f, target.position.y + slowup, target.position.z - 6.56f);
        }
        else
        {
            tr.position = new Vector3(target.position.x + .05f, target.position.y + slowup, target.position.z - 6.56f);
            tr.LookAt(target);
        }
    }
}
