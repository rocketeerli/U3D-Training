using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Transform now_Transform;
    private MapCreate map_Script;

    private int z = 3;
    private int x = 2;

    private float offset = 0;
    private CameraFollower CF;
    // Use this for initialization
    void Start () {
        now_Transform = gameObject.GetComponent<Transform>();
        map_Script = GameObject.Find("Map").GetComponent<MapCreate>();
        CF = GameObject.Find("Main Camera").GetComponent<CameraFollower>();
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
        CreateMap();
    }
    private void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePos();
            CF.Follow = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x++;
            if(x % 2 == 1)
                z--;
            ChangePos();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x++;
            if(x % 2 == 0)
                z++;
            ChangePos();
        }
    }
    /// <summary>
    /// 循环生成地图.
    /// </summary>
    private void CreateMap()
    {
        Transform map_transform = map_Script.map_list[map_Script.map_list.Count - 1][0].GetComponent<Transform>();
        offset = map_transform.position.z + map_Script.Side_Length / 2;
        if (map_transform.position.z - now_Transform.position.z < 2)
        {
            //生成地图.
            map_Script.CreateMap(offset);
        }
    }
}
