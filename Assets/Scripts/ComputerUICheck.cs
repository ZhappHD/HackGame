using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComputerUICheck : MonoBehaviour {

	private ComputerEnter _computerEnter;

	void Awake () {
		_computerEnter = GameObject.Find ("Monitor").GetComponent<ComputerEnter> ();
	}

	void Update () {
		if (_computerEnter._isEntering) {
			GetComponent<Image> ().CrossFadeAlpha (1f, 0.2f, false);
		} else {
			GetComponent<Image> ().CrossFadeAlpha (0f, 0.2f, false);
		}
	}
}
