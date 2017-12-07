using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public int force = 4;
    private Rigidbody rd;
    // Use this for initialization
    void Start () {
        rd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(x, 0, z) * force);
    }
}
