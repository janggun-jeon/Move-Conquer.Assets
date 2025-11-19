using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Dice; // 주사위 객체
    public GameObject restartButton; // 재시작 버튼
    public GameObject gameOverText;

    public GameObject[] tiles; // 타일 list 받기
    public bool isGameOver; // 종료 판정 변수
    // public int diceNumber;
    int diceNumber; // 받은 주사위 숫자
    int maxTurn; // 최대 턴수 설정


    public GameObject playerPrefab;
    GameObject player1;
    GameObject player2;










    //Player p1 = player1.GetComponent<Player>(); 
    //Player p2 = player2.GetComponent<Player>(); 




    bool flag; // 시점 정하기 아직 안씀
    bool turnEnd; // 각 턴 종료



    //아래에 정의된 변수는 텍스트로 표시할 정보
    public static float time;// 시간

    public static int turn; // 턴의 정의

    public static int redScore; // player1 점수
    public static int blueScore; // player2 점수

    public static string winner; // 승자



  





    //public static enum playerColor = { RED =1, BLUE }  
    // Start is called before the first frame update
    void Start()
    {
        
        player1 = Instantiate(playerPrefab);
        player2 = Instantiate(playerPrefab);
        player1.GetComponent<Player>().PlayerRestart(4, 1, tiles);
        player2.GetComponent<Player>().PlayerRestart(13, 2, tiles);
        


        //player1.id = 1;
        //player2.id = 2;

        time = 30.0f;
        restartButton.SetActive(false);
        gameOverText.SetActive(false);
        turn = 1;
        turnEnd = false;
        
        maxTurn = 6;
        diceNumber = Dice.GetComponent<Dice>().diceNumber;
        Debug.Log("주사위 숫자는" + diceNumber);
        isGameOver = false;

        redScore = 0;
        blueScore = 0;


    }

    // Update is called once per frame
    void Update()
    {

           
        TurnChange();
        TileCounter();
        TurnTime();
        Win();
        //Reset();
        PlayerMove();
        if (isGameOver)
        {
            Debug.Log("게임종료는: " + isGameOver);
            gameOverText.GetComponent<Text>().text = "<Winner>: " + winner;
            restartButton.SetActive(true);
            gameOverText.SetActive(true);
        }


    }

    

    void TurnTime()
    {
        time -= Time.deltaTime;
        if (turnEnd == true)
        {
            time = 30.0f;
            turnEnd = false;
        }

        if (time < 0)
        {
            //player1.SetActive(false);
            //player2.SetActive(false);
            time = 0;
        }


    }

    void TileCounter() // 타일 갯수 세는 함수
    {
        if (turnEnd == true)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].GetComponent<Tile>().colorNumber == 1) // player1 점수 세는 반복문
                {
                    redScore++;

                }
                else if (tiles[i].GetComponent<Tile>().colorNumber == 2) // player2 점수 세는 반복문
                {
                    blueScore++;
                }

            }
        }

    } // argument로 요약 시도

    public void OnClickRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    void TurnChange() // 턴 변화 규칙
    {
        if (turn <= maxTurn )
        {
            if (diceNumber == player1.GetComponent<Player>().moveCount)
            {
                player1.SetActive(false);
               /* player1.GetComponent<Player>().unPaint = false;
                player2.GetComponent<Player>().unPaint = true;*/
            }
            if (diceNumber == player2.GetComponent<Player>().moveCount)
            {
                player2.SetActive(false);
                /* player1.GetComponent<Player>().unPaint = true;
                 player2.GetComponent<Player>().unPaint = false;*/
            }



        }
        // turn 7일때 게임 종료
        if (player1.activeSelf == false && player2.activeSelf == false) // if 조건문에 스페이스바를 다음턴 넘어가는 키를 추가하자
        {

            if (turn <= maxTurn)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player1.SetActive(true);
                    player2.SetActive(true);
                    //int routineCount = player1.GetComponent<Player>().routine.Count;
                    //Debug.Log("경로 총 횟수:" + routineCount);



                    Debug.Log("턴 " + turn + " 종료");
                    int index1 = player1.GetComponent<Player>().routine[diceNumber]; // Routine의 총 개수는 첫 위치 포함 마지막 까지
                    int index2 = player2.GetComponent<Player>().routine[diceNumber]; // Routine의 총 개수는 첫 위치 포함 마지막 까지

                    Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7); // ex [0,0,0,0,0,0], dicenubmer = 5


                    diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6까지 굴리기              
                    Debug.Log("주사위 숫자는 " + diceNumber);


                    // diceNumber + 1 이므로 index는 diceNubmer가 마지막
                    player1.GetComponent<Player>().routine = new List<int>();
                    player1.GetComponent<Player>().routine.Add(index1);
                    player2.GetComponent<Player>().routine = new List<int>();
                    player2.GetComponent<Player>().routine.Add(index2);
                    player1.GetComponent<Player>().moveCount = 0;
                    player2.GetComponent<Player>().moveCount = 0;
                    redScore = 0;
                    blueScore = 0;
                    // 턴이 변화하면서 경로정보와 moveCount 초기화

                    for (int i = 0; i < tiles.Length; i++) // 턴이 바뀌면서 타일 현재 정보 변경
                    {
                        tiles[i].GetComponent<Tile>().currentColorNumber
                        = tiles[i].GetComponent<Tile>().colorNumber;
                    }


                    turn++;
                    turnEnd = true;
                }
            }


        }
    }
    /*
    void TurnEnd()
    {
        if (diceNumber == player1.GetComponent<Player>().moveCount)
        {
            player1.SetActive(false);
        }
        if (diceNumber == player2.GetComponent<Player>().moveCount)
        {
            player2.SetActive(false);
        }
    }

    IEnumerator TurnNext(GameObject player)
    {
        yield return new WaitForSeconds(2.0f);

        if (player1.activeSelf == false && player2.activeSelf == false && maxTurn <= 6) // if 조건문에 스페이스바를 다음턴 넘어가는 키를 추가하자
        {

            if (turn <= maxTurn && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 " + turn + " 종료");
                player1.SetActive(true);
                player2.SetActive(true);
                Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7);
                diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6까지 굴리기              
                Debug.Log("주사위 숫자는 " + diceNumber);
                int index = player.GetComponent<Player>().routine[diceNumber]; // Routine의 총 개수는 첫 위치 포함 마지막 까지 
                // diceNumber + 1 이므로 index는 diceNubmer가 마지막
                player.GetComponent<Player>().routine = new List<int>();
                player.GetComponent<Player>().routine.Add(index);               
                player.GetComponent<Player>().moveCount = 0;
                
                for (int i = 0; i < tiles.Length; i++)
                {
                    tiles[i].GetComponent<Tile>().currentColorNumber
                    = tiles[i].GetComponent<Tile>().colorNumber;
                }
                player.GetComponent<Player>().PlayerMove();

                turn++;
                turnEnd = true;

            }

        }
    }
    */




    void Win()
    {
        if (turn > maxTurn)
        {
            player1.SetActive(false);
            player2.SetActive(false);
            isGameOver = true;
        }

        if (isGameOver)
        {
            //Debug.Log("게임종료:" + isGameOver);
            TileCounter();

            if (redScore > blueScore)
            {
                winner = "player1";
            }
            else if (redScore < blueScore)
            {
                winner = "player2";
            }
            else
            {
                winner = "승자가 정해지지 못했습니다.";
            }


        }



    }







    /*
    void Reset(GameObject player) // 플레이어 객체의 위치를 리스트에 넣고 반환
    {


        if (Input.GetMouseButtonDown(0))
        {


            player.GetComponent<Player>().moveCount = 0;                      
            int index = player.GetComponent<Player>().routine[0];
            player.GetComponent<Player>().index = index;
            player.SetActive(true);
            player.transform.position = tiles[index].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
            player.GetComponent<Player>().routine = new List<int>();
            player.GetComponent<Player>().routine.Add(index);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // 타일의 턴 변경 전 색상
                tiles[i].GetComponent<MeshRenderer>().material
                = tiles[i].GetComponent<Tile>().tileColor[j]; // 색 초기화
            }
            Debug.Log("초기화");
        }

    }
    */
    public void OnClickReset()
    {

        player1.GetComponent<Player>().moveCount = 0;
        int index1 = player1.GetComponent<Player>().routine[0];
        player1.GetComponent<Player>().index = index1;
        player1.SetActive(true);
        player1.transform.position = tiles[index1].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
        player1.GetComponent<Player>().routine = new List<int>();
        player1.GetComponent<Player>().routine.Add(index1);

        player2.GetComponent<Player>().moveCount = 0;
        int index2 = player2.GetComponent<Player>().routine[0];
        player2.GetComponent<Player>().index = index2;
        player2.SetActive(true);
        player2.transform.position = tiles[index2].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
        player2.GetComponent<Player>().routine = new List<int>();
        player2.GetComponent<Player>().routine.Add(index2);

        for (int i = 0; i < tiles.Length; i++)
        {
            int j = tiles[i].GetComponent<Tile>().currentColorNumber; // 타일의 턴 변경 전 색상
            tiles[i].GetComponent<MeshRenderer>().material
            = tiles[i].GetComponent<Tile>().tileColor[j]; // 색 초기화
        }
        Debug.Log("초기화");

    }
    /*
    void Reset() // 플레이어 객체의 위치를 리스트에 넣고 반환
    {


        if (Input.GetMouseButtonDown(0))
        {

            player1.GetComponent<Player>().moveCount = 0;
            int index1 = player1.GetComponent<Player>().routine[0];
            player1.GetComponent<Player>().index = index1;
            player1.SetActive(true);
            player1.transform.position = tiles[index1].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
            player1.GetComponent<Player>().routine = new List<int>();
            player1.GetComponent<Player>().routine.Add(index1);

            player2.GetComponent<Player>().moveCount = 0;
            int index2 = player2.GetComponent<Player>().routine[0];
            player2.GetComponent<Player>().index = index2;
            player2.SetActive(true);
            player2.transform.position = tiles[index2].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
            player2.GetComponent<Player>().routine = new List<int>();
            player2.GetComponent<Player>().routine.Add(index2);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // 타일의 턴 변경 전 색상
                tiles[i].GetComponent<MeshRenderer>().material
                = tiles[i].GetComponent<Tile>().tileColor[j]; // 색 초기화
            }
            Debug.Log("초기화");
        }

    }
    */

    void PlayerMove() // Player가 원하는 대로 동시에 움직임
    {
        List<int> copyRoutine1 = player1.GetComponent<Player>().routine;
        List<int> copyRoutine2 = player2.GetComponent<Player>().routine;
        if (time == 0)
        {
            for (int i = 0; i <= diceNumber; i++)
            {

                //StartCoroutine(TurnMove(i, copyRoutine1, 1));
                //StartCoroutine(TurnMove(i, copyRoutine2, 2));
            }
            
        }

    }

    public void TurnMove(int i, List<int> copyRoutine, int id) // id가 플레이어 번호
    {
        player1.SetActive(true);
        player2.SetActive(true);
       
               
        int pos = copyRoutine[i];

        if (id == 1)
        {
            player1.transform.position = tiles[pos].transform.position;
        }
        else if (id == 2)
        {
            player2.transform.position = tiles[pos].transform.position;
        }
        
        // [ 123456 ] 
        /*
        int pos1 = player1.GetComponent<Player>().routine[i];
        player1.transform.position = tiles[pos1].transform.position;
        int pos2 = player2.GetComponent<Player>().routine[i];
        player2.transform.position = tiles[pos2].transform.position;
       */



    }



    public static void Rule()
    {
        int index1 = GameObject.Find("player1").GetComponent<Player>().index;
        int index2 = GameObject.Find("player2").GetComponent<Player>().index;
        if (index1 == index2)
        {

           GameObject.Find("player1").GetComponent<Player>().unPaint = true;
           GameObject.Find("player2").GetComponent<Player>().unPaint = true;


        }
        else
        {
            GameObject.Find("player1").GetComponent<Player>().unPaint = false;
            GameObject.Find("player2").GetComponent<Player>().unPaint = false;
        }
    }
}


