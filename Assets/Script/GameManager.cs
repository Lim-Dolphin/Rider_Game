using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글턴 할당

    //생성할 맵 리스트
    public GameObject[] Map_List;

    //현재 생성된 맵 리스트
    public List<GameObject> Now_Map;

    //맵 크기
    int Map_size = 120;

    //게임 시작 여부
    private bool isPlay = false;

    //게임 시작화면
    public GameObject gamestart_UI;

    //이전 최고 점수와 역대 최고 점수 저장
    private int Score = 0;
    private int HighScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
        Now_Map = new List<GameObject>();
        Reset_Map();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        bool isOut = Check_Area();

        if(isOut)
        {
            Delete_Map();
            Create_Map();
        }
    }

    public void Map_Move()
    {
        for(int i=0;i<Now_Map.Count;i++)
        {
            Now_Map[i].transform.position = new Vector2(Now_Map[i].transform.position.x - (Map_size/2), Now_Map[i].transform.position.y);
        }
    }
    private bool Check_Area()
    {
        bool isOut = false;
        if(Now_Map[0].transform.position.x <= -120)
        {
            isOut = true;
        }
        return isOut;
    }

    private void Delete_Map()
    {
        GameObject Delete_map = Now_Map[0];
        Now_Map.RemoveAt(0);
        Destroy(Delete_map);
    }

    private void Create_Map()
    {
        int random_num = Random.Range(0, 5);
        GameObject create_map = Instantiate(Map_List[random_num]);
        create_map.transform.position = new Vector2(Map_size * Now_Map.Count, 0);
        Now_Map.Add(create_map);
    }

    private void Reset_Map()
    {
        if(Now_Map.Count != 0)
        {
            for (int i = 0; i < Now_Map.Count;i++)
            {
                Destroy(Now_Map[i]);
            }
        }
        Now_Map.Clear();
        while (Now_Map.Count < 3)
        {
            int random_num = Random.Range(0, 5);
            GameObject create_map = Instantiate(Map_List[random_num]);
            create_map.transform.position = new Vector2(Map_size * Now_Map.Count, 0);
            Now_Map.Add(create_map);
        }
    }

    public bool Get_isPlay()
    {
        return isPlay;
    }

    //게임 시작 버튼을 눌렀을 때
    public void Game_Start()
    {
        isPlay = true;
        gamestart_UI.SetActive(false);
    }

    public void Set_Score(int score)
    {
        Score = score;
        if(HighScore <= Score)
        {
            HighScore = Score;
        }
    }

    public void Restart()
    {
        Reset_Map();
        isPlay = false;
        gamestart_UI.SetActive(true);
        gamestart_UI.transform.GetChild(4).GetComponent<Text>().text = Score.ToString();
        gamestart_UI.transform.GetChild(5).GetComponent<Text>().text = HighScore.ToString();
    }
}
