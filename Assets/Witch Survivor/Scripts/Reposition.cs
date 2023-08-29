using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPosition = GameManager.Instance.CurrentPlayer.transform.position;
        Vector3 mapPosition = transform.position;
        float diffX = Mathf.Abs(playerPosition.x - mapPosition.x);
        float diffY = Mathf.Abs(playerPosition.y - mapPosition.y);
    }
}
