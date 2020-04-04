using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //tìm hiểu Invoke trong unity
    // Start is called before the first frame update
    public GameObject platForm;   // game object 
    public GameObject Diamomnd; //game object
    Vector3 lastPos; // lưu vị trí cũ
    float size;  //size của vật thể
    [SerializeField] float spawner_rate = 0.01f;

    private void Awake()
    {

    }
    void Start()
    {

        size = platForm.transform.localScale.x;  // lưu đô dài size x của vậy -> để tiện cho vật generate vật thể (xác định vị trí vật thể)
        lastPos = platForm.transform.position; // lưu vị trí vật thể cuối

    }
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f,spawner_rate); // gọi hàm spawnPlatform sau 0.2s , các lần sau sẽ gọi hàm   liên tục sau 0.3f 
    }
    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);     
        if(rand < 3)
        {
            SpawnX();  //random theo trục x
        }
        else
        {
            SpawnZ(); // random theo trục y
        }

    }
    // Update is called once per frame
    void Update()
    {

       if(GameManager.instance.gameOver)  // nếu game kết thức 
        {
            CancelInvoke("SpawnPlatform"); // hủy bỏ hàm gọi  
        }
    }

    void SpawnX()  //spawn theo trục x
    {
        Vector3 pos = lastPos;  //lấy vị trí của vật trước  
        pos.x += size; // xác định vị trí mới của vật được generate bằng cách vị trí theo trục x + size của vật thể theo trục x
        lastPos = pos; // xét lại vị trí cho last pos
        Instantiate(platForm, lastPos, Quaternion.identity); // tạo vật thể
        SpawnDiamond(pos); // random diamond
    }

    void SpawnZ() // spawn theo trục z 
    {
        Vector3 pos = lastPos;   //lấy vị trí của vật trước
        pos.z += size;  // xác định vị trí mới của vật được generate bằng cách vị trí theo trục z + size của vật thể theo trục z
        lastPos = pos;  // xét lại vị trí cho last pos
        Instantiate(platForm, lastPos, Quaternion.identity); // tạo vật thể
        SpawnDiamond(pos); // random diamond
    }
    void SpawnDiamond(Vector3 pos)  // hàm để tạo ra diamond
    {
        int ran = Random.Range(0, 4); 
        if(ran == 1)
        {
            Instantiate(Diamomnd, new Vector3(pos.x,pos.y+1,pos.z), Quaternion.identity); //tạo đối tượng diamond
        }
    }

   
}
