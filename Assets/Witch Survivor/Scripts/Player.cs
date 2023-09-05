using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float coolTime = 1.35f;

    private Rigidbody2D rigid2D;
    private Animator animator;

    public Vector2 moveDirection { get; private set; }

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InvokeRepeating("Attack", coolTime, coolTime);
    }

    private void FixedUpdate()
    {
        if (rigid2D == null) {
            return;
        }

        if (animator == null)
        {
            return;
        }

        animator.SetFloat("speed", moveDirection.magnitude);

        float xScale = moveDirection.x < 0 ? -1f : 1f;
        transform.localScale = new Vector3(xScale, 1f, 1f);
        rigid2D.MovePosition(rigid2D.position + moveDirection * speed * Time.fixedDeltaTime);

    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void Attack()
    {
        GameObject whip = PoolManager.Instance.Spawn("Whip");
        whip.transform.SetParent(transform);
    }
}
