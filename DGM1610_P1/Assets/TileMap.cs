using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public int tileDim = 1; //the 3d tile dimensions 
    public Vector3 mapDim = new Vector3(10, 10, 0);     //the width and height of the map
    private GameObject tile;
    void Start()
    {
        tile = transform.GetChild(0).gameObject;
        tile.transform.localScale = new Vector3(tileDim, tileDim, tileDim);

        for (int x = 0; x < mapDim.x; x++)
        {
            for (int y = 0; y < mapDim.x; y++)
            {
                for (int z = 0; z < mapDim.z; y++)
                {
                    //place tiles
                    //instantiate();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
