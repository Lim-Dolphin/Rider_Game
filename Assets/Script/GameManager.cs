using System.Collections;
using System.Collections.Generic;
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
        
    }
}
