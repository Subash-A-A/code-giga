using UnityEngine;
public class SubmitBlock : MonoBehaviour
{
    [SerializeField] private PlayerTestMovement _player;
    [SerializeField] BlockPosition _codeBlockParent;
    private bool _coderOnBlock = false;
    private WorldManager _worldManager;

    private void Start()
    {
        _worldManager = FindObjectOfType<WorldManager>();
    }

    private void Update()
    {
        if (_coderOnBlock)
        {
            if (Input.GetMouseButtonDown(0) && !_player.isRunningCode)
            {
                // Camera will focus coder if param is set to false else will focus player
                _worldManager.SwitchCamera(false);
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
