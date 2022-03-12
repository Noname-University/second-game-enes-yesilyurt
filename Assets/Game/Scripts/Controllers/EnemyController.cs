using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyLines[] lines;

    private void Start()
    {
        var orthographic = Camera.main.orthographicSize;

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].count; j++)
            {
                var enemy = Instantiate(lines[i].enemy, new Vector3
                (
                    -lines[i].count/2f * lines[i].offset.x + lines[i].offset.x * j,
                    0,
                    orthographic + lines[i].offset.y * (i+1)
                ),
                Quaternion.identity);

                enemy.transform.eulerAngles = new Vector3(0,180,0);
            }
        }
    }
}

[System.Serializable]
public class EnemyLines
{
    public GameObject enemy;

    public int count;

    public Vector2 offset;
}
