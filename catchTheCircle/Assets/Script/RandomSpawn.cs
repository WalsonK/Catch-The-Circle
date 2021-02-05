using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawner;

    public GameObject[] Shapes;
    public Material[] shaders;
    private GameObject newObject;

    private int SpawnCount = 0;
    public float forwardForce = 500f;
    public int MaxWave = 10;


    // Start is called before the first frame update
    void Start()
    {

        while (SpawnCount < MaxWave)
        {
            Randomizer();
            spawner.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z + forwardForce);
            SpawnCount++;
        }
    }

    void Randomizer()
    {
        string obj = FindObjectOfType<GameManager>().obj.ToString();
        int randomVoid = Random.Range(0, spawnPoints.Length);
        Material shader;
        GameObject shape;

        for (int i = 0; i < spawnPoints.Length; i++)

        {
            if(i != randomVoid){
                Spawner(Shapes[Random.Range(0, Shapes.Length)],shaders[Random.Range(0, shaders.Length)], spawnPoints[i]);
            }
            else{

                switch (true)
                {

                    case bool _ when Regex.IsMatch(obj, "Jaune"):
                        shader = shaders[1];
                        break;

                    case bool _ when Regex.IsMatch(obj, "Bleu"):
                        shader = shaders[2];
                        break;

                    case bool _ when Regex.IsMatch(obj, "Violet"):
                        shader = shaders[0];
                        break;

                    default:
                        shader = shaders[Random.Range(0, shaders.Length)];
                        break;

                };

                switch (true)
                {
                    case bool _ when Regex.IsMatch(obj, "Spheres"):
                        shape = Shapes[2];
                        break;

                    case bool _ when Regex.IsMatch(obj, "Triangles"):
                        shape = Shapes[0];
                        break;

                    case bool _ when Regex.IsMatch(obj, "Cubes"):
                        shape = Shapes[1];
                        break;

                    default:
                        shape = Shapes[Random.Range(0, Shapes.Length)];
                        break;
                }

                Spawner(shape, shader, spawnPoints[i]);
            };
           
        }

    }

    void Spawner(GameObject Shape, Material shader, Transform spawnpoint)
    {
        newObject = Instantiate(Shape, new Vector3(spawnpoint.position.x + Random.Range(-1, 1), spawnpoint.position.y, spawnpoint.position.z), spawnpoint.rotation);
        newObject.GetComponent<Renderer>().material = shader;

        //diffuclt = true donc modifie les tags avec couleurs :
        if (FindObjectOfType<GameManager>().difficult == true)
        {
            //Sphere
            if (Shape.name == "Sphere" && shader.name == "purpleD")
            {
                newObject.tag = "circleP";
            }
            if (Shape.name == "Sphere" && shader.name == "yellowD")
            {
                newObject.tag = "circleY";
            }
            if (Shape.name == "Sphere" && shader.name == "blueD")
            {
                newObject.tag = "circleB";
            }

            //triangle
            if (Shape.name == "triangle" && shader.name == "purpleD")
            {
                newObject.tag = "triangleP";
            }
            if (Shape.name == "triangle" && shader.name == "yellowD")
            {
                newObject.tag = "triangleY";
            }
            if (Shape.name == "triangle" && shader.name == "blueD")
            {
                newObject.tag = "triangleB";
            }

            //cube
            if (Shape.name == "cube1" && shader.name == "purpleD")
            {
                newObject.tag = "cubeP";
            }
            if (Shape.name == "cube1" && shader.name == "yellowD")
            {
                newObject.tag = "cubeY";
            }
            if (Shape.name == "cube1" && shader.name == "blueD")
            {
                newObject.tag = "cubeB";
            }


        }   


    }

}

