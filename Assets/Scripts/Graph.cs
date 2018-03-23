using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;

	void Awake () {
		
		for (int i = 0; i < 11; i++) {
			Transform point = Instantiate(pointPrefab);
			
			point.localPosition = Vector3.right * i;

			point.localScale = Vector3.one / 5f;

			point.localPosition = Vector3.right * i / 5f;
		}
	}
}
