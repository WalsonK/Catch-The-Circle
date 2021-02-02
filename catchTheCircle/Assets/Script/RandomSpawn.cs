using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawner;

    public GameObject[] Shapes;
    public Material[] Colors;
    private GameObject newObject;

    private int SpawnCount = 0;
    public float forwardForce = 500f;
    public int MaxWave = 10;


    void Start()
    {
        while (SpawnCount < MaxWave)
        {
            Spawner();
            spawner.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z + forwardForce);
            SpawnCount++;
        }
    }
    // Start is called before the first frame update

    void Spawner()
    {
        int randomVoid = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(i != randomVoid)
                {
                newObject = Instantiate(Shapes[Random.Range(0, Shapes.Length)], new Vector3(spawnPoints[i].position.x + Random.Range(-1,1), spawnPoints[i].position.y, spawnPoints[i].position.z), spawnPoints[i].rotation);
                newObject.GetComponent<Renderer>().material = Colors[Random.Range(0, Colors.Length)];
            }
           
        }

    }

}

