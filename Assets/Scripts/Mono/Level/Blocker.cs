using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG 
{
	public class Blocker : MonoBehaviour
	{
		[SerializeField] private GameObject playerDeathParticle;
		private bool isActivated;
		private void OnTriggerExit(Collider other)
		{
			if (other.tag == "Player")
			{
				isActivated = true;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (isActivated)
			{
				var spawnPos = new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z);
				Destroy(other.gameObject);
				Instantiate(playerDeathParticle, spawnPos, quaternion.identity);
				StartCoroutine(PlayerDeath());
			}
		}

		private IEnumerator PlayerDeath()
		{
			yield return new WaitForSeconds(2);
			GameManager.Instance.ResetCurrentLevelData();
			var sceneToLoad = SceneManager.GetActiveScene();
			SceneManager.LoadScene(sceneToLoad.name);
		}
	}
}
