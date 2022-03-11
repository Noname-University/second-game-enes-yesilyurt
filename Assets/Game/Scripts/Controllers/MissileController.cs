using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{

    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private Transform missileParent;

    [SerializeField]
    private int missileCount;

    private Queue<GameObject> pool;


    private void Awake()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < missileCount; i++)
        {
            var missile = Instantiate(missilePrefab, transform.position, Quaternion.identity, missileParent);
            missile.SetActive(false);
            pool.Enqueue(missile);
        }
    }

    public void Fire()
    {
        var missile = pool.Dequeue();
        missile.transform.position = transform.position;
        missile.SetActive(true);

        pool.Enqueue(missile);
    }
}
