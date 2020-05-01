using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarVertical : MonoBehaviour
{
	public static bool selected;
	public static float distanceAbove;
	public static float distanceBelow;
	public static float zUpperLimit;
	public static float zLowerLimit;

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
}
