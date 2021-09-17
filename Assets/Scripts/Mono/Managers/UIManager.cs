using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace FG 
{
	//Singleton pattern.
	public class UIManager : MonoBehaviour
	{
		private static UIManager instance; 
		public static UIManager Instance => instance;

		private float winAmount;
		private Image fillerBar;

		public float WinAmount { get => winAmount; set => winAmount = value; }

		public Image FillerBar
		{ get => fillerBar; set => fillerBar = value; }

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
			WinAmount = GameObject.Find("LevelManager").GetComponent<LevelManager>().PickupsToWin;
			FillerBar = GameObject.Find("PickupFiller").GetComponent<Image>();
			var fillPercent = 1 / winAmount;

			fillerBar.fillAmount += fillPercent;
			Debug.Log(fillerBar.fillAmount);

			//GameObject.Find("Text_Pickup").GetComponent<TextMeshProUGUI>().text = value.ToString();
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
