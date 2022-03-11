using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFireSpeed : MonoBehaviour, ICollectable
{
    [SerializeField]
    private float speed;
    
    private void Update() 
    {
        transform.position -= transform.forward * Time.deltaTime * speed;   
    }
    public void Collect()
    {
        Debug.Log("asd");
    }

    public void Spawn(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
