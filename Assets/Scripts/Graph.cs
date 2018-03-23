using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;      //This is what is instantiated

	[Range(15, 105)]
	public int resolution = 15;		   //Number instantiated

	void Awake () {

		//Make sure the resolution is odd so that the range(-1, 1) is fully
		//covered with a cube at the origin
		if ((resolution / 2) == 0) {
			resolution = resolution + 1;
		}
		

		//Scale of a cube
		float step = 2 / ((float)resolution - 1);
		Vector3 scale = Vector3.one * step;		
		
		//Position of a cube 
		Vector3 position;

		//Constant as we dont deal with the z plane
		position.z = 0;     
		Debug.Log(step);
		//Visualizing f(x) = x
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate(pointPrefab);
			
			//Position for f(x) = x
			position.x = ((i * step)  - 1f);
			position.y = position.x;
			point.localPosition = position;

			//Bringing back the cubes together so there is no overlap
			point.localScale = scale;
		}
	}
}
