using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FG 
{
	public class LevelSelection : MonoBehaviour
	{
		[SerializeField] private string levelUnlockToCheck;

		//Unlocks corresponding level selection button based on if the level is unlocked or not.
		private void Start()
		{
			if (GameManager.Instance.unlockLevel[levelUnlockToCheck] == false)
			{
				GetComponent<Button>().interactable = false;
				GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.15f);
			}
			else
			{
				GetComponent<Button>().interactable = true;
				GetComponent<Image>().color = new Color(255, 255, 255, 225);
			}
		}
	}
}
