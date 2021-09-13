using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	public class UIManager : MonoBehaviour
	{
		private int pickupScore = 0;
		private int _scoreToWin;
		[HideInInspector]
		public bool canWin = false;

		#region Unity Event Functions
		private void Awake()
		{
			//Amount of pickups to get before u can complete the level
			//doing it like this i dont have to bother changing any values while designing level.
			_scoreToWin = GameObject.FindGameObjectsWithTag("Pickup").Length;
		}

		private void Start()
		{
			canWin = false;
		}

		#endregion

		public void LoadSceneSingle(string sceneName)
		{
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
		
		public void ExitGame()
		{
			Application.Quit();
			EditorApplication.ExitPlaymode();
		}
		
		public void UpdateScore()
		{
			var scoreText = GameObject.Find("Text_Pickup").GetComponent<TextMeshProUGUI>();
			pickupScore++;
			scoreText.text = pickupScore.ToString();
			
			if (pickupScore >= _scoreToWin)
			{
				canWin = true;
			}
		}
	}
}
