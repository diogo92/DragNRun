using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//Forces aspect ratio to 16:9 on all devices.
public class CameraAspectRatio : MonoBehaviour {
	public float AspectWidth = 9.0f;
	public float AspectHeight = 16.0f;
	void Start () {
		Screen.SetResolution (Screen.width, Screen.height, true);
		float targetaspect = AspectWidth / AspectHeight;
		float windowaspect = (float)Screen.width / (float)Screen.height;
		float scaleheight = windowaspect / targetaspect;
		if (scaleheight < 1.0f)
		{  
			Rect rect = GetComponent<Camera>().rect;
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			GetComponent<Camera>().rect = rect;
		}
		else
		{
			float scalewidth = 1.0f / scaleheight;
			Rect rect = GetComponent<Camera>().rect;
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			GetComponent<Camera>().rect = rect;
		}

	/*	CanvasScaler cs = FindObjectOfType<CanvasScaler> ();
		float MultFactor = cs.referenceResolution.y / ((windowaspect * cs.referenceResolution.y) / targetaspect); 
		cs.referenceResolution = new Vector2 (cs.referenceResolution.x*MultFactor, cs.referenceResolution.y*MultFactor);*/


	}

}
