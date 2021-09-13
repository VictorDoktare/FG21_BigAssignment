using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	public class UIManager : MonoBehaviour
	{
		private UIManager _uiManager = null;
		private int pickupScore = 0;
		
		#region Unity Event Functions
		private void Awake()
		{
			if (_uiManager != null)
			{
				Destroy(gameObject);
			}
			else
			{
				_uiManager = this;
				DontDestroyOnLoad(gameObject);
			}

			pickupScore = 0;
		}

		private void Start()
		{
			pickupScore = 0;
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
		}
	}
}
