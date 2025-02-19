using UnityEngine;

public class Block : MonoBehaviour
{
    public int column;  // X 좌표 (가로)
    public int row;     // Y 좌표 (세로)
    private Board board; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        board = FindObjectOfType<Board>(); // 보드 스크립트 찾기
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPosition(int x, int y)
    {
        column = x;
        row = y;
        transform.position = new Vector2(x, y);
    }
}
