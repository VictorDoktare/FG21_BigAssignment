using System;
using System.Collections;
using UnityEngine;

namespace FG 
{
	public class PlayerController : MonoBehaviour
	{
		[Range(1, 10)][SerializeField] private float rollSpeed = 1f;

		private GameObject _objRaycaster;
		private RaycastHit _raycastHit;
		
		private bool _isMoving;
		private int _layerMask = 0;

		#region Unity Event Functions

		private void Awake()
		{
			_objRaycaster = transform.Find("Raycaster").gameObject;
		}

		private void Start()
		{
			//Invert layers to check all except itself
			_layerMask = ~_layerMask;
		}

		private void Update()
		{
			InputDirection();
			
			//Locking the "Raycaster" child object makes checking directions easier
			_objRaycaster.transform.rotation = Quaternion.Euler(0f,0f,0f);
		}

		private void FixedUpdate()
		{
			CollisionChecks();
		}

		#endregion
		
		//Directional Input
		void InputDirection()
		{
			//Makes sure movement is complete before checking for new input
			if (_isMoving) return;
			
			//Input Direction X-Axis
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
			{
				RollDirection(-0.5f, Vector3.left);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				RollDirection(0.5f, Vector3.right);
			}
			//Input Direction X-Axis
			else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
			{
				RollDirection(0.5f, Vector3.forward);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
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
			_isMoving = true;

			for (int i = 0; i < 90 / rollSpeed; i++)
			{
				transform.RotateAround(anchor, axis, rollSpeed);
				yield return new WaitForSeconds(0.01f);
				
			}
			
			//Correcting the position and rotation of the cube to make sure there no decimal offsets after each move since those can add up.
			transform.position = new Vector3((float)Math.Round((decimal)transform.position.x , 2), 0f,  (float)Math.Round((decimal)transform.position.z , 2));
			transform.eulerAngles = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y), Mathf.Round(transform.eulerAngles.z));

			//Ground check so i can make player fall if there is no tiles to stand on
			if (_raycastHit.collider == null)
			{
				GetComponent<Rigidbody>().isKinematic = false;
				yield break;;
			}

			_isMoving = false;
		}

		//Using raycasts for collision checks since i need the player to be kinematic to avoid offset problems
		void CollisionChecks()
		{
			if (Physics.Raycast(_objRaycaster.transform.position,
				_objRaycaster.transform.TransformDirection(Vector3.down),
				out _raycastHit, 0.6f, _layerMask));
			{
				Debug.DrawRay(_objRaycaster.transform.position, _objRaycaster.transform.TransformDirection(Vector3.down) * _raycastHit.distance, Color.magenta);
			}
		}
	}
}
