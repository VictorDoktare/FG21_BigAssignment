using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Pickup : MonoBehaviour
	{
		//public static event Action OnPlayerPickup;
		[SerializeField] private GameObject pickupVFX;

		private void Update()
		{
			transform.Rotate(0, 45 * Time.deltaTime, 0);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				GameManager.Instance.AddPickup();
				GameManager.Instance.CheckForLevelClear();
				Instantiate(pickupVFX, transform.position, quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
	
}
