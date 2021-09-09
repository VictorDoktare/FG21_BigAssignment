using System;
using UnityEngine;

namespace FG 
{
	public class Pickup : MonoBehaviour 
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				Destroy(gameObject);
			}
		}
	}
}
