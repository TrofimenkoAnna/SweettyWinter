using System;
using UnityEngine;

//namespace Assets.Scripts
//{
	[RequireComponent(typeof (CharacterController))]
	public class FPS : MonoBehaviour {

		private MouseLook m_MouseLook = new MouseLook();
		private Camera m_Camera;
		private CharacterController m_CharacterController; 
		public float speed = 16.0F;
    	public float jumpSpeed = 1.0F;
    	public float gravity = 20.0F;
    	private Vector3 moveDirection = Vector3.zero;

		// Use this for initialization
		void Start () {

        	m_Camera = Camera.main; 
			m_MouseLook.Init(transform, m_Camera.transform);
		}
	
		// Update is called once per frame
		void Update () {
			RotateView();

			CharacterController controller = GetComponent<CharacterController>();
				if (controller.isGrounded)
				{
            		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            		moveDirection = transform.TransformDirection(moveDirection);
            		moveDirection *= speed;
					moveDirection = Vector3.ClampMagnitude(moveDirection, speed);

            		if (Input.GetButton("Jump"))
					{
						moveDirection.y = jumpSpeed * 1.5F;
					}
                		
				}
					moveDirection.y -= gravity * Time.deltaTime;
       	 			controller.Move(moveDirection * Time.deltaTime);
		}

		private void RotateView()
        {
            m_MouseLook.LookRotation (transform, m_Camera.transform);
        }

	}
//}