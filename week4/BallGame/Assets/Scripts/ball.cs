using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {
    public int force = 4;
    private Rigidbody rd;
    private Transform player_Transform;

    public GameObject food;
    public Transform foods;
    private int food_number = 0;

    public Text score_Text;
    public Text max_score_Text;
    private int score = 0;
    private int max_score;

    private Transform[] walls_Transform;
    private void SaveData()
    {
        if (score > max_score)
        {
            PlayerPrefs.SetInt("score", score);
        }
    }
	// Use this for initialization
	void Start () {
        rd = gameObject.GetComponent<Rigidbody>();
        player_Transform = gameObject.GetComponent<Transform>();
        /*Vector3 pos = new Vector3(Random.Range(-4.7f, 4.7f), 0.2f, Random.Range(-4.7f, 4.7f));
        GameObject.Instantiate(food, pos, Quaternion.identity, foods);
        food_number++;*/

        walls_Transform = GameObject.Find("wall").GetComponentsInChildren<Transform>();

        max_score = PlayerPrefs.GetInt("score", 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(x,0,z) * force);
        if (food_number < 10)
        {
            Vector3 pos = new Vector3(Random.Range(-4.7f, 4.7f), 0.2f, Random.Range(-4.7f, 4.7f));
            GameObject.Instantiate(food, pos, Quaternion.identity, foods);
            food_number++;
        }
        DesttoyWalls();
        ChangeScale();
        if (player_Transform.position.y <= 0)
        {
            SaveData();
            Application.Quit();
        }
        /*if (Input.GetKey("escape"))
            Application.Quit();*/
        
    }
    void DesttoyWalls()
    {
        if (score == 5 && walls_Transform[1] != null)
        {
            Destroy(walls_Transform[1].gameObject);
        }
        if (score == 8 && walls_Transform[2] != null)
        {
            Destroy(walls_Transform[2].gameObject);
        }
        if (score == 12 && walls_Transform[3] != null)
        {
            Destroy(walls_Transform[3].gameObject);
        }
        if (score == 16 && walls_Transform[4] != null)
        {
            Destroy(walls_Transform[4].gameObject);
        }
    }
    void ChangeScale()
    {
        if (score == 8)
        {
            player_Transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        if (score == 11)
        {
            player_Transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        }
        if (score == 14)
        {
            player_Transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            Destroy(other.gameObject);
            food_number--;
            score++;
            score_Text.text = "分数：" + score.ToString();
            max_score_Text.text = "最高分：" + max_score.ToString();
        }
    }
}
