using UnityEngine;

public class Reposition : MonoBehaviour
{
    private CompositeCollider2D col = null;
    private Spawner spawner = null;

    private void Awake()
    {
        col = GetComponent<CompositeCollider2D>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        if (GameManager.Instance == null) return; 
        if (GameManager.Instance.CurrentPlayer == null) return;

        Vector3 playerPosition = GameManager.Instance.CurrentPlayer.transform.position;
        Vector3 mapPosition = transform.position;
        float diffX = Mathf.Abs(playerPosition.x - mapPosition.x);
        float diffY = Mathf.Abs(playerPosition.y - mapPosition.y);

        Vector3 playerDir = GameManager.Instance.CurrentPlayer.moveDirection;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * col.bounds.size.x * 2f);
                }
                else if(diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * col.bounds.size.y * 2f);
                }
                else
                {
                    transform.Translate(Vector3.right * dirX * col.bounds.size.x * 2f);
                    transform.Translate(Vector3.up * dirY * col.bounds.size.y * 2f);
                }
                break;
            case "Enemy":                
                spawner.SpawnAtRandomPoint(gameObject);
                break;
        }
    }
}
