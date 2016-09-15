using System;
using UnityEngine;

	[Serializable]
	public class MouseLook {

		public float XSensitivity = 2f; 
    	public float YSensitivity = 2f;

		private Quaternion m_CharacterTargetRot;
		private Quaternion m_CameraTargetRot;

		public bool clampVerticalRotation = true; // зажать вращение по вертикали
        public float MinimumX = -90F;
        public float MaximumX = 90F;

        public bool lockCursor = true; 
        private bool m_cursorIsLocked = true;

	 	public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation; // вращение цели
            m_CameraTargetRot = camera.localRotation;		// вращение камеры
        }

		public void LookRotation(Transform character, Transform camera)
		{
			float yRot = Input.GetAxis("Mouse X") * XSensitivity;
			float xRot = Input.GetAxis("Mouse Y")* YSensitivity;

			m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f); // повернуть цель на yRot
			m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);   // повернуть камеру

			if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            character.localRotation = m_CharacterTargetRot; // простое вращение
            camera.localRotation = m_CameraTargetRot;   
            
            UpdateCursorLock();    
		}

		Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        } 

        // заблокировать курсор
        public void SetCursorLock(bool value) 
        {
            lockCursor = value; // блокировать?
            if(!lockCursor) // если нет
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None; // вернуть курсор
                Cursor.visible = true;
            }
        }

         // обновить блокировку курсора
        public void UpdateCursorLock() 
        {
            if (lockCursor)
                InternalLockUpdate();
        }

         // обновление блокировки
        private void InternalLockUpdate() 
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
	}
