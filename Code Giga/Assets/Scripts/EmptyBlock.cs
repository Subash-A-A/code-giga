using UnityEngine;

public class EmptyBlock : MonoBehaviour
{
    [SerializeField] private bool _coderOnEmptyBlock = false;
    [SerializeField] private GameObject _keyBindCanvas;
    [SerializeField] Animator[] _anims;
    private BlockPosition _codeBlockParent;
    private void Start()
    {
        _codeBlockParent = GetComponentInParent<BlockPosition>();
    }

    private void Update()
    {
        _keyBindCanvas.SetActive(_coderOnEmptyBlock);
        _keyBindCanvas.transform.LookAt(Camera.main.transform.position);

        if (_coderOnEmptyBlock)
        {   
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _codeBlockParent.SpawnBlock(0);
                _anims[0].SetTrigger("Selected");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _codeBlockParent.SpawnBlock(1);
                _anims[1].SetTrigger("Selected");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _codeBlockParent.SpawnBlock(2);
                _anims[2].SetTrigger("Selected");
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
