using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] points { get; private set; }

    private void Awake()
    {
        points = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            GameObject newEnemy = PoolManager.Instance.Spawn("Enemy");
            SpawnAtRandomPoint(newEnemy);
        }
    }

    public void SpawnAtRandomPoint(GameObject enemy) 
    {
        if (!enemy.activeInHierarchy) return;

        Transform point = points[Random.Range(1, points.Length)];        
        enemy.transform.SetParent(point, false);
        enemy.transform.localPosition = Vector3.zero;
        enemy.transform.parent = null;
    }
}
