using System;
using UnityEngine;
using UnityEngine.Events;

namespace FG 
{
	public class Goal : MonoBehaviour
	{
		[SerializeField] private UnityEvent _ChangeLevel = new UnityEvent();
		[SerializeField] UIManager _uiManager;

		private void Awake()
		{
			//_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				if (_uiManager.canWin == true)
				{
					Debug.Log("Exit");
					_ChangeLevel.Invoke();
				}
			}
		}
	}
}
