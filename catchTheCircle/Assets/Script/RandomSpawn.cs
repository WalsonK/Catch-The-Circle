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
    private float timeToSpawn = 2f;
    public float timeBetweenWave = 1f;

    public float forwardForce = 500f;
    public int MaxWave = 10;


    void Update()
    {
     
         if (Time.time >= timeToSpawn && SpawnCount < MaxWave)
        {
            Spawner();
            timeToSpawn = Time.time + timeBetweenWave;
            SpawnCount++;
        }
            
  
    }

    void FixedUpdate()
    {
        spawner.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z + forwardForce * Time.deltaTime);  
    }
    // Start is called before the first frame update

    void Spawner()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            newObject = Instantiate(Shapes[Random.Range(0, Shapes.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
            newObject.GetComponent<Renderer>().material = Colors[Random.Range(0, Colors.Length)];
        }

    }

}

