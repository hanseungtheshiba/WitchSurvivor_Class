using UnityEngine;

public class Attack : Poolable
{
    [SerializeField]
    private float atk = 3f;
    [SerializeField]
    private float atkRemain = 0.5f;
    
    private void OnEnable()
    {
        Invoke("Release", atkRemain);        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.GetMask("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Damage(atk);
        }
    }    
}
