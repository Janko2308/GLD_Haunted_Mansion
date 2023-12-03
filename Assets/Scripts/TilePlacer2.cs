using UnityEngine;

public class TilePlacer2 : MonoBehaviour
{
    public GameObject floorPrefab;
    //public GameObject wallPrefab;
    public int sizex = 10;
    public int sizez = 7;


    void Start()
    {
        PlaceFloorAndWalls2();
    }

    void PlaceFloorAndWalls2()
    {
        // Place the floor tiles
        for (int x = 0; x < sizex; x++)
        {
            for (int z = 0; z < sizez; z++)
            {
                Instantiate(floorPrefab, new Vector3(x, 3.1f, z), Quaternion.identity);
            }
        }
        /*
        // Place the wall tiles
        for (int i = 0; i < sizex; i++)
        {
            // Place walls along the x-axis
            Instantiate(wallPrefab, new Vector3(i, 0, 0), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(i, 0, sizex-2), Quaternion.identity);
        }
        for (int i = 0; i < sizez; i++)
        {
            // Place walls along the z-axis
            Instantiate(wallPrefab, new Vector3(-1, 0, i), Quaternion.Euler(0, 90, 0));
            Instantiate(wallPrefab, new Vector3(sizez+1, 0, i), Quaternion.Euler(0, 90, 0));
        }*/
    }
}