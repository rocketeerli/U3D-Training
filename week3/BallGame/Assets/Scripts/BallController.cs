using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public int force = 4;
    private Rigidbody rd;
    private Transform ball_Tranform;

    public GameObject food;

    private int food_num = 0;

    public Transform foods;
    public Text game_score;

    private int score = 0;         //记录当前游戏分数.
    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        ball_Tranform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(x, 0, z) * force);

        CreateFood();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            Destroy(other.gameObject);
            food_num--;
            score++;
            game_score.text = "分数：" + score.ToString();
        }
    }
    /// <summary>
    /// 食物生成控制.
    /// </summary>
    private void CreateFood()
    {
        if (food_num < 10)
        {
            Vector3 pos = new Vector3(Random.Range(-4.7f, 4.7f), 0.3f, Random.Range(-4.7f, 4.7f));
            Instantiate(food, pos, Quaternion.identity, foods);
            food_num++;
        }
    }
}
