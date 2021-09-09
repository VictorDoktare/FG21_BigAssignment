using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	public class UIManager : MonoBehaviour
	{
		private static UIManager _uiManager = null;

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
	}
}
