using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFinder : MonoBehaviour
{
    private Board board;
    private List<GameObject> matchedBlocks = new List<GameObject>();

    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    public void FindMatches()
    {
        matchedBlocks.Clear();

        for (int x = 0; x < board.width; x++)
        {
            for (int y = 0; y < board.height; y++)
            {
                GameObject currentBlock = board.allBlocks[x, y];  // 올바른 접근 방식
                if (currentBlock != null)
                {
                    CheckMatch(currentBlock, x, y);
                }
            }
        }

        if (matchedBlocks.Count >= 4)
        {
            foreach (GameObject block in matchedBlocks)
            {
                Destroy(block);
            }
            StartCoroutine(DropBlocks());
        }
    }

    void CheckMatch(GameObject block, int x, int y)
    {
        List<GameObject> tempMatches = new List<GameObject>();

        for (int i = -1; i <= 1; i += 2)
        {
            if (x + i >= 0 && x + i < board.width)
            {
                if (board.allBlocks[x + i, y] != null && 
                    board.allBlocks[x + i, y].tag == block.tag)
                {
                    tempMatches.Add(board.allBlocks[x + i, y]);
                }
            }

            if (y + i >= 0 && y + i < board.height)
            {
                if (board.allBlocks[x, y + i] != null && 
                    board.allBlocks[x, y + i].tag == block.tag)
                {
                    tempMatches.Add(board.allBlocks[x, y + i]);
                }
            }
        }

        if (tempMatches.Count >= 3)
        {
            matchedBlocks.Add(block);
            matchedBlocks.AddRange(tempMatches);
        }
    }

    IEnumerator DropBlocks()
    {
        yield return new WaitForSeconds(0.5f);
        for (int x = 0; x < board.width; x++)
        {
            for (int y = 0; y < board.height; y++)
            {
                if (board.allBlocks[x, y] == null)
                {
                    for (int k = y; k < board.height - 1; k++)
                    {
                        board.allBlocks[x, k] = board.allBlocks[x, k + 1];
                        if (board.allBlocks[x, k] != null)
                        {
                            board.allBlocks[x, k].GetComponent<Block>().SetPosition(x, k);
                        }
                    }
                }
            }
        }
    }
}
