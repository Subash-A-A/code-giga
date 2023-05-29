using UnityEngine;

public class Ruby : MonoBehaviour
{
    [SerializeField] private GameObject _rubySplash;
    private void Start()
    {   
        int scaleX = Random.value > 0.5 ? 1 : -1;
        int scaleZ = Random.value > 0.5 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1f, scaleZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            Instantiate(_rubySplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
