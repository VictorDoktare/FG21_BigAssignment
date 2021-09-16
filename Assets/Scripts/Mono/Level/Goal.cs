using System;
using System.Collections;
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
				StartCoroutine(LoadNextLevel());
			}
		}

		private IEnumerator LoadNextLevel()
		{
			yield return new WaitForSeconds(0.15f);
			GameManager.Instance.ResetCurrentLevelData();
			GameManager.Instance.LevelUnlock(unlockLevel);
			UIManager.Instance.LoadLevel(nextLevel);
		}
	}
}
