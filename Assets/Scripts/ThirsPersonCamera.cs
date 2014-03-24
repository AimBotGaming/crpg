using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraOrigin
{
	public float x = 0.0f, y = 10.0f, z = -6.0f;
}

[System.Serializable]
public class CameraZoom
{
	public float zoom = 35.0f, zoomMin = 25.0f, zoomMax = 50.0f;
}

public class ThirsPersonCamera : MonoBehaviour
{
	public Transform target;
	public CameraOrigin camOrigin;
	public CameraZoom camZoom;

	public float moveSmoothines = 10.0f;

	void FixedUpdate()
	{
		Transform current = this.transform;

		Vector3 camPos = new Vector3
		(
			target.position.x + camOrigin.x,
			target.position.y + camOrigin.y,
			target.position.z + camOrigin.z
		);

		this.transform.position = Vector3.Lerp (current.position, camPos, Time.deltaTime * moveSmoothines);
	}

}
