using UnityEngine;
public class WallCheck : MonoBehaviour
{
    [SerializeField] private Transform[] _wallCheckSensors;
    [SerializeField] private LayerMask _whatIsWall;
    public bool[] _wallCheck;

    private void Start()
    {
        _wallCheck = new bool[4];
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _wallCheckSensors.Length; i++)
        {
            CheckForWalls(i);
        }
    }

    private void CheckForWalls(int wallIndex)
    {
        if (Physics.CheckSphere(_wallCheckSensors[wallIndex].position, 0.1f, _whatIsWall))
        {
            _wallCheck[wallIndex] = true;
        }
        else
        {
            _wallCheck[wallIndex] = false;
        }
    }
}
