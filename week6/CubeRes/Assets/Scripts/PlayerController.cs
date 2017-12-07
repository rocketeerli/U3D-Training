using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Transform now_Transform;
    private MapCreate map_Script;

    private int z = 3;
    private int x = 2;
	// Use this for initialization
	void Start () {
        now_Transform = gameObject.GetComponent<Transform>();
        map_Script = GameObject.Find("Map").GetComponent<MapCreate>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControl();
    }
    private void ChangePos()
    {
        Transform tran = map_Script.map_list[x][z].GetComponent<Transform>();
        now_Transform.position = new Vector3(tran.position.x, tran.position.y + 0.254f / 2, tran.position.z);
        Vector3 rot = new Vector3(0, 135, 0);
        now_Transform.rotation = Quaternion.Euler(rot);
    }
    private void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePos();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x++;
            z--;
            ChangePos();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x++;
            z++;
            ChangePos();
        }
    }
}
