using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace FG 
{
	//Singleton pattern.
	public class UIManager : MonoBehaviour
	{
		private static UIManager instance; 
		public static UIManager Instance => instance;

		private bool gameIsPaused = false;

		public bool GameIsPaused => gameIsPaused;
		
		private void Awake()
		{
			CheckForInstance();
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

		//Level to load based on name.
		public void LoadLevel(string levelName)
		{
			SceneManager.LoadScene(levelName, LoadSceneMode.Single);
		}

		//Update UI HUD containing the amount of pickups collected.
		public void UpdatePickupHud(int value)
		{
			GameObject.Find("Text_Pickup").GetComponent<TextMeshProUGUI>().text = value.ToString();
		}

		public void LoadPauseMenu()
		{
			var pauseMenu = GameObject.Find("Canvas_PauseMenu");
			
			if (!gameIsPaused)
			{
				gameIsPaused = !gameIsPaused;
				pauseMenu.GetComponent<Canvas>().enabled = true;
				
				//Sets button to be the selected button when opening the UI. This is needed since im enabling/disabling the object.
				SetEventSystemSelected("Button_Continue");
				
				GameManager.Instance.StopTime();
				
				Debug.Log("Paused:" + gameIsPaused);
		
			}
			else
			{
				GameManager.Instance.StartTime();
				gameIsPaused = !gameIsPaused;
				pauseMenu.GetComponent<Canvas>().enabled = false;
				
				Debug.Log("Unpaused:" + gameIsPaused);
			}
		}

		//Sets what button that is pre-selected when UI appears.
		public void SetEventSystemSelected(string buttonName)
		{
			var button = GameObject.Find(buttonName);
			var eventSystem = EventSystem.current;
			var baseEvent = new BaseEventData(eventSystem);
			
			eventSystem.SetSelectedGameObject(button, baseEvent);
		}
	}
}
