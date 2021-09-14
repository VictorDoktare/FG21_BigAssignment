using System;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Goal : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			//Resets GameManager data and Unlocks a new level before scene change.
			if (GameManager.Instance.LevelCleared == true)
			{
				GameManager.Instance.ResetCurrentLevelData();
				GameManager.Instance.LevelUnlock("level02");
				UIManager.Instance.LoadLevel("02.Level");
			}
		}
	}
}
