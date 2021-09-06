using System;
using System.Collections;
using UnityEngine;

namespace FG 
{
	public class PlayerController : MonoBehaviour
	{
		[Range(1, 10)][SerializeField] private float rollSpeed = 1f;
		
		private bool isMoving;

		#region Unity Event Functions

		private void Update()
		{
			InputDirection();
		}

		#endregion
		
		//Directional Input
		void InputDirection()
		{
			//Makes sure movement is complete before checking for new input
			if (isMoving) return;
			
			//Input Direction X-Axis
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				RollDirection(-0.5f, Vector3.left);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				RollDirection(0.5f, Vector3.right);
			}
			
			//Input Direction Z-Axis
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				RollDirection(0.5f, Vector3.forward);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				RollDirection(-0.5f, Vector3.back);
			}
		}

		//Set the pivot and axis which the cube is rotating from
		void RollDirection(float direction, Vector3 vector)
		{
			var pivotAnchor = transform.position + new Vector3(direction, -0.5f, direction);
			var pivotAxis = Vector3.Cross(Vector3.up, vector);
			
			StartCoroutine(RollCube(pivotAnchor, pivotAxis));
		}

		//Rotate cube and correct eventual offsets
		IEnumerator RollCube(Vector3 anchor, Vector3 axis)
		{
			isMoving = true;

			for (int i = 0; i < 90 / rollSpeed; i++)
			{
				transform.RotateAround(anchor, axis, rollSpeed);
				yield return new WaitForSeconds(0.01f);
				
			}
			
			//Correcting the position and rotation of the cube to make sure there no decimal offsets after each move since those can add up.
			transform.position = new Vector3((float)Math.Round((decimal)transform.position.x , 2), 0f,  (float)Math.Round((decimal)transform.position.z , 2));
			transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));

			isMoving = false;
		}

	}
}
