using System;
using System.Collections;
using UnityEngine;

namespace FG 
{
	public class PlayerController : MonoBehaviour
	{
		[Range(1, 10)][SerializeField] private float rollSpeed = 1f;
		
		private bool isMoving;

		private void Update()
		{
			if (isMoving) return;

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				var pivotAnchor = transform.position + new Vector3(-0.5f, -0.5f, 0f);
				var pivotAxis = Vector3.Cross(Vector3.up, Vector3.left);
				StartCoroutine(RollPlayer(pivotAnchor, pivotAxis));
			}
		}

		void RollDirection(float direction)
		{
			
		}

		IEnumerator RollPlayer(Vector3 anchor, Vector3 axis)
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
