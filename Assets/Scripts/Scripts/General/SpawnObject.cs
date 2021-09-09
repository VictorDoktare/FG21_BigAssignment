using UnityEngine;


namespace FG 
{
	public class SpawnObject : MonoBehaviour
	{
		[Range(0.1f, 10)] [SerializeField] private float scaleSpeed;
		[SerializeField] private AnimationCurve _scaleCurve;

		private Vector3 _startScale, _endScale;
		private float _lerpInterpolant = 0;
		private float _randTime;

		private void Start()
		{
			_startScale = Vector3.zero;
			_endScale = transform.localScale;
			
			transform.localScale = new Vector3(0f, 0f, 0f);
		}

		private void Update()
		{
			_lerpInterpolant += Time.deltaTime * scaleSpeed;
			ScaleObject();
			if (_lerpInterpolant >= 5)
			{
				Destroy(gameObject.GetComponent<SpawnObject>());
			}
		}

		private void ScaleObject()
		{
			transform.localScale = Vector3.Lerp(_startScale, _endScale, _scaleCurve.Evaluate(_lerpInterpolant));
		}

	}
}
