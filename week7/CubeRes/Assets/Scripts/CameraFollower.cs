using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    private Transform now_Transform;
    private Transform Player_Transform;

    public bool Follow = false;
	// Use this for initialization
	void Start () {
        now_Transform = gameObject.GetComponent<Transform>();
        Player_Transform = GameObject.Find("cube_car").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        CameFoll();

    }
    public void StartFollow()
    {
        if(Follow)
        {
            CameFoll();
        }
    }
    /// <summary>
    /// 摄像机跟随.
    /// </summary>
    private void CameFoll()
    {
        Vector3 pos = new Vector3(now_Transform.position.x,now_Transform.position.y, Player_Transform.position.z + -1.171639f);
        now_Transform.position = Vector3.Lerp(now_Transform.position, pos, Time.deltaTime);
    }
}
