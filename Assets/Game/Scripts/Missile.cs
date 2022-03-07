using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if(Vector3.Distance(transform.position, Player.Instance.position) > 130)
        {
            Destroy(gameObject);
        }
    }
}
