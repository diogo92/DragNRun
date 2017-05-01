using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrag : MonoBehaviour {
	private Vector3 screenPoint; 
	private Vector3 offset;
    private Transform playerPos;

	private LevelMaster lm;


	//Platfrom specific drag speed modifier
	public float DragSpeedModifier = 1f;

	bool IsTouching = false;
    private void Start()
    {
		
		lm = FindObjectOfType<LevelMaster> ();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


	void Update () {
		//First check count of touch

		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began && lm.CurrentPlatform == null) {
					screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position); // I removed this line to prevent centring 
					RaycastHit hit;
					if (Physics.Raycast (Camera.main.ScreenToWorldPoint (new Vector3(touch.position.x,touch.position.y,10f)), transform.position-Camera.main.transform.position, out hit)) {
						if (hit.collider.gameObject == gameObject || hit.collider.gameObject.transform.IsChildOf(transform)) {
							IsTouching = true;
							offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (screenPoint.x, touch.position.y, screenPoint.z));
						//	Debug.DrawRay(Camera.main.ScreenToWorldPoint (new Vector3(touch.position.x,touch.position.y,10f)), transform.position-Camera.main.transform.position, Color.red, 100, true);
							lm.CurrentPlatform = gameObject;
						}
					}
				} else if (touch.phase == TouchPhase.Moved && lm.CurrentPlatform == gameObject) {
					if (!PlayerOnThisPlatform () && IsTouching) {
						Vector3 curScreenPoint = new Vector3 (screenPoint.x, touch.position.y, screenPoint.z);
						Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
						transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, Mathf.Clamp (curPosition.y, -10, 10), transform.position.z), Time.deltaTime * lm.PlatformDragSpeed * DragSpeedModifier);
					}
				} else if (touch.phase == TouchPhase.Ended) {
					IsTouching = false;
					lm.CurrentPlatform = null;
				}
			}
		}
	}



	/*
	 * 	Check if player is on platform
	 */

	bool PlayerOnThisPlatform()
	{
		float boundExtent = GetComponent<BoxCollider>().bounds.extents.z;
		float boundCenter = GetComponent<BoxCollider>().bounds.center.z-0.5f;
		return playerPos.position.z > (boundCenter - boundExtent) && playerPos.position.z < (boundCenter + boundExtent);
	}

	#if UNITY_EDITOR
   void OnMouseDown() {
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // I removed this line to prevent centring 
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
	}


	void OnMouseDrag() 
	{
       if (!PlayerOnThisPlatform())
        {
            Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp(curPosition.y,-10,10), transform.position.z), Time.deltaTime * lm.PlatformDragSpeed * DragSpeedModifier);
        }
	}
	#endif

}
