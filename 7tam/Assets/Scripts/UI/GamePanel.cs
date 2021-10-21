using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class GamePanel : BasePanel
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _bomb;
    [SerializeField] private Image _bombImage;

    [SerializeField] private Button _up;
    [SerializeField] private Button _down;
    [SerializeField] private Button _left;
    [SerializeField] private Button _right;

    private float _cooldown = 1;
    private float _currentTime = 0;
    private bool _bombIsPlanted = false;

    private void Update()
    {
        if (_bombIsPlanted)
        {
            _currentTime += Time.deltaTime;

            _bombImage.fillAmount = _currentTime;

            if (_currentTime >= _cooldown)
            {
                _currentTime = 0;
                _bomb.gameObject.SetActive(true);
                _bombImage.gameObject.SetActive(false);
                _bombIsPlanted = false;
            }
        }
    }

    private void Awake()
    {
        _mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
        _bomb.onClick.AddListener(() => PlantBomb());

        _up.onClick.AddListener(() => EventManager.Instance.Events[EventType.Up].Invoke());
        _down.onClick.AddListener(() => EventManager.Instance.Events[EventType.Down].Invoke());
        _left.onClick.AddListener(() => EventManager.Instance.Events[EventType.Left].Invoke());
        _right.onClick.AddListener(() => EventManager.Instance.Events[EventType.Right].Invoke());
    }

    public override void Hide()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(-350, 0), 0.3f);
        gameObject.SetActive(false);
        _bombImage.gameObject.SetActive(false);
        _bomb.gameObject.SetActive(true);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.3f);
        _bomb.gameObject.SetActive(true);
        _bombImage.gameObject.SetActive(false);
    }

    public void SetMenuButton(Sprite sprite)
    {
        _mainMenu.GetComponent<Image>().sprite = sprite;
    }

    private void PlantBomb()
    {
        _bombImage.gameObject.SetActive(true);
        _bomb.gameObject.SetActive(false);
        _bombIsPlanted = true;

        EventManager.Instance.Events[EventType.PlantBomb].Invoke();
    }
}