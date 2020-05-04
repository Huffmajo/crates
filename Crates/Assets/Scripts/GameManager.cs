using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool gameWon;
	public int numMoves;
	public GameObject targetCrate;

	private RaycastHit hit;
	private Ray ray;

    void Start()
    {
        gameWon = false;
    }

    void Update()
    {
        // check for win condition
        if (Physics.Raycast(targetCrate.transform.position, Vector3.down , out hit))
        {
        	if (hit.collider.gameObject.tag == "Finish" && !gameWon)
        	{
        		// change color of crate to show win state
        		targetCrate.GetComponent<Renderer>().material.color = Color.black;
        		gameWon = true;
        	}
        }
    }
}
