using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public GameObject tilePrefab; // Assign your tile prefab in the Inspector
    public int rows = 10;
    public int columns = 10;
    public float tileSize = 1.0f; // Adjust this based on the size of your tiles
    // Start is called before the first frame update
    void Start()
    {
        CreateTileMatrix();
    }
    void CreateTileMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calculate the position for the current tile
                Vector3 position = new Vector3(j * tileSize, 0, i * tileSize);

                // Instantiate the tile at the calculated position
                Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }
}
