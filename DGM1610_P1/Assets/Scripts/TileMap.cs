using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public int tileDim = 1; //the 3d tile dimensions 
    public Vector3 mapDim = new Vector3(10, 10, 1);     //the width and height of the map
    private GameObject tile;
    
    void Start()
    {
        tile = transform.GetChild(0).gameObject;
        tile.transform.localScale = new Vector3(tileDim, tileDim, tileDim);

        for (int x = 0; x < mapDim.x; x += tileDim)
        {
            for (int y = 0; y < mapDim.y; y += tileDim)
            {
                for (int z = 0; z < mapDim.z; z += tileDim)
                {
                    //place floor and ceiling tiles
                    GameObject clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(x, y, z);

                    clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(x, y + 4, z);

                    //place wall tiles
                    clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(x, z, y);

                    clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(y, z, x);

                    clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(x, z, y + 10);

                    clone = GameObject.Instantiate(tile);
                    clone.transform.position = new Vector3(y + 10, z, x);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
