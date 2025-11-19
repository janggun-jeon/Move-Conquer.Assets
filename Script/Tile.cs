using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] tileColor;
    public int currentColorNumber = 0; // 타일의 변화전 색깔 정보 저장
    public int colorNumber; // 타일의 색깔 정보 
    // Start is called before the first frame update
    void Start()
    {
        /* if (num == 1)
         {
             GetComponent<MeshRenderer>().material = tileColor[num];
         }*/
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MakeColor(int id)
    {
        GetComponent<MeshRenderer>().material = tileColor[id];
        colorNumber = id;
    }

}
