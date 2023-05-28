using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private bool _coderOnBlock = false;
    private BlockPosition _codeParent;

    private void Start()
    {
        _codeParent = GetComponentInParent<BlockPosition>();
    }

    private void Update()
    {
        if (_coderOnBlock)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent = null;
                _codeParent.UpdateBlockPositions();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coderOnBlock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coderOnBlock = false;
        }
    }
}
