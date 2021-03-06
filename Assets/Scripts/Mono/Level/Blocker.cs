using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace FG 
{
	public class Blocker : MonoBehaviour
	{
		[SerializeField] private GameObject playerDeathParticle;
		[SerializeField] private GameObject spikes;
		[SerializeField] private AudioClip[] blockerAudio;

		private AudioSource _audioSource;
		
		private bool isActivated;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.tag == "Player")
			{
				isActivated = true;
				PlaySoundFX(blockerAudio[1], 0.1f);
				spikes.transform.localPosition = new Vector3(0, 0, 0);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (isActivated)
			{
				StartCoroutine(PlayerDeath(other));
			}
			else
			{
				PlaySoundFX(blockerAudio[0], 1);
			}
		}

		private IEnumerator PlayerDeath(Collider player)
		{
			var spawnPos = new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z);
			yield return new WaitForSeconds(0.15f);
			Destroy(player.gameObject);
			Instantiate(playerDeathParticle, spawnPos, quaternion.identity);
			yield return new WaitForSeconds(2);
			GameManager.Instance.ResetCurrentLevelData();
		}

		private void PlaySoundFX(AudioClip audioclip, float volume)
		{
			_audioSource.clip = audioclip;
			_audioSource.volume = volume;
			_audioSource.Play();
		}
	}
}
