using System;
using UnityEngine;

namespace FG 
{
	public class Pause : MonoBehaviour
	{
		private bool isPaused = false;
		private void Update()
		{
			PauseGame();
		}

		private void PauseGame()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				UIManager.Instance.LoadPauseMenu();
			}
		}
	}
}
