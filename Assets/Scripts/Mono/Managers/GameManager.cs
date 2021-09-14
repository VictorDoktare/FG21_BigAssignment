using System;
using System.Collections.Generic;
using UnityEngine;

namespace FG 
{
	//Singleton pattern.
	public class GameManager : MonoBehaviour
	{
		private static GameManager instance;
		public static GameManager Instance => instance;

		private bool levelCleared = false;
		private int pickupCount;

		public bool LevelCleared => levelCleared;

		public Dictionary<string, bool> unlockLevel = new Dictionary<string, bool>();
		
		private void Awake()
		{
			CheckForInstance();
			SetLevelDictionary();
		}
		
		//Singleton setup.
		private void CheckForInstance()
		{
			if (instance == null)
			{
				
				instance = this;
				DontDestroyOnLoad(gameObject);
				
			}
			else
			{
				Destroy(gameObject);
			}
		}
		
		//Setup dictionary of levels.
		private void SetLevelDictionary()
		{
			for (int i = 1; i < 10; i++)
			{
				if (i == 1)
				{
					unlockLevel.Add($"level0{i}", true);
				}
				else
				{
					unlockLevel.Add($"level0{i}", false);
				}
			}
		}

		//Unlocking levels for the level select.
		public void LevelUnlock(string levelName)
		{
			unlockLevel[key: levelName] = true;
		}

		//Adds to the pickupCount and pass it to the UI.
		public void AddPickup()
		{
			pickupCount++;
			UIManager.Instance.UpdatePickupHud(pickupCount);
		}

		public void CheckForLevelClear()
		{
			if (pickupCount == GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().PickupsToWin)
			{
				levelCleared = true;
			}
		}

		public void ResetCurrentLevelData()
		{
			levelCleared = false;
			pickupCount = 0;
		}
	}
}
