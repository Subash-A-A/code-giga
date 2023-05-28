using UnityEngine;

public class SubmitBlock : MonoBehaviour
{
    [SerializeField] private PlayerTestMovement _player;
    private bool _coderOnBlock = false;

    private void Update()
    {
        if (_coderOnBlock)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _player.TestMove();
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
