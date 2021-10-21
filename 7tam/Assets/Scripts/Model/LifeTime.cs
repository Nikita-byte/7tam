using UnityEngine;


public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private ObjectType _objectType;
    private float _currentTime = 0;
    private bool _isActive;

    private void Start()
    {
        _currentTime = 0;
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _lifeTime)
            {
                _isActive = false;
                _currentTime = 0;
                ObjectPool.Instance.ReturnInPool(_objectType, gameObject);
            }
        }
    }
}
