using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public int size = 10;

    void Start()
    {
        PlaceFloorAndWalls();
    }

    void PlaceFloorAndWalls()
    {
        // Place the floor tiles
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                Instantiate(floorPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        // Place the wall tiles
        for (int i = 0; i < size; i++)
        {
            // Place walls along the x-axis
            Instantiate(wallPrefab, new Vector3(i, 0, -1), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(i, 0, size), Quaternion.identity);

            // Place walls along the z-axis
            Instantiate(wallPrefab, new Vector3(-1, 0, i), Quaternion.Euler(0, 90, 0));
            Instantiate(wallPrefab, new Vector3(size, 0, i), Quaternion.Euler(0, 90, 0));
        }
    }
}