using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{	
	private Ray ray;
    private	RaycastHit hit;
    public List<float> validZs;

    public Vector3 touchEndPos;
	public GameObject selectedObj;

    void SlideCrate(GameObject obj)
    {
    	// move selected object 
    	if (selectedObj.tag == "Vertical")
    	{
    		VerticalCrate script = selectedObj.GetComponent<VerticalCrate>();

    		// sliding up
            if (touchEndPos.z > selectedObj.transform.position.z)
            {
                // don't move past upper limit
                if (touchEndPos.z > script.zUpperLimit)
                {
                    selectedObj.transform.position = new Vector3(selectedObj.transform.position.x, selectedObj.transform.position.y, script.zUpperLimit);
                }
                // otherwise follow touch position
                else
                {
                    selectedObj.transform.position = new Vector3(selectedObj.transform.position.x, selectedObj.transform.position.y, Mathf.Round(touchEndPos.z) - 0.5f);
                }
            }

            // sliding down
            if (touchEndPos.z < selectedObj.transform.position.z)
            {
                // don't move past upper limit
                if (touchEndPos.z < script.zLowerLimit)
                {
                    selectedObj.transform.position = new Vector3(selectedObj.transform.position.x, selectedObj.transform.position.y, script.zLowerLimit);
                }
                // otherwise follow touch position
                else
                {
                    selectedObj.transform.position = new Vector3(selectedObj.transform.position.x, selectedObj.transform.position.y, Mathf.Round(touchEndPos.z) + 0.5f);
                }
            }
    	}

    	// move selected object 
    	else if (selectedObj.tag == "Horizontal")
    	{
    		HorizontalCrate script = selectedObj.GetComponent<HorizontalCrate>();

    		// sliding right
            if (touchEndPos.x > selectedObj.transform.position.x)
            {
                // don't move past right limit
                if (touchEndPos.x > script.xUpperLimit)
                {
                    selectedObj.transform.position = new Vector3(script.xUpperLimit, selectedObj.transform.position.y, selectedObj.transform.position.z);
                }
                // otherwise follow touch position
                else
                {
                    selectedObj.transform.position = new Vector3(Mathf.Round(touchEndPos.x) - 0.5f, selectedObj.transform.position.y, selectedObj.transform.position.z);
                }
            }

            // sliding left
            if (touchEndPos.x < selectedObj.transform.position.x)
            {
                // don't move past left limit
                if (touchEndPos.x < script.xLowerLimit)
                {
                    selectedObj.transform.position = new Vector3(script.xLowerLimit, selectedObj.transform.position.y, selectedObj.transform.position.z);
                }
                // otherwise follow touch position
                else
                {
                    selectedObj.transform.position = new Vector3(Mathf.Round(touchEndPos.x) + 0.5f, selectedObj.transform.position.y, selectedObj.transform.position.z);
                }
            }
    	}
    }

    void Update()
    {
    	// click/touch start
        if (Input.GetMouseButtonDown(0))
        {
        	// get object clicked/touched
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if (Physics.Raycast(ray, out hit))
        	{
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
        		touchEndPos = hit.point;
        	}

   	    	SlideCrate(selectedObj);
        }

        // click/touch release
        if (Input.GetMouseButtonUp(0))
        {
        	// get end position 
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if (Physics.Raycast(ray, out hit))
        	{
        		touchEndPos = hit.point;
        	}

        	// increment number of moves
        }
    }
}
