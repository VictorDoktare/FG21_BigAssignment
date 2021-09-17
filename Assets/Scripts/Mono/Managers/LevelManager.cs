using System;
using UnityEngine;

namespace FG 
{
	public class LevelManager : MonoBehaviour
	{
	
		[HideInInspector] public float PickupsToWin;
		
		private void Start()
		{
			//Objects needed to pickup before clearing level.
			PickupsToWin = GameObject.FindGameObjectsWithTag("Pickup").Length;
		}
	}
}
