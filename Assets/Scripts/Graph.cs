using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;      //This is what is instantiated

	[Range(15, 105)]
	public int resolution = 15;		   //Number instantiated

	void Awake () {
		
		//Scale of a cube
		Vector3 scale = Vector3.one / 5f;		
		
		//Position of a cube 
		Vector3 position;

		//Constant as we dont deal with the z plane
		position.z = 0;     
		
		//Visualizing f(x) = x
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate(pointPrefab);
			
			//Position for f(x) = x
			position.x = ((i / 5f) - 1f);
			position.y = position.x;
			point.localPosition = position;

			//Bringing back the cubes together so there is no overlap
			point.localScale = scale;
		}
	}
}
