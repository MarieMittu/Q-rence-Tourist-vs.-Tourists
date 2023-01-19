using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerQueueBar : MonoBehaviour
{
    Image timerBar;
    private float maxTime = 30f;
    [SerializeField]
    public float timeLeft;

    private static TowerQueueBar _instance;

    private TowerQueueBar() { }

    public static TowerQueueBar Instance
    {
        get
        {
            if (_instance == null)
                _instance = new TowerQueueBar();

            return _instance;
        }
    }


    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            //StaminaManager.Instance.Decrease();
            Invoke("GameOver", 2f);
        }
    }

    public void Increase()
    {
        timeLeft += 2f;
        Debug.Log("Time Increase");
        if (timeLeft > maxTime)
        {
            timeLeft = maxTime;
        }
        timerBar.fillAmount = timeLeft / maxTime;
    }

    public void Decrease()
    {
        timeLeft = 0f;
    }

    public void GameOver()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}