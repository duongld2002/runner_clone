using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 16.5f;
    public int numberOfTiles = 7;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else if (i == 6)
            {
                SpawnTile(5);
            }
            else
            {
                SpawnTile(Random.Range(1, tilePrefabs.Length - 1));
            }
            
        }
    }

    //void Update()
    //{
    //    if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
    //    {
    //        SpawnTile(Random.Range(1, tilePrefabs.Length));
    //        //DeleteTile();
    //    }
    //}

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

}
