using System;
using UnityEngine;

namespace FG 
{
	public class LevelManager : MonoBehaviour
	{
		public int PickupsToWin;
		private void Start()
		{
			//Objects needed to pickup before clearing level.
			PickupsToWin = GameObject.FindGameObjectsWithTag("Pickup").Length;
		}
	}
}
