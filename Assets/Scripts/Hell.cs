using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell : MonoBehaviour
{
	
	public string targetTag = "foot";
     // Reference to the GameObject to be modified
    public GameObject cross;

    public GameObject monster1;
    public GameObject monster2;
    
	public GameObject kitty;
	public GameObject painting;

	public GameObject candlelight;
	public GameObject candlelight2;
    public GameObject candlelight3;
	public GameObject candlelight4;
	public GameObject candlelight5;
   
	public GameObject alien;

	public GameObject[] feet;

    // Coordinates defining the area
    public Vector3 areaCenter;
    public Vector3 areaSize;

    // Define the events to be triggered when the player enters and leaves the area
    public UnityEngine.Events.UnityEvent onPlayerEnter;
    public UnityEngine.Events.UnityEvent onPlayerExit;

    private bool isPlayerInsideArea = false;


    private void Update()
    {
        // Check if the player is inside the area
        bool isInsideNow = IsPlayerInsideArea();

        // Check if the player has entered the area
        if (isInsideNow && !isPlayerInsideArea)
        {
            // Trigger the event when the player enters the area
            OnPlayerEnterArea();
        }
        // Check if the player has exited the area
        else if (!isInsideNow && isPlayerInsideArea)
        {
            // Trigger the event when the player leaves the area
            OnPlayerExitArea();
        }

        isPlayerInsideArea = isInsideNow;

		
    }

    private void OnPlayerEnterArea()
    {
		
        // Modify the referenced GameObject
        ModifyObject();

        // Additional code you want to run when the player enters the area
        Debug.Log("Player entered the area!");

        // You can call other functions directly here if needed
    }

    private void OnPlayerExitArea()
    {
        // Additional code you want to run when the player exits the area
        Debug.Log("Player exited the area!");

        // You can call other functions directly here if needed
        RevertStuff();
    }

    private void ModifyObject()
    {
        // Check if the referenced GameObject is assigned
        if (cross != null)
        {
            // Rotate the object
            cross.transform.Rotate(new Vector3(180, 180, 0));

            // Change the object's size (scale)
            cross.transform.localScale = new Vector3(2, 2, 2);
        }

        monster1.SetActive(true);
        monster2.SetActive(true);
        
        kitty.transform.Rotate(new Vector3(0, 0, 30));
        kitty.transform.localScale = new Vector3(3, 3, 3);
        
        painting.transform.Rotate(new Vector3(0, 0, 120));
        painting.transform.localScale = new Vector3(3, 3, 3);

		candlelight.SetActive(true);
		candlelight2.SetActive(true);
    	candlelight3.SetActive(true);
		candlelight4.SetActive(true);
		candlelight5.SetActive(true);

		alien.SetActive(true);

		foreach (GameObject obj in feet)
        	{
            	obj.SetActive(true);
        	}	
    }

    private void RevertStuff()
    {
        if (cross != null)
        {
            // Rotate the object
            cross.transform.Rotate(new Vector3(180, 180, 0));

            // Change the object's size (scale)
            cross.transform.localScale = new Vector3(3, 3, 3);
        }
        
        monster1.SetActive(false);
        monster2.SetActive(false);
        
        kitty.transform.Rotate(new Vector3(0, 0, -30));
        kitty.transform.localScale = new Vector3(1, 1, 1);
        
        painting.transform.Rotate(new Vector3(0, 0, -120));
        painting.transform.localScale = new Vector3(1, 1, 1);

		candlelight.SetActive(false);
		candlelight2.SetActive(false);
    	candlelight3.SetActive(false);
		candlelight4.SetActive(false);
		candlelight5.SetActive(false);

		alien.SetActive(false);

		
		foreach (GameObject obj in feet)
        {
            obj.SetActive(false);
        }
    }

    private bool IsPlayerInsideArea()
    {
        // Check if the player's position is within the specified area
        return transform.position.x >= areaCenter.x - areaSize.x / 2 &&
               transform.position.x <= areaCenter.x + areaSize.x / 2 &&
               transform.position.z >= areaCenter.z - areaSize.z / 2 &&
               transform.position.z <= areaCenter.z + areaSize.z / 2;
    }
}