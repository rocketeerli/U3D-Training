using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour {
    public int speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0) * speed);
    }
}
