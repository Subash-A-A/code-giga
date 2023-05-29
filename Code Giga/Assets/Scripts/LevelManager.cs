using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _ruby;

    public int currentLevel = 1;

    public void ToNextLevel()
    {
        currentLevel++;
    }

    public GameObject GetRubyGameObject()
    {
        return _ruby;
    }
}
