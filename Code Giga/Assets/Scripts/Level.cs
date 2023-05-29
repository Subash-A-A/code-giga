using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform _rubies;
    [SerializeField] int _level = 1;
    [SerializeField] Vector3[] _rubyPos;
    public bool _completed = false;
    private PlayerTestMovement _player;
    private LevelManager _manager;

    private void OnEnable()
    {
        _completed = false;
        if(_rubies.childCount <= 0)
        {
            InitLevel();
        }
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerTestMovement>();
        _manager = GetComponentInParent<LevelManager>();
    }

    private void Update()
    {
        if(_rubies.childCount <= 0 && !_player.isRunningCode && !_completed)
        {
            _completed = true;
            Debug.Log("Level " + _level + " Completed!");
            _manager.ToNextLevel();
        }
    }

    private void InitLevel()
    {
        IntiRubies();
    }

    private void IntiRubies()
    {
        foreach(var pos in _rubyPos)
        {
            GameObject ruby = Instantiate(_manager.GetRubyGameObject(), _rubies);
            ruby.transform.position = pos;
        }
    }
}
