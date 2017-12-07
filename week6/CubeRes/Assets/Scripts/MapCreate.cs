using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour {
    public List<GameObject[]> map_list = new List<GameObject[]>();

    private GameObject floor_Prefab;
    private GameObject wall_Prefab;
    private Transform now_Transform;

    private float Side_Length = 0.254f * Mathf.Sqrt(2);

    private Color color_Sigle = new Color(124 / 255f, 155 / 255f, 230 / 255f);
    private Color color_Even = new Color(125 / 255f, 169 / 255f, 233 / 255f);
    private Color color_Wall = new Color(87 / 255f, 93 / 255f, 169 / 255f);

    // Use this for initialization
    void Start()
    {
        floor_Prefab = Resources.Load("tile_white") as GameObject;
        wall_Prefab = Resources.Load("wall2") as GameObject;
        now_Transform = gameObject.GetComponent<Transform>();
        CreateMap();
    }
        
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(map_list.Count);
            Debug.Log("hahahhahahahhah");
        }
	}
    private void CreateMap()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject[] item1 = new GameObject[6];
            for (int j = 0; j < 6; j++)
            {
                Vector3 pos = new Vector3(j * Side_Length, 0, i * Side_Length);
                Vector3 rot = new Vector3(-90, 45, 0);
                if (j == 0 || j == 5)
                {
                    GameObject tile = Instantiate(wall_Prefab, pos, Quaternion.Euler(rot));
                    tile.GetComponent<Transform>().SetParent(now_Transform);
                    tile.GetComponent<MeshRenderer>().material.color = color_Wall;
                    item1[j] = tile;
                }
                else
                {
                    GameObject tile = Instantiate(floor_Prefab, pos, Quaternion.Euler(rot));
                    tile.GetComponent<Transform>().SetParent(now_Transform);
                    //侧面加颜色.
                    tile.GetComponent<MeshRenderer>().material.color = color_Sigle;
                    //表面加颜色.
                    tile.GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material.color = color_Sigle;
                    item1[j] = tile;
                }
            }
            map_list.Add(item1);
            GameObject[] item2 = new GameObject[5];
            for (int j = 0; j < 5; j++)
            {
                Vector3 pos = new Vector3(j * Side_Length + Side_Length / 2, 0, i * Side_Length + Side_Length / 2);
                Vector3 rot = new Vector3(-90, 45, 0);
                GameObject tile = Instantiate(floor_Prefab, pos, Quaternion.Euler(rot));
                tile.GetComponent<Transform>().SetParent(now_Transform);
                //侧面加颜色.
                tile.GetComponent<MeshRenderer>().material.color = color_Even;
                //表面加颜色.
                tile.GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material.color = color_Even;
                item2[j] = tile;
            }
            map_list.Add(item2);
        }
    }
}
