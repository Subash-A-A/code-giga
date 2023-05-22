using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    [SerializeField] private float _yPos = 0.5f;
    [SerializeField] private GameObject _splashEffect;
    private Vector3 _pos;
    private Animator _animator;
    private WallCheck _check;

    private void Start()
    {
        _pos = new Vector3(0, _yPos, 0);
        _animator = GetComponent<Animator>();
        _check = GetComponent<WallCheck>();
    }

    private void Update()
    {

        TestMove();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, _pos, 10 * Time.deltaTime);
    }

    private void TestMove()
    {
        if ((_check._wallCheck[0] && Input.GetKeyDown(KeyCode.U)) ||
            (_check._wallCheck[1] && Input.GetKeyDown(KeyCode.J)) ||
            (_check._wallCheck[2] && Input.GetKeyDown(KeyCode.H)) ||
            (_check._wallCheck[3] && Input.GetKeyDown(KeyCode.K))
            )
        {
            _animator.SetTrigger("Jump");
            Instantiate(_splashEffect, transform.position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.U) && !_check._wallCheck[0])
        {
            _pos += new Vector3(0, 0, 1);
            _animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.J) && !_check._wallCheck[1])
        {
            _pos += new Vector3(0, 0, -1);
            _animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.H) && !_check._wallCheck[2])
        {
            _pos += new Vector3(-1, 0, 0);
            _animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.K) && !_check._wallCheck[3])
        {
            _pos += new Vector3(1, 0, 0);
            _animator.SetTrigger("Jump");
        }
    }
    
}
