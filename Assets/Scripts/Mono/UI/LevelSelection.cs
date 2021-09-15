using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FG 
{
	public class LevelSelection : MonoBehaviour
	{
		[SerializeField] private string levelUnlockToCheck;

		private Image _image;
		private Button _button;

		private void Awake()
		{
			_button = GetComponent<Button>();
			_image = GetComponent<Image>();
			
			if (GameManager.Instance.unlockLevel[levelUnlockToCheck] == false)
			{
				_button.interactable = false;
				_image.color = new Color(255f, 255f, 255f, 0.15f);
			}
			else
			{
				_button.interactable = true;
				_image.color = new Color(255, 255, 255, 225);
			}
		}

		//Unlocks corresponding level selection button based on if the level is unlocked or not.
		private void Start()
		{

		}
	}
}
