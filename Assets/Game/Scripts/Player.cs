using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float fireTime;

    [SerializeField]
    private GameObject missile;
    
    private void Start() 
    {
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position += new Vector3
            (
                touch.deltaPosition.x * Time.deltaTime * speed,
                0,
                touch.deltaPosition.y * Time.deltaTime * speed
            );
        }
    }

    private IEnumerator Fire()
    {
        Instantiate(missile, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(fireTime);
        StartCoroutine(Fire());
    }
}
