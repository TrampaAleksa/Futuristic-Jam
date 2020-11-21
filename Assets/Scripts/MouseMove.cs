using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{
	[SerializeField]
	float rotationSpeed = 0.4f;
	float move;
	[SerializeField]
	float maxDownLook = 0.15f;
	[SerializeField]
	float maxUpperLook = 0.15f;
	float x;
	bool canGoDown = true;
	bool canGoUp = true;
	private void Start()
	{
		x = Camera.main.transform.localRotation.x;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	private void Update()
	{
		move = Input.GetAxis("Mouse Y");
		//print(Camera.main.transform.localRotation.x);
		if (move != 0)
		{
			if (x - Camera.main.transform.localRotation.x <= maxUpperLook)
			{
				canGoUp = true;
			}
			else canGoUp = false; 
			if (Camera.main.transform.localRotation.x <= x + maxDownLook)
			{
				canGoDown = true;
			}
			else canGoDown = false;
			if (canGoUp && move > 0)
			{

				Camera.main.transform.Rotate(-rotationSpeed, 0, 0);
			}
			if (canGoDown && move < 0)
				Camera.main.transform.Rotate(rotationSpeed, 0, 0);
		}
		if (Input.GetButtonDown("Cancel"))
		{
			LockCursor(false);
		}

		// if the player fires, then relock the cursor
		if (Input.GetButtonDown("Fire1"))
		{
			LockCursor(true);
		}
	}
	private void LockCursor(bool isLocked)
	{
		if (isLocked)
		{
			// make the mouse pointer invisible
			Cursor.visible = false;

			// lock the mouse pointer within the game area
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			// make the mouse pointer visible
			Cursor.visible = true;

			// unlock the mouse pointer so player can click on other windows
			Cursor.lockState = CursorLockMode.None;
		}
	}
}