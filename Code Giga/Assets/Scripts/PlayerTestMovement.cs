using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;
    [SerializeField] private Animator _anim;
    private WallCheck _check;
    private float _playerYRot = 0f;

    private void Start()
    {
        _check = GetComponent<WallCheck>();
    }
    private void Update()
    {
        TestMove();
    }
    private void TestMove()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (_check._wallCheck[0] && Input.GetKeyDown(KeyCode.W))
        {
            _anim.SetTrigger("Jump");
            Instantiate(_splashEffect, transform.position, Quaternion.identity);
            return;
        }
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            _anim.SetTrigger("Jump");
            _playerYRot -= 90f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Jump");
            _playerYRot += 90f;
        }

        if (Input.GetKeyDown(KeyCode.W) && !_check._wallCheck[0])
        {
            _anim.SetTrigger("Jump");
            dir = new Vector3(0, 0, 1);
            Instantiate(_splashEffect, transform.position, Quaternion.identity);
        }

        transform.rotation = Quaternion.Euler(0f, _playerYRot, 0f);
        transform.Translate(dir);
    }

}
