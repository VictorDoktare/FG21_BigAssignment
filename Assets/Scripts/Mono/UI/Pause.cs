using System;
using UnityEngine;

namespace FG 
{
	public class Pause : MonoBehaviour
	{
		private bool gameIsPaused = false;

		public bool GameIsPaused => gameIsPaused;
		private void Update()
		{
			PauseGame();
		}

		private void PauseGame()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				LoadPauseMenu();
			}
		}
		
		public void LoadPauseMenu()
		{
			var pauseMenu = GameObject.Find("Canvas_PauseMenu");
			
			if (!gameIsPaused)
			{
				gameIsPaused = !gameIsPaused;
				pauseMenu.GetComponent<Canvas>().enabled = true;
				
				//Sets button to be the selected button when opening the UI. This is needed since im enabling/disabling the object.
				UIManager.Instance.SetEventSystemSelected("Button_Continue");
				
				StopTime();
			}
			else
			{
				StartTime();
				gameIsPaused = !gameIsPaused;
				pauseMenu.GetComponent<Canvas>().enabled = false;
			}
		}
		
		public void StartTime() => Time.timeScale = 1;
		public void StopTime() => Time.timeScale = 0;
	}
}
