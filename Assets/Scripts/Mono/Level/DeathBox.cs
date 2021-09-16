using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	public class DeathBox : MonoBehaviour 
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				GameManager.Instance.ResetCurrentLevelData();
				var sceneToLoad = SceneManager.GetActiveScene();
				SceneManager.LoadScene(sceneToLoad.name);
			}
		}
	}
}
