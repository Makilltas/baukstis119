using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject towers;
    public float spawnrate = 2;

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(towers);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime + spawnrate)
        {
            Instantiate(towers);
            lastSpawnTime = Time.time;
        }
    }
}
