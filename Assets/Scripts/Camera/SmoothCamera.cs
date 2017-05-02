using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour
{
    public Transform lookAt;

    public bool smooth = true;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(-5f, 1f, 0);

	public Transform WaterPlane;
	public Transform SkyLimit;

	void Start(){
	}
    private void LateUpdate()
    {

        Vector3 desiredPosition = lookAt.transform.position + offset;

        if(smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            transform.position = desiredPosition;
        }
		if (WaterPlane != null) {
			WaterPlane.position = new Vector3 (-22, -10, transform.position.z);
			WaterPlane.gameObject.GetComponent<MeshRenderer> ().material.mainTextureOffset += new Vector2 (0.1f*Time.deltaTime, 0.13f*Time.deltaTime);
		}
		if (SkyLimit != null) {
			SkyLimit.position = new Vector3 (-22, 10, transform.position.z);
		}
    }
}