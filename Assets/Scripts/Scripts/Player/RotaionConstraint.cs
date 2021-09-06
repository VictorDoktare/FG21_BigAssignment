using System;
using UnityEngine;

namespace FG 
{
	public class RotaionConstraint : MonoBehaviour 
	{
		private void Update()
		{
			transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
	}
}
