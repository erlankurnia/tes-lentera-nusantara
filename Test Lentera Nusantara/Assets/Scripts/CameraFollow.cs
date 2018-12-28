using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float followSpeed = 8f;
	public Vector3 offset;

	private void FixedUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		transform.position = smoothPosition;
		//if(transform.position.y < 5f)
		//{
		//	transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
		//}
	}
}
