using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCrate : MonoBehaviour
{
    public static bool selected;
	public float xUpperLimit;
	public float xLowerLimit;

	private float distanceRight;
	private float distanceLeft;
	private float halfSizeX;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        halfSizeX = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        	distanceRight = DistanceToObject(Vector3.right);
	        distanceLeft = DistanceToObject(Vector3.left);
    	    xUpperLimit = GetMaxX();
        	xLowerLimit = GetMinX();
    }

    // return distance from object origin to nearest surface in dirVector's direction
    float DistanceToObject(Vector3 dirVector)
    {
    	RaycastHit hit;
    	if (Physics.Raycast(transform.position, dirVector, out hit, Mathf.Infinity))
    	{
    		return hit.distance;
    	}
    	else
    	{
    		return 0f;
    	}
    }

    // return maximum x position crate can move to
    float GetMaxX()
    {
    	float currentX = transform.position.x;
    	return currentX + distanceRight - halfSizeX;
    }

    // return minimum x position crate can move to
    float GetMinX()
    {
    	float currentX = transform.position.x;
    	return currentX - distanceLeft + halfSizeX;
    }
}
