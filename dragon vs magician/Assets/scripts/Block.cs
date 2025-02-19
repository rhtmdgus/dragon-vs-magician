using UnityEngine;

public class Block : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int row, col; // 블록의 위치 정보
    public Sprite[] blockSprites; // 다양한 블록 스프라이트

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomSprite();
    }

    void AssignRandomSprite()
    {
        if (blockSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, blockSprites.Length);
            spriteRenderer.sprite = blockSprites[randomIndex];
        }
    }
}
