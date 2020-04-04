using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // đối tượng game manager được gọi nhiều nên sẽ sử dụng singleton pattern
    public static GameManager instance; // biến static dạng của chính class đố 
    public bool gameOver;
    public List<AudioClip> list;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if(!instance) //nếu instance null thì sẽ lấy địa chỉ của class này 
        {
            instance = this;  //gán địa chỉ
        }
        gameOver = false;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart() // khi game bắt đầu
    {
        UIManager.instance.GameStart();  //chạy animation bên ui
        ScoreManager.instance.StartScore(); //bắt đầu tính điểm
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); //tìm đối tượng PLatformSpawner để thực hiện generate
        audio.clip = list[0];
        audio.loop = true;
        audio.Play();
    }
     public void GameOver()
    {
        UIManager.instance.GameOver(); // chạy animation game over
        ScoreManager.instance.StopScore(); // dừng tính điểm
        gameOver = true;    //xét đã gameOver
        audio.loop = false;
        audio.Stop();
    }
}
