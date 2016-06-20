using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
using System.Collections;

public class ComputerEnter : MonoBehaviour {

	public Text _interactText;

	[HideInInspector]
	public bool _isEntering = false;

	private bool _canInteract;
	private float _lerp;

	private Vector3 _velocity = Vector3.zero;

	void Awake () {
		_interactText.CrossFadeAlpha (0f, 0f, false);
	}

	void Update () {
		_lerp += Time.time / 200f;

		if (_canInteract) {
			if (Input.GetMouseButtonDown (0)) {
				_isEntering = !_isEntering;
				_lerp = 0f;
			}
		}

		if (_isEntering) {
			Camera.main.transform.position = Vector3.SmoothDamp (Camera.main.transform.position, new Vector3 (-2.5f, 1.75f, 3.85f), ref _velocity, 0.2f);
			Camera.main.GetComponent<SimpleMouseRotator> ().enabled = false;
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, Quaternion.Euler (new Vector3 (0f, 0f, 0f)), _lerp);
		} else {
			Camera.main.transform.position = Vector3.SmoothDamp (Camera.main.transform.position, new Vector3 (-2.5f, 2f, 2f), ref _velocity, 0.2f);
			Camera.main.GetComponent<SimpleMouseRotator> ().enabled = true;
		}
	}

	void OnMouseEnter () {
		_interactText.CrossFadeAlpha (1f, 0.2f, false);
		_canInteract = true;
	}

	void OnMouseExit () {
		_interactText.CrossFadeAlpha (0f, 0.2f, false);
		_canInteract = false;
	}
}