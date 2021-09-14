using System;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Pickup : MonoBehaviour
	{
		public static event Action OnPlayerPickup;
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				GameManager.Instance.AddPickup();
				Destroy(gameObject);
			}
		}
	}
	
}
