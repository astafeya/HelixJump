using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public GameObject Lavel;
    public Slider Slider;

    private float _startY;
    private float _minimumReachedY;
    private float _finishTransformY;
    void Start()
    {
        _startY = Player.transform.position.y;
        _minimumReachedY = _startY;
        GameObject finish = GameObject.Find("Finish Platform");
        _finishTransformY = finish.transform.position.y;
    }

    void Update()
    {
        _minimumReachedY = Mathf.Min(_minimumReachedY, Player.transform.position.y);
        float t = Mathf.InverseLerp(_startY, _finishTransformY, _minimumReachedY);
        Slider.value = t;
    }
}
