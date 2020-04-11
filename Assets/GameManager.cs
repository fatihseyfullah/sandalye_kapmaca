using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float period;
    public InputField inputField;
    private bool isPlaying;
    private bool isPaused;
    private AudioSource audioSource;
    private float nextStopTime=0f;
    float nextTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        period = 0f;
        isPlaying = false;
        isPaused = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    void Update()
    {
        if (period > 0f && Time.time>nextStopTime)
        {
            if (isPaused)
            {
                audioSource.Pause();
                isPlaying = true;
                isPaused = false;
                nextStopTime = Time.time + 6f;
                Debug.Log("******isPaused******period=>" + period + ";nextStopTime=>" + nextStopTime + ";Time.time=>" + Time.time + ";nextTime=>" + nextTime);
            }
            else if( !isPlaying)
            {
                audioSource.Play(0);
                isPlaying = true;
                isPaused = false;
                nextTime = Random.Range(period / 2, period);
                nextStopTime = nextStopTime + nextTime;
                Debug.Log("******!!!!!isPlaying******period=>" + period + ";nextStopTime=>" + nextStopTime + ";Time.time=>" + Time.time+ ";nextTime=>"+nextTime);
            }
            else if(isPlaying)
            {
                audioSource.UnPause();
                isPlaying = true;
                isPaused = true;
                nextTime = Random.Range(period / 2, period);
                nextStopTime = nextStopTime + nextTime;
                Debug.Log("******isPlaying******period=>" + period + ";nextStopTime=>" + nextStopTime + ";Time.time=>" + Time.time + ";nextTime=>" + nextTime);
            }

        }
    }

    public void savePeriod()
    {
        try
        {
            period = float.Parse(inputField.text);
        }
        catch (System.Exception ex)
        {
            period = 0f;
            Debug.Log(ex.ToString());
        }
        Debug.Log("New period Value=>"+period);
    }
}