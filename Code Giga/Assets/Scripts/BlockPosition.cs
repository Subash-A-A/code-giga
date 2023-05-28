using UnityEngine;

public class BlockPosition : MonoBehaviour
{
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private GameObject _emptyBlock;
    [SerializeField] private int _blocksPerRow = 9;
    [SerializeField] private int _blocksPerCol = 7;

    public void UpdateBlockPositions()
    {   
        float currentZ = 4;
        float currentX = -4;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 pos = new Vector3(currentX, 0, currentZ);
            child.localPosition = pos;

            currentX += 1;

            if(currentX > 4)
            {
                currentX = -4;
            }

            if ((i + 1) % 9 == 0)
            {
                currentZ -= 1;
            }
        }
    }
    public void SpawnBlock(int i)
    {   
        if(transform.childCount >= _blocksPerRow * _blocksPerCol)
        {
            Debug.Log("Full!");
            return;
        }
        GameObject block = Instantiate(_blocks[i], transform);
        block.name = i + "";
        UpdateBlockPositions();
    }

    public void ResetBlocks()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        Instantiate(_emptyBlock, transform);
        UpdateBlockPositions();
    }
}
