using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width = 6;  // 보드의 가로 크기
    public int height = 6; // 보드의 세로 크기
    public GameObject[] blocks; // 블록 프리팹 배열 (5가지 블록 등록)
    public GameObject[,] allBlocks; // 블록 저장용 2D 배열

    void Start()
    {
        allBlocks = new GameObject[width, height];
        SetupBoard();
    }

    void SetupBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(x, y);
                int blockIndex = Random.Range(0, blocks.Length); // 0~4 사이에서 랜덤 블록 선택
                GameObject block = Instantiate(blocks[blockIndex], position, Quaternion.identity);
                block.transform.parent = this.transform; // 보드의 자식으로 설정
                block.GetComponent<Block>().SetPosition(x, y); // 블록 위치 설정
                allBlocks[x, y] = block;
            }
        }
    }
}
