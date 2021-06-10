using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    public float damage = 1.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.black;
    }
}
