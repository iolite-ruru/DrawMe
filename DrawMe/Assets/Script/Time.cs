using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time : MonoBehaviour
{
    public Text time;
    public Image icon_time;
    public static Stopwatch watch;

    public Sprite moon;

    int minutes;
    int seconds;

    private void Awake()
    {

        watch = new Stopwatch();
        minutes = 0;
    }

    void Update()
    {
        //minutes = (int)watch.ElapsedMilliseconds / 60000;
        seconds = (int)watch.ElapsedMilliseconds / 1000; //��
        time.text = string.Format("{0:00}", minutes) + " : " + string.Format("{0:00}", seconds);
        if (seconds >= 60)
        {
            minutes++;
            watch.Restart();
        }
        if (minutes == 2) watch.Stop();
        if (minutes >= 1)
        {
            if (seconds % 2 == 0) time.color = Color.red;
            else time.color = Color.white;
        }
        if (minutes >= 2 && Customer.object_is_destory) //6�� �Ǹ� ���� ����
        {
            //UnityEngine.Debug.Log("������ ȣ��");
            watch.Stop();
            watch.Reset();
            DontDestroy.destroy = true;
            //���� ȿ��
            SceneManager.LoadScene("SceneEnding");

        }
    }
}
