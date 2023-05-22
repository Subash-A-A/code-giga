using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    [SerializeField] private float _yPos = 0.5f;
    private Vector3 _pos;

    private void Start()
    {
        _pos = new Vector3(0, _yPos, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _pos += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _pos += new Vector3(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _pos += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _pos += new Vector3(1, 0, 0);
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, _pos, 10 * Time.deltaTime);
    }
    
}
