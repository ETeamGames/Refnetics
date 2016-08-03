using UnityEngine;
using System.Collections;

public class ClampTime
{
    private float startValue, endValue;
    private float startTime,effectTime;
    private bool isEnd;
    public bool IsEnd
    {
        get
        {
            return isEnd;
        }
        private set
        {
            isEnd = value;
        }
    }
    public float StartValue { set { startValue = value; } get { return startValue; } }
    public float EndValue { set { endValue = value; } get { return endValue; } }
    public float StartTime { set { startTime = value; } get { return startTime; } }
    public float EffectTime
    {
        set
        {
            effectTime = value;
            if (effectTime <= 0)
                isEnd = true;
        }
        get
        {
            return effectTime;
        }
    }

    public ClampTime()
    {
        isEnd = false;
    }

    void reset()
    {
        isEnd = false;
    }

    public float value(float time)
    {
        if (isEnd)
            return endValue;
        return startValue + (endValue - startValue) * Mathf.Clamp01((time-startTime)/effectTime);
    }
}

public class TestCubeScript : MonoBehaviour {
    public float time = 1f;
    public string PathName = "Path1";
    public bool stopFlag = false;
    public float speed;
    private ClampTime speedEffect;
    private float timeBuffer = 0;

    void Start()
    {
        speedEffect = new ClampTime();
        speedEffect.EffectTime = 0;
    }

    void FixedUpdate()
    {
        

        if (!stopFlag)
        {
            speed = speedEffect.value(Time.time);
            timeBuffer += Time.fixedDeltaTime * speed;
            iTween.PutOnPath(gameObject, iTweenPath.GetPath(PathName), Mathf.Clamp(timeBuffer / time, 0, 1));
        }
    }

    void Update()
    {
    }

    public void stop()
    {
        stopFlag = true;
    }
    public void start()
    {
        stopFlag = false;
    }
    public void speedChange(float speed, float effectTime)
    {
        speedEffect.StartValue = this.speed;
        speedEffect.EndValue = speed;
        speedEffect.StartTime = Time.time;
        speedEffect.EffectTime = effectTime;
    }
}
