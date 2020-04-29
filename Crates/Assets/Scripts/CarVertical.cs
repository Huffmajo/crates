using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarVertical : MonoBehaviour
{
	public static bool selected;
	public static float distanceAbove;
	public static float distanceBelow;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
        	distanceAbove = DistanceToObject(Vector3.forward);
        	distanceBelow = DistanceToObject(Vector3.back);
        }
    }

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
}
