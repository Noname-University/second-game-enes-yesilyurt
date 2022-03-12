using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFireSpeed : MonoBehaviour, ICollectable
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float value;



    private float maxDistance;


    private Vector3 spawnPosition;

    private void Awake() 
    {
        maxDistance = Camera.main.orthographicSize * 2 + 5;
    }
    
    private void Update() 
    {
        transform.position -= transform.forward * Time.deltaTime * speed;

        if(Vector3.Distance(transform.position, spawnPosition) > maxDistance)
        {
            gameObject.SetActive(false);
        }   
    }

    public void Collect()
    {
        gameObject.SetActive(false);
        Player.Instance.FireTime *= value;
    }

    public void Spawn(Vector3 position)
    {
        transform.position = position;
        spawnPosition = position;
        gameObject.SetActive(true);

        LeanTween.moveX(gameObject, 10, .4f).setOnComplete
        (()=>
            LeanTween.moveX(gameObject, -20, .8f).setLoopPingPong().setEaseInOutCubic()
        );
    }
}
