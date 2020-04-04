using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    // đối tượng liên quan đến UI thường được các đối tượng khác gọi nên phải dùng  singleton pattern lưu ý sẽ ko dùng UI gọi các đối tượng game object khác
    public static UIManager instance;  // biến static dạng của chính class đố 
    public GameObject ScorePanel;
    public GameObject zigzacPanel;
    public GameObject gameOverPanel;
    public GameObject taptext;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text scoreText;
    public GameObject helpPanel;
    public BallController ballController;
    public List<Image> listImg;
    public Button btnHelp;
    public Button Music;
    bool isShowHelp;
    private void Awake()
    {
        if(!instance)  // singletin pattern    //check nếu instance là null thì sẽ tham chiếu đến chính nó(lưu địa chỉ)
        {
            instance = this; // lưu điện chỉ của chính biến 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: "+PlayerPrefs.GetInt("highScore"); // lấy data cao nhất được lưu trong máy
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.Score.ToString();
    }
    public void GameStart()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString(); // lấy data cao nhất được lưu trong máy
        taptext.SetActive(false);   //ẩn đối tượng
        zigzacPanel.GetComponent<Animator>().Play("PanelMoveUp"); // chạt animation
        Invoke("showScore", 1f);
    }
    public void GameOver()
    {
        hideScorePanel();
        score.text = PlayerPrefs.GetInt("score").ToString();  //  hiện thị số điểm
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString(); //hiện thị highscore
        gameOverPanel.SetActive(true); //hiện panel
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // reloadd lại scene khi game kết thúc
    }


    public void showScore() {
        ScorePanel.SetActive(true);
       
    }

    public void hideScorePanel()
    {
        ScorePanel.SetActive(false);
    }

    public void ShowHelp()
    {
        ballController.start = false;
        ballController.PressSomething = !ballController.PressSomething;
        if (!isShowHelp)
        {
            helpPanel.SetActive(true);
            isShowHelp = true;
        }
        else
        {
            helpPanel.SetActive(false);
            isShowHelp = false;
        }
        Debug.Log(ballController.start);
        Debug.Log(ballController.PressSomething);
    }
}
