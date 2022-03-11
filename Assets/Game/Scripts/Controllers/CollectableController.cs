using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class CollectableController : MonoSingleton<CollectableController>
{
    [SerializeField]
    private CollectableType[] collectableTypes;

    private ICollectable[] collectables;

    private int collectableCount = 0;


    private void Awake() 
    {
          InitPool();
    }

    private void Start() 
    {
        
    }


    public void SpawnCollectable(Vector3 position)
    {
        var index = Random.Range(0,collectableCount);
        var collectable = collectables[index];
        collectable.Spawn(position);
    }

    private void InitPool()
    {
        for (int i = 0; i < collectableTypes.Length; i++)
        {
            collectableCount += collectableTypes[i].Count;
        }

        collectables = new ICollectable[collectableCount];

        int index = 0;

        for (int i = 0; i < collectableTypes.Length; i++)
        {
            for (int j = 0; j < collectableTypes[i].Count; j++)
            {
                var collectable = Instantiate(collectableTypes[i].Prefab);
                collectable.SetActive(false);
                collectables[index] = collectable.GetComponent<ICollectable>();
                index++;
            }
        }  
    }
}

[System.Serializable]
public class CollectableType
{
    public GameObject Prefab;
    public int Count;
}
