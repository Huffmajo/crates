using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
	public Vector3 swipeStartPos;
	public Vector3 swipeEndPos;
	public float swipeAngle;

	private LineRenderer swipeLine;
	private Ray ray;
    private	RaycastHit hit;
    private Rigidbody rb;

    private enum Direction {UP, DOWN, LEFT, RIGHT};
    private Direction dir;

	GameObject selectedObj;

    void Start()
    {
    	rb = GetComponent<Rigidbody>();

       // instantiate swipe line
       swipeLine = gameObject.AddComponent<LineRenderer>();
       swipeLine.positionCount = 2;
       swipeLine.startWidth = 1f;
       swipeLine.endWidth = 0f;
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
   	    Vector3 posDiff = swipeEndPos - swipeStartPos;
   	    swipeAngle = Mathf.Atan2(posDiff.x, posDiff.z) * Mathf.Rad2Deg + 180;
    }

    // determines input from swipe
    /*
    Direction SwipeInput()
    {

    }
	*/

    // check position is clear for movement
    bool DirectionClear(Direction dir)
    {
    	Vector3 dirVector;

    	switch(dir)
    	{
    		case Direction.UP:
    			dirVector = Vector3.forward;
    			break;

    		case Direction.DOWN:
    			dirVector = Vector3.back;
    			break;

    		case Direction.LEFT:
    			dirVector = Vector3.left;
    			break;

    		case Direction.RIGHT:
    			dirVector = Vector3.right;
    			break;

    		default:
    			dirVector = Vector3.up;
    			break;
    	}

    	if (Physics.Raycast(transform.position, dirVector, out hit, 1f))
    	{
    		return false;
    	}
    	else
    	{
    		return true;
    	}
    }

    // move crate
    void Move(Direction dir, float thrust)
    {
    	Vector3 dirVector;

    	switch(dir)
    	{
    		case Direction.UP:
    			dirVector = Vector3.forward;
    			break;

    		case Direction.DOWN:
    			dirVector = Vector3.back;
    			break;

    		case Direction.LEFT:
    			dirVector = Vector3.left;
    			break;

    		case Direction.RIGHT:
    			dirVector = Vector3.right;
    			break;

    		default:
    			dirVector = Vector3.up;
    			break;
    	}

    	rb.AddForce(dirVector * thrust);
    }

}
