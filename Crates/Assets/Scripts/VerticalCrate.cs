using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCrate : MonoBehaviour
{
	public static bool selected;
	public float zUpperLimit;
	public float zLowerLimit;

    private float distanceAbove;
    private float distanceBelow;
	private float halfSizeZ;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        halfSizeZ = transform.localScale.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        	distanceAbove = DistanceToObject(Vector3.forward);
	        distanceBelow = DistanceToObject(Vector3.back);
    	    zUpperLimit = GetMaxZ();
        	zLowerLimit = GetMinZ();
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

    // return maximum z position car can move to
    float GetMaxZ()
    {
    	float currentZ = transform.position.z;
    	return currentZ + distanceAbove - halfSizeZ;
    }

    // return minimum z position car can move to
    float GetMinZ()
    {
    	float currentZ = transform.position.z;
    	return currentZ - distanceBelow + halfSizeZ;
    }

    // return list of all acceptable positions including max and min
    List<float> GetAcceptablePositions(float max, float min)
    {
        List<float> positions = new List<float>();
        float position = max;
        while (position > min)
        {
            positions.Add(position);
            position -= 1f;
        }

        return positions;
    }

    // returns the position that is closest to currentPosition
    float ClosestAcceptablePosition(List<float> positions, float currentPosition)
    {
    	float delta;
    	float closest = Mathf.Infinity;

    	foreach (float position in positions)
    	{
    		delta = Mathf.Abs(currentPosition) - Mathf.Abs(position);
    		if (delta < closest)
    		{
    			closest = delta;
    		}
    	}
    	return closest;
    }
}
