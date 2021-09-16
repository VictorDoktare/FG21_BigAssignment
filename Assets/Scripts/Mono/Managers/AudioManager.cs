using System;
using UnityEngine;

namespace FG 
{
	public class AudioManager : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
