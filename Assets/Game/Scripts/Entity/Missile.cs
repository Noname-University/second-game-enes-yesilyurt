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

        if(Vector3.Distance(transform.position, Player.Instance.transform.position) > 130)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        var killable = other.GetComponent<IKillable>();
        if(killable != null)
        {
            killable.TakeHit(1);
            gameObject.SetActive(false);
        }
    }
}
