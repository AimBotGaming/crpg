using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraOrigin
{
	public float x = 0.0f, y = 11.0f, z = -6.0f;
	public float rx = 60, ry = 0, rz = 0;
}

[System.Serializable]
public class CameraZoom
{
	public float zoomMin = 25.0f, zoomMax = 50.0f, zoomSpeed  = 125.0f;
}

public class ThirsPersonCamera : MonoBehaviour
{
	public Transform target;
	public CameraOrigin camOrigin;
	public CameraZoom camZoom;

	public float moveSmoothines = 10.0f;
	public float rotateSmoothines = 10.0f;
	public float zoomSmoothines = 10.0f;

	void FixedUpdate()
	{
		Transform current = this.transform;
		float curZoom = Camera.main.fieldOfView;
		float scroll = Input.GetAxis("Scroll");

		Vector3 camPos = new Vector3
		(
			target.position.x + camOrigin.x,
			target.position.y + camOrigin.y,
			target.position.z + camOrigin.z
		);

		Quaternion camRot = Quaternion.Euler 
		(
			camOrigin.rx,
			camOrigin.ry,
			camOrigin.rz
		);

		float newZoom = Mathf.Clamp(curZoom + scroll * camZoom.zoomSpeed, camZoom.zoomMin, camZoom.zoomMax);


		this.transform.position = Vector3.Lerp (current.position, camPos, Time.deltaTime * moveSmoothines);
		this.transform.rotation = Quaternion.Lerp (current.rotation, camRot, Time.deltaTime * rotateSmoothines);
		Camera.main.fieldOfView = Mathf.Lerp (curZoom, newZoom, Time.deltaTime * zoomSmoothines);
	}

}
