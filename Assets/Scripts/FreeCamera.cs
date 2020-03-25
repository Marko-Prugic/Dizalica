using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class FreeCamera : MonoBehaviour
{
	#region Variables
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -90F;
	public float maximumY = 90F;

	public float smoothSpeed = 20F;
	public float movementSpeed = 10F;

	private float rotationX = 0F;
	private float rotationY = 0F;

	private float smoothRotationX = 0F;
	private float smoothRotationY = 0F;
	#endregion

	private void Start()
	{
		
	}

	private void Update()
	{

		if (Input.GetMouseButton(1))
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		}

		// smooth mouse look
		smoothRotationX += (rotationX - smoothRotationX) * smoothSpeed * Time.smoothDeltaTime;
		smoothRotationY += (rotationY - smoothRotationY) * smoothSpeed * Time.smoothDeltaTime;

		// transform camera to new direction
		transform.localEulerAngles = new Vector3(-smoothRotationY, smoothRotationX, 0);

		// handle camera movement via controller
		Vector3 inputMag = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 inputMoveDirection = transform.rotation * inputMag;
		transform.position += inputMoveDirection * movementSpeed * Time.smoothDeltaTime;

		transform.position += (transform.rotation * Vector3.forward) * Input.GetAxis("Mouse ScrollWheel") * 200.0f;
	}
}
