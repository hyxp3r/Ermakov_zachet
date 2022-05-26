using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f; // чувствительность вращения
	[SerializeField] private Transform playerBody; // координаты тела игрока
	
	private float xRotation;
	
	private void Update()
	{
		// считывание значений по 2 координатам
		float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ограничения
		
		transform.localRotation = Quaternion.Euler(xRotation,0f,0f); // вращение по оси Y
		playerBody.Rotate(Vector3.up * mouseX); // вращение камеры вместе с телом игрока по оси X
	}
}
