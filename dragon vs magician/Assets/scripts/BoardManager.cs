using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int width = 6, height = 6; // 보드 크기
    public GameObject blockPrefab; // 블록 프리팹
    public Transform boardContainer; // 블록들이 배치될 부모 오브젝트
    public Sprite[] blockSprites; // 블록 이미지들

    private GameObject[,] blocks; // 블록을 저장하는 2D 배열

    void Start()
    {
        blocks = new GameObject[width, height];
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(x, y);
                GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity, boardContainer);
                newBlock.name = $"Block_{x}_{y}";

                Block blockScript = newBlock.GetComponent<Block>();
                blockScript.row = y;
                blockScript.col = x;
                blockScript.blockSprites = blockSprites;

                blocks[x, y] = newBlock;
            }
        }
    }
}
