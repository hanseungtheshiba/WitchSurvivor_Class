using UnityEngine;

public class Enemy : Poolable
{
    [SerializeField]
    private float speed = 1f;
    private Rigidbody2D target = null;
    private Rigidbody2D rigid = null;

    private Vector2 dirVector = Vector2.zero;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameManager.Instance.CurrentPlayer.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.CurrentPlayer == null) {
            return; 
        }

        target = GameManager.Instance.CurrentPlayer.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }

        dirVector = target.position - rigid.position;

        float xScale = dirVector.x < 0 ? -1f : 1f;
        transform.localScale = new Vector3(xScale, 1f, 1f);

        Vector2 nextPosition = dirVector.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextPosition);
    }
}
