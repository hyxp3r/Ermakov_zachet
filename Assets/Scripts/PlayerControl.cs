using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	
	[SerializeField] private CharacterController controller;
	[SerializeField] private float playerSpeed;
	[SerializeField] private float spawnSpeed = 5.0f;
	[SerializeField] private float gravity = -9.81f;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float groundDistance = 0.4f;
	[SerializeField] private LayerMask groundMask;
	[SerializeField] private float jampHeight = 3f;
	
	private Vector3 velocity;
	
	private bool isGrounded;
	
	void Start()
	{
		playerSpeed = spawnSpeed;
		Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
		if (isGrounded && velocity.y<0)
		{
			velocity.y = -2f;
		}
		
		float x = Input.GetAxis("Horizontal");
		float z= Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x+ transform.forward *z;
		controller.Move(move*playerSpeed*Time.deltaTime);
		
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jampHeight * -2f * gravity);
			
		}
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		
		
		
		
		if (Input.GetKey(KeyCode.LeftShift))
			playerSpeed = 10.0f;
		else 
			playerSpeed = spawnSpeed;
		
		
	
		
    }
}
