using UnityEngine;
using System.Collections;

public class PlayerTestMovement : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _executionDelay = 0.5f;
    [SerializeField] private Transform _codeBlockParent;
    [SerializeField] private LevelManager _levelManager;
    
    public bool isRunningCode = false;

    private WallCheck _check;
    private float _playerYRot = 0f;
    private AudioSource _audio;

    private void Start()
    {
        _check = GetComponent<WallCheck>();
        _levelManager = FindObjectOfType<LevelManager>();
        _audio = GetComponent<AudioSource>();
    }
 
    public void TestMove()
    {
        isRunningCode = true;
        StartCoroutine(ExecuteMoves(1));
    }

    public void MoveForward()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (_check._wallCheck[0])
        {
            return;
        }
        if (!_check._wallCheck[0])
        {
            dir = new Vector3(0, 0, 1);
        }
        PlayPop();
        _anim.SetTrigger("Jump");
        Instantiate(_splashEffect, transform.position, Quaternion.identity);
        transform.Translate(dir);
    }

    public void TurnLeft()
    {
        _anim.SetTrigger("Jump");
        _playerYRot -= 90f;
        transform.rotation = Quaternion.Euler(0f, _playerYRot, 0f);
        Instantiate(_splashEffect, transform.position, Quaternion.identity);
        PlayPop();
    }

    public void TurnRight()
    {
        _anim.SetTrigger("Jump");
        _playerYRot += 90f;
        transform.rotation = Quaternion.Euler(0f, _playerYRot, 0f);
        Instantiate(_splashEffect, transform.position, Quaternion.identity);
        PlayPop();
    }

    public void Move(string id)
    {
        switch (id)
        {
            case "0":
                MoveForward();
                break;
            case "1":
                TurnLeft();
                break;
            case "2":
                TurnRight();
                break;
            default:
                break;
        }
    }

    IEnumerator ExecuteMoves(int i)
    {
        if(i <= 1)
        {
            // This is just to prevent the player to execute the instruction immediately.
            // 2s is for the world to switch.
            yield return new WaitForSeconds(2f);
        }

        if(i < _codeBlockParent.childCount)
        {
            Move(_codeBlockParent.GetChild(i).name);
            yield return new WaitForSeconds(_executionDelay);
            StartCoroutine(ExecuteMoves(i + 1));
        }
        else
        {
            yield return new WaitForSeconds(0);
            _codeBlockParent.GetComponent<BlockPosition>().ResetBlocks();
            isRunningCode = false;
            _levelManager.CheckWinCondition();
        }
    }

    public void ResetRotation()
    {
        _playerYRot = 0;
    }

    private void PlayPop()
    {
        if (!_audio.isPlaying)
        {
            _audio.Play();
        }
    }
}
