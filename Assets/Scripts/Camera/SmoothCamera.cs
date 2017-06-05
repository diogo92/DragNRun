using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour
{
	public static SmoothCamera Instance { set; get; }
    public Transform lookAt;

	public bool minimapCam = false;

    public bool smooth = true;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(-5f, 1f, 0);

	public Transform LimitsTransform;


	void Awake(){
		Debug.Log (tag);
		if (tag=="MainCamera")
			Instance = this;
	}
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
		if(!minimapCam)
			transform.position = new Vector3 (transform.position.x, Mathf.Clamp (transform.position.y, -5, 20), transform.position.z);

		if (LimitsTransform != null) {
			LimitsTransform.position = new Vector3 (-22, -10, transform.position.z);
			LimitsTransform.gameObject.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset += new Vector2 (0.1f*Time.deltaTime, 0.13f*Time.deltaTime);
		}
    }
}