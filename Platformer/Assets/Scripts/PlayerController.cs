using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private	Movement2D movement2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;	// 오브젝트의 충돌 범위 컴포넌트

    private void Awake()
	{
        animator = GetComponent<Animator>();
        movement2D = GetComponent<Movement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

	private void Update()
	{
        // 플레이어 이동
        // left or a = -1  /  right or d = 1
        float x = Input.GetAxisRaw("Horizontal"); // 4
                                                  // 좌우 이동 방향 제어
        movement2D.Move(x);

        // 방향 전환
        if (x == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if (x == 1)
        {
            spriteRenderer.flipX = false;
        }

        // 공격 애니메이션
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
        }
        else if (!Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", false);
        }

        // 점프 애니메이션
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
        }

        // 달리기 애니메이션
        if (x != 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        // 플레이어 점프 (스페이스 키를 누르면 점프!)
        if ( Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.S))
		{
			movement2D.Jump();
		}

        // 플레이어 s 점프
        if(Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            movement2D.SJump();
        }

        // 스페이스 키를 누르고 있으면 isLongJump = true
        if ( Input.GetKey(KeyCode.Space))
		{
			movement2D.isLongJump = true;
		}
		// 스페이스 키를 떼면 isLongJump = false
		else if ( Input.GetKeyUp(KeyCode.Space) )
		{
			movement2D.isLongJump = false;
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(capsuleCollider2D.isTrigger == true)
        {
            capsuleCollider2D.isTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}

