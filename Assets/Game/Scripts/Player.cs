using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float fireTime;

    private MissileController missileController;
    
    private void Start() 
    {
        missileController = GetComponent<MissileController>();
        
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
        missileController.Fire();
        yield return new WaitForSeconds(fireTime);
        StartCoroutine(Fire());
    }
}
