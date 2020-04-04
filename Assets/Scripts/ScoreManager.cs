using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   
    //tìm hiểu Invoke trong unity
    // đối tượng game manager được gọi nhiều nên sẽ sử dụng singleton pattern
    public static ScoreManager instance;  // biến static dạng của chính class đố 
    [SerializeField] int score;  //điểm
    [SerializeField] int highScore; //điểm cao nhất

    public int Score { get => score; set => score = value; }

    public void Awake()
    {
        if(!instance)  //nếu instance null thì sẽ lấy địa chỉ của class này 
        {
            instance = this;//gán địa chỉ
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0; //điểm ban đầu
        PlayerPrefs.SetInt("score", score); //xét giá trị score được lưu trong máy
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IncrementScore()  //tính điểm
    {
        score++; 
    }
    public void StartScore() //tính điểm
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);  //gọi hàm IncrementScore sau 0.1f và gọi liên tục sau mỗi 0.5f
    }
    public void StopScore() //dừng tính điểm
    {
        CancelInvoke("IncrementScore"); //hủy bỏ invoke gọi hàm  IncrementScore
        PlayerPrefs.SetInt("score", score); //set score trong máy
        if(PlayerPrefs.HasKey("highScore") ) //nếu trong máy có highscore
        {
            if(score > PlayerPrefs.GetInt("highScore")) //nếu điểm chơi được lớn hơn điểm highscore lưu trong máy
            {
                PlayerPrefs.SetInt("highScore",score); //lưu highscore
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score); //lưu highscore
        }
    }

    public void addBonusScore()
    {
        score += 10;
    }
}
