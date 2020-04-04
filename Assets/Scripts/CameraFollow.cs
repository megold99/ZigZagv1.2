using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;   //đối tượng ball
    Vector3 offset;        //khoảng cách giữa ball và camera
    [SerializeField]
    [Range(0,10f)]  
    float lerpSpeed;     //tóc độ
     public bool gameOver;
    private void Awake()
    {
        gameOver = false;

    }
    void Start()
    {
        offset = transform.position - ball.transform.position;  // lưu khoảng cách giữa trái đóng và vật

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)  //nếu game chưa kết thúc
        {
            Follow(); 
        }
    }
     void Follow() //thực hiện di chuyển
    {
        Vector3 pos = transform.position;  //vị trí của camera
        Vector3 target = ball.transform.position+offset; //vị trí của đối tượng cần follow + khoảng cách (xem lại vector cấp 3)
        pos = Vector3.Lerp(pos,target,lerpSpeed*Time.deltaTime); //thực hiện hàm lerp (nội suy tuyến tính) làm mượt chuyển động theo thời gian 
        transform.position = pos; //xét  vector (sau khi thực hiện hàm lerp ) vị trí cho camera

    }
}
