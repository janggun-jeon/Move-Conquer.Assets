using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] tiles;
    public int id;
    public int[] input;
    public GameObject player;
    public int index1;
    public int index2;
    public int checknum = -1;
    public int[] checkPos;

    public List<Vector3> routine = new List<Vector3>(); // 플레이어 경로




    // Start is called before the first frame update
    void Start()
    {
        if (player.tag == "Player1")
        {
            index1 = 4; // 정중앙에 대한 일반화 한 식 나중에 넣어보기
            player.transform.position = tiles[4].transform.position;
            Debug.Log(player.transform.position);
            GameManager.Routine(gameObject); // 최초 위치 초기화
        }
        if (player.tag == "Player2")
        {
            index2 = 13; // 정중앙에 대한 일반화 한 식 나중에 넣어보기
            player.transform.position = tiles[13].transform.position;
        }

        //tiles[0].GetComponent<Tile>().MakeBlue();
    }

    // Update is called once per frame
    void Update()
    {    // Player1 기준에서 인덱스가 0에 가까운 위치가 천장(위쪽)
        if (player.tag == "Player1")
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                
                if (index1 - 3 >= 0) // Player1 기준 올라감
                {
                    index1 -= 3;
                    CrossPaint();

                }
                else
                {
                    Debug.Log("위로 갈수 없음");
                }
                


            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index1 % 3 == 2) // Player1 기준 맨왼쪽
                {
                    Debug.Log("왼쪽으로 갈 수 없음");                  
                }
                else
                {
                    index1 += 1;
                    CrossPaint();
                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index1 + 3 <= 17) // Player1 기준 맨 아래
                {
                    index1 += 3;
                    CrossPaint();
                }
                else
                {
                    Debug.Log("아래로 갈 수 없음");
                }

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index1 % 3 == 0) // Player1 기준 맨 오른쪽
                {
                    Debug.Log("오른쪽으로 갈 수 없음");
                }
                else
                {
                    index1 -= 1;
                    CrossPaint();
                }

            }

        }
        if (player.tag == "Player2")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (index2 - 3 >= 0) // Player2 기준 올라감
                {
                    index2 -= 3;
                    CrossPaint();

                }
                else
                {
                    Debug.Log("위로 갈수 없음");
                }


            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (index2 % 3 == 0) // Player1 기준 맨왼쪽
                {
                    Debug.Log("왼쪽으로 갈 수 없음");
                }
                else
                {
                    index2 -= 1;
                    CrossPaint();
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index2 + 3 <= 17) // Player2 기준 맨 아래
                {
                    index2 += 3;
                    CrossPaint();
                }
                else
                {
                    Debug.Log("아래로 갈 수 없음");
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (index2 % 3 == 2) // Player2 기준 맨 오른쪽
                {
                    Debug.Log("오른쪽으로 갈 수 없음");
                }
                else
                {
                    index2 += 1;
                    CrossPaint();
                }


            }

        }


    }
    

   
    void CrossPaint()
    {
       
            if (player.tag == "Player1")
            {

                if (index1 % 3 == 0) // 움직인 후 인덱스 받고 Player1 기준 가장 오른쪽
                {
                    Debug.Log("우측은 칠해지지 않음");
                }
                else
                {
                    tiles[index1 - 1].GetComponent<Tile>().MakeRed();
                }

                if (index1 % 3 == 2) // 움직인 후 인덱스 받고 Player1 기준 가장 왼쪽
                {
                    Debug.Log("좌측은 칠해지지 않음");
                }
                else
                {
                    tiles[index1 + 1].GetComponent<Tile>().MakeRed();
                }

                if (index1 - 3 >= 0) // 움직인 후 인덱스 받고 Player1 위쪽 판정
                {
                    tiles[index1 - 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("위쪽은 칠해지지 않음");
                }

                if (index1 + 3 <= 17) // 움직인 후 인덱스 받고 Player1 아래쪽 판정
                {
                    tiles[index1 + 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("아래쪽은 칠해지지 않음");
                }


               
                player.transform.position = tiles[index1].transform.position;
            

            }

            if (player.tag == "Player2")
            {

                if (index2 % 3 == 0) // 움직인 후 인덱스 받고 Player2 기준 가장 왼쪽
                {
                    Debug.Log("왼측은 칠해지지 않음");
                }
                else
                {
                    tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
                }

                if (index2 % 3 == 2) // 움직인 후 인덱스 받고 Player2 기준 가장 오른쪽
                {
                    Debug.Log("우측은 칠해지지 않음");
                }
                else
                {
                    tiles[index2 + 1].GetComponent<Tile>().MakeBlue();
                }

                if (index2 - 3 >= 0) // 움직인 후 인덱스 받고 Player2 위쪽 판정
                {
                    tiles[index2 - 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("위쪽은 칠해지지 않음");
                }

                if (index2 + 3 <= 17) // 움직인 후 인덱스 받고 Player2 아래쪽 판정
                {
                    tiles[index2 + 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("아래쪽은 칠해지지 않음");
                }



                player.transform.position = tiles[index2].transform.position;
            }


        }
        /*
        if (player.tag == "Player2")
        {
            if (index2 % 3 == 0) // 움직인 후 인덱스 받고 Player2 기준 가장 왼쪽
            {
                Debug.Log("왼측은 칠해지지 않음");
            }
            else
            {
                tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
            }


            tiles[index2 - 1].GetComponent<Tile>().MakeBlue();
            tiles[index2 + 1].GetComponent<Tile>().MakeBlue();
            tiles[index2 - 3].GetComponent<Tile>().MakeBlue();
            tiles[index2 + 3].GetComponent<Tile>().MakeBlue();

            player.transform.position = tiles[index2].transform.position;


        }
        */

 

    
    /*
    void PlayerMove()
    {
        switch (checknum)
        {
            case 1:
                Debug.Log("S,D 누를수 있음")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S 누름");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D 누름");
                    break;
                }

            case 2:

                Debug.Log("S,D 누를수 있음")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S 누름");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D 누름");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A 누름");
                    CrossPaint();

                }
            case 3:

                Debug.Log("S,D 누를수 있음")
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D 누름");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A 누름");
                    CrossPaint();

                }
            case 4:

                Debug.Log("S,D 누를수 있음")
                if (Input.GetKeyDown(KeyCode.S))
                {
                    index1 += 3;
                    Debug.Log("S 누름");
                    break;

                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    index1 -= 1;
                    Debug.Log("D 누름");
                    break;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    index1 += 1;
                    Debug.Log("A 누름");
                    break

                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    index1 -= 3;
                    Debug.Log("W 누름");
                    break


                }


        }
    }
    */
    void CheckPos(int idx)
    {
    
        
        if (idx % 3 == 0)
        {

            if (idx - 3 <= 0 )
            {
                checkPos = new int[] { idx + 1, idx + 3 };
                checknum = 1;
            }

            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx + 1, idx - 3 };
                checknum = 7;
            }
            else
            {
                checkPos = new int[] { idx + 1, idx - 3, idx + 3 };
                checknum = 4;
            }


        }

        else if (idx % 3 == 2)
        {

            if (idx - 3 <= 0)
            {
                checkPos = new int[] { idx - 1, idx + 3 };
                checknum = 3;
            }
            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx - 1, idx - 3 };
                checknum = 9;
            }
            else
            {
                checkPos = new int[] { idx - 1, idx - 3, idx + 3 };
                checknum = 6;
            }


        }

    
        else
        {
            if (idx - 3 <= 0)
            {
                checkPos = new int[] { idx - 1, idx + 1, idx + 3 };
                checknum = 2;
            }
            else if (idx + 3 >= 17)
            {
                checkPos = new int[] { idx - 1, idx + 1, idx - 3 };
                checknum = 8;
            }
            else
            {
                checkPos = new int[] { idx - 1, idx + 1, idx - 3, idx + 3 } ;
                checknum = 5;
            }
        }


    }
    
    
}
