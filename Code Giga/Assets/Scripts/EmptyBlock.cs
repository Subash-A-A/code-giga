using UnityEngine;

public class EmptyBlock : MonoBehaviour
{
    [SerializeField] private bool _coderOnEmptyBlock = false;
    private BlockPosition _codeBlockParent;
    private void Start()
    {
        _codeBlockParent = GetComponentInParent<BlockPosition>();
    }

    private void Update()
    {
        if (_coderOnEmptyBlock)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _codeBlockParent.SpawnBlock(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _codeBlockParent.SpawnBlock(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _codeBlockParent.SpawnBlock(2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coderOnEmptyBlock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coderOnEmptyBlock = false;
        }
    }
}
