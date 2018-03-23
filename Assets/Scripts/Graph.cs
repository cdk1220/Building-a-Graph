using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;

	void Awake () {
		
		for (int i = 0; i < 11; i++) {
			Transform point = Instantiate(pointPrefab);
			
			//Cubes span a range of -1 to 1 on the axis
			point.localPosition = Vector3.right * ((i / 5f) - 1f);

			//Bringing back the cubes together so there is no overlap
			point.localScale = Vector3.one / 5f;
		}
	}
}
