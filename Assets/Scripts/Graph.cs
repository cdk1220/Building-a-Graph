﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    //This is what is instantiated
	public Transform pointPrefab;      

    //Number instantiated which can now be changed in the IDE
	[Range(15, 105)]
	public int resolution = 15;

    //Using enumerations to change the function on the fly
    public GraphFunctionName function;

	//List to contain points created
	List<Transform> points = new List<Transform>();

    //List of functions that we can visualize
    static GraphFunction[] functions = {
        SineFunction,
        MultiSineFunction,
        Sine2DFunction,
        MultiSine2DFunction,
        RippleFunction
    };

    //Since pi is used alot created a const
    const float pi = Mathf.PI;

    //Calls every frame
	void Update() {
		
        //Time elapsed
        float t = Time.time;

        //Choosing the right function
        GraphFunction f = functions[(int)function];

        for (int i = 0; i < resolution * resolution; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;

            position.y = f(position.x, position.z, t);
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

        //Create enough points for a grid, as many lines as the number of points
        for (int i = 0, z = 0; i < resolution; i++, z++)
        {
            //Rows are along y
            position.z = ((z * step) - 1f);

            for (int x = 0; x < resolution; x++)
            {
                Transform point = Instantiate(pointPrefab);

                if (x == resolution)
                {
                    x = 0;
                    z += 1;
                }

                //Points are along 
                position.x = ((x * step) - 1f);

                point.localPosition = position;

                //Bringing back the cubes together so there is no overlap
                point.localScale = scale;

                //Make the clones children
                point.SetParent(transform, false);

                //Add created cube to the list
                points.Add(point);
            }
        }
	}

    //Call this in Update() to visualize a sine function
    static float SineFunction(float x, float z, float t) {
        return Mathf.Sin(pi * (x + t));
    }

    //Call this in Update to visualize a complex a complex sine function
    static float MultiSineFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }

    //Call this to visualize a 2D function
    static float Sine2DFunction (float x, float z, float t) {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(pi * (z + t));
        y *= 0.5f;
        return y;
    }

    //Call this to visualize multisine 2D
    static float MultiSine2DFunction(float x, float z, float t)
    {
        float y = 4f * Mathf.Sin(pi * (x + z + t * 0.5f));
        y += Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(2f * pi * (z + 2f * t)) * 0.5f;
        y *= 1f / 5.5f;
        return y;
    }

    //Call this to visualize a ripple
    static float RippleFunction(float x, float z, float t)
    {
        float d = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sin(4f * pi * d - t);
        y /= 1f + 10f * d;
        return y;
    }
}
