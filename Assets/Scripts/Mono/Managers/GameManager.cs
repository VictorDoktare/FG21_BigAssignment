using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	//Singleton pattern.
	public class GameManager : MonoBehaviour
	{
		private static GameManager instance;
		public static GameManager Instance => instance;

		private bool levelCleared = false;
		private int pickupCount;
		private bool playerCanMove;

		//public bool PlayerCanMove { get => playerCanMove; set => playerCanMove = value; }
		public bool LevelCleared => levelCleared;

		public Dictionary<string, bool> unlockLevel = new Dictionary<string, bool>();
		
		private void Awake()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
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

		//Reset Data before re-loading the scene
		public void ResetCurrentLevelData()
		{
			UIManager.Instance.WinAmount = 0;
			
			if (UIManager.Instance.FillerBar != null)
			{
				UIManager.Instance.FillerBar.fillAmount = 0;
			}
			levelCleared = false;
			pickupCount = 0;
			var sceneToLoad = SceneManager.GetActiveScene();
			SceneManager.LoadScene(sceneToLoad.name);
		}

		public void ExitGame()
		{
			Application.Quit();
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
}
