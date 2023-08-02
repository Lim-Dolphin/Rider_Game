using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //������ �� ����Ʈ
    public GameObject[] Map_List;

    //���� ������ �� ����Ʈ
    public List<GameObject> Now_Map;

    //�� ũ��
    int Map_size = 120;

    // Start is called before the first frame update
    void Start()
    {
        Now_Map = new List<GameObject>();
        while(Now_Map.Count < 3)
        {
            int random_num = Random.Range(0, 5);
            GameObject create_map = Instantiate(Map_List[random_num]);
            create_map.transform.position = new Vector2(Map_size * Now_Map.Count, 0);
            Now_Map.Add(create_map);
        }
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
}
