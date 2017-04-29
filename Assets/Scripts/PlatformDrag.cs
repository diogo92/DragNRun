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
				if (touch.phase == TouchPhase.Began) {
					screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position); // I removed this line to prevent centring 
					RaycastHit hit;
					if (Physics.Raycast (Camera.main.ScreenToWorldPoint (touch.position), Camera.main.transform.forward, out hit)) {
						if (hit.collider.gameObject == gameObject) {
							IsTouching = true;
							offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (screenPoint.x, Input.mousePosition.y, screenPoint.z));
						}
					}
				} else if (touch.phase == TouchPhase.Moved) {
					if (!PlayerOnThisPlatform () && IsTouching) {
						Vector3 curScreenPoint = new Vector3 (screenPoint.x, touch.position.y, screenPoint.z);
						Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
						transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, Mathf.Clamp (curPosition.y, -10, 10), transform.position.z), Time.deltaTime * lm.PlatformDragSpeed * DragSpeedModifier);
					}
				} else if (touch.phase == TouchPhase.Ended) {
					IsTouching = false;
				}
			}
		}
	}


    void OnMouseDown() {
	//	screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // I removed this line to prevent centring 
	//	offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
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

	void OnMouseDrag() 
	{
      /*  if (!PlayerOnThisPlatform())
        {
            Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Clamp(curPosition.y,-10,10), transform.position.z), Time.deltaTime * lm.PlatformDragSpeed * DragSpeedModifier);
        }*/
	}

}
