﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    //This is what is instantiated
	public Transform pointPrefab;      

    //Number instantiated which can now be changed in the IDE
	[Range(15, 105)]
	public int resolution = 15;		 

    //Gives the option to change between functions on the fly
    [Range(0, 1)]
    public int function;

	//List to contain points created
	List<Transform> points = new List<Transform>();

    //Calls every frame
	void Update() {
		
        float t = Time.time;

		for (int i = 0; i < resolution; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;

            //Choose which functino to visualize
            if (function == 0) {

                position.y = SineFunction(position.x, t);
            }
            else {

                position.y = MultiSineFunction(position.x, t);
            }

			point.localPosition = position;
		}
		
	}
	
    //When the object is created
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
		position.y = 0;
		position.z = 0;     
		
		//Visualizing f(x) = x
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate(pointPrefab);
			
			//Position for f(x) = x
			position.x = ((i * step)  - 1f);
			point.localPosition = position;

			//Bringing back the cubes together so there is no overlap
			point.localScale = scale;

			//Make the clones children
			point.SetParent(transform, false);

			//Add created cube to the list
			points.Add(point);
		}
	}

    //Call this in Update() to visualize a sine function
    static float SineFunction(float x, float t) {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    //Call this in Update to visualize a complex a complex sine function
    static float MultiSineFunction(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }


}
