using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;

    public Transform wall;
    public GameObject brick_prefab;
    public GameObject bullet_prefab;

    private Transform now_Transform;
    private int x_number = 15;
    private int y_number = 10;
	// Use this for initialization
	void Start () {
        now_Transform = gameObject.GetComponent<Transform>();
        CreateWall();
	}
	
	// Update is called once per frame
	void Update () {
        SendRay();
	}
    /// <summary>
    /// 主摄像机发射射线.
    /// </summary>
    private void SendRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //向鼠标点击的地方发射一条射线.
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Destroy(hit.collider.gameObject);
                //实例化子弹.
                GameObject bullet = GameObject.Instantiate(bullet_prefab, now_Transform.position, Quaternion.identity);

                //发射子弹.
                Vector3 bullet_direction = hit.point - now_Transform.position;
                bullet.GetComponent<Rigidbody>().AddForce(bullet_direction*100);
            }
        }
    }
    /// <summary>
    /// 生成一堵墙.
    /// </summary>
    private void CreateWall()
    {
        for (int i = 0; i < x_number; i++)
        {
            for (int j = 0; j < y_number; j++)
            {
                GameObject brick = Instantiate(brick_prefab, new Vector3(i + 0.2f, j + 0.2f, 0), Quaternion.identity);
                brick.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
            }
        }
    }
}
