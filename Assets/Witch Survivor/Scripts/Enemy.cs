using UnityEngine;

public class Enemy : MonoBehaviour
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

    private void OnEnable()
    {
        target = GameManager.Instance.CurrentPlayer.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        dirVector = target.position - rigid.position;
        Vector2 nextPosition = dirVector.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextPosition);
    }
}
