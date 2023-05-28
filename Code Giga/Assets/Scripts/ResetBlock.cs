using UnityEngine;

public class ResetBlock : MonoBehaviour
{
    [SerializeField] private BlockPosition _codeParent;
    private bool _coderOnBlock = false;

    private void Update()
    {
        if (_coderOnBlock)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _codeParent.ResetBlocks();
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
