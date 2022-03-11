using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private bool active = false;


    private bool jobDone = false;


    private void Update() 
    {
        if(active && !jobDone)
        {
            jobDone = true;

            CollectableController.Instance.SpawnCollectable(transform.position);
        }
    }
}
