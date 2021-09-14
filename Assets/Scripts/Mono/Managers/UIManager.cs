using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	//Singleton pattern.
	public class UIManager : MonoBehaviour
	{
		private static UIManager instance; 
		public static UIManager Instance => instance;
		
		//public static event Action OnPlayerPickup;
		
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

	}
}
