using System;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Pickup : MonoBehaviour
	{
		[SerializeField] private UnityEvent _triggerPickupEvent = new UnityEvent();
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				_triggerPickupEvent.Invoke();
				Destroy(gameObject);
			}
		}
	}
	
}
