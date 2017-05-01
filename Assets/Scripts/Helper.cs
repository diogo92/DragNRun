using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {
	public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag)where T:Component{
		Transform t = parent.transform;
		foreach(Transform tr in t)
		{
			if(tr.tag == tag)
			{
				return tr.GetComponent<T>();
			}
		}
		return null;
	}

	public static bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
	{
		bool equal = true;

		if (Mathf.Abs (v1.x - v2.x) > precision) equal = false;
		if (Mathf.Abs (v1.y - v2.y) > precision) equal = false;
		if (Mathf.Abs (v1.z - v2.z) > precision) equal = false;

		return equal;
	}

	public static Vector3 RandomPointInsideCollider(Collider col){
		Vector3 result = Vector3.zero;

		float centerX = col.bounds.center.x;
		float centerY = col.bounds.center.y;
		float centerZ = col.bounds.center.z;

		float maxX = centerX + col.bounds.extents.x;
		float minX = centerX -col.bounds.extents.x;

		float maxY = centerY + col.bounds.extents.y;
		float minY = centerY -col.bounds.extents.y;

		float maxZ = centerZ + col.bounds.extents.z;
		float minZ = centerZ -col.bounds.extents.z;

		result.x = Random.Range (minX, maxX);
		result.y = Random.Range (minY, maxY);
		result.z = Random.Range (minZ, maxZ);

		return result;
	}

	public static Vector3 RandomPointForObstacles(Collider col){
		Vector3 result = Vector3.zero;

		float centerY = col.bounds.center.y;
		float centerZ = col.bounds.center.z;

		float maxY = centerY + col.bounds.size.y/2;
		float minY = centerY -col.bounds.size.y/2;

		float maxZ = centerZ + col.bounds.size.z/2;
		float minZ = centerZ -col.bounds.size.z/2;

		result.x = 0;
		result.y = Random.Range (minY, maxY);
		result.z = Random.Range (minZ, maxZ);
		while (!col.bounds.Contains (result)) {
			result.y = Random.Range (minY, maxY);
		}
		return result;
	}


}