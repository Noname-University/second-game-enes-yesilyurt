using System;
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
    private float boundX;
    private float boundY;

    private void Awake() 
    {
        boundX = Camera.main.orthographicSize/2-7;
        boundY = Camera.main.orthographicSize - 7;
        missileController = GetComponent<MissileController>();
    }
    
    private void Start() 
    {
        StartCoroutine(Fire());
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other) 
    {
        var collectable = other.GetComponent<ICollectable>();
        if(collectable != null)
        {
            collectable.Collect();
        }
    }

    private void Movement()
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

            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, -boundX, boundX),
                0,
                Mathf.Clamp(transform.position.z, -boundY, 0)
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
