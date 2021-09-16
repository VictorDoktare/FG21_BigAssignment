using System;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Goal : MonoBehaviour
	{
		[SerializeField] private string nextLevel;
		[SerializeField] private string unlockLevel;
		private void OnTriggerEnter(Collider other)
		{
			//Resets GameManager data and Unlocks a new level before scene change.
			if (GameManager.Instance.LevelCleared == true)
			{
				GameManager.Instance.ResetCurrentLevelData();
				GameManager.Instance.LevelUnlock(unlockLevel);
				UIManager.Instance.LoadLevel(nextLevel);
			}
		}
	}
}
