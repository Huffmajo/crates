using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
	public Vector3 swipeStartPos;
	public Vector3 swipeEndPos;

	private LineRenderer swipeLine;
	private Ray ray;
    private	RaycastHit hit;


	GameObject selectedObj;

    void Start()
    {
       // instantiate swipe line
       swipeLine = gameObject.AddComponent<LineRenderer>();
       swipeLine.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
    	// click/touch start
        if (Input.GetMouseButtonDown(0))
        {
        	// WORKS BUT IS DEPENDENT ON CAMERA ANGLE AND POSITION
        	//swipeStartPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));

        	// get object clicked/touched
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if (Physics.Raycast(ray, out hit))
        	{
        		swipeStartPos = hit.point;
        		selectedObj = hit.collider.gameObject;
        		Debug.Log("SelectedObj: " + selectedObj);
        	}

        }

        // click/touch held
        if (Input.GetMouseButton(0))
        {
        	// get end position 
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if (Physics.Raycast(ray, out hit))
        	{
        		swipeEndPos = hit.point;
        	}

        	// WORKS BUT IS DEPENDENT ON CAMERA ANGLE AND POSITION
        	//swipeEndPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
        }

        // click/touch release
        if (Input.GetMouseButtonUp(0))
        {
        	// get end position 
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if (Physics.Raycast(ray, out hit))
        	{
        		swipeEndPos = hit.point;
        	}

        	//swipeEndPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
        }

        // draw swipe line
        swipeLine.SetPosition(0, swipeStartPos);
   	    swipeLine.SetPosition(1, swipeEndPos);
    }

}
