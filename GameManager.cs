using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Camera cam; // 레이저를 쏠 카메라 컴포넌트
    public static GameObject cntPlayer; // 현재 플레이어
    public static List<Vector3> routine; // 플레이어 경로

    public static float time; // 턴 시간

    public static GameObject board; // 보드
    public static int redScore; // 레드팀 점수
    public static int blueScore; // 블루팀 점수 

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        cntPlayer = GameObject.FindWithTag("Player1");

        routine = new List<Vector3>();

        time = 30f;

        board = GameObject.FindWithTag("Board");
        redScore = 0;
        blueScore = 0;
    }

    void Update()
    {
        time -= Time.deltaTime; // 턴 시간 감소
        ArrowClick(); // 항상 클릭 가능
        /*if ((int)time % 2 == 1)
        {
            Score();
        }*/
    }

    public  void ArrowClick() // 이동할 타일 클릭하면 이동
    {
        if (Input.GetMouseButtonDown(0)) // 클릭이 있을 때
        {
            // 클릭 위치 정보 받아오기
            Vector3 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // 클릭 위치의 오브젝트(타일) 탐지
            RaycastHit hit;
            Physics.Raycast(clickPos, transform.forward, out hit, 60f);
            if (hit.collider.tag == "Arrow")
            {
                // 플레이어 이동
                cntPlayer.transform.position = hit.transform.position; // 이동
                Routine(cntPlayer);
            }
        }
    }

    public static void Routine(GameObject player) // 플레이어 객체의 위치를 리스트에 넣고 반환
    {
        routine.Add(player.transform.position);
        player.GetComponent<Player>().routine = routine;
    }

    public static void Score()
    {
        GameObject[] tiles = board.GetComponent<Board>().tiles;
        int r = 0; int b = 0; 
        for (int itr = 0; itr < tiles.Length; itr++)
        {
            if (tiles[itr].GetComponent<Tile>().colorNumber == 1)
            {
                r++; Debug.Log("Score!");
            }
            else if (tiles[itr].GetComponent<Tile>().colorNumber == 2)
            {
                b++;
            }
        }
        redScore = r;
        blueScore = b;
    }
}
