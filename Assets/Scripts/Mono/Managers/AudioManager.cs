using System;
using UnityEngine;

namespace FG 
{
	public class AudioManager : MonoBehaviour
	{
		private static AudioManager instance;
		public static AudioManager Instance => instance;
		private void Awake()
		{
			CheckForInstance();
		}
		
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
	}
}
