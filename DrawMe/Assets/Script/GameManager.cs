using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Camera cam;

    public Drawing drawingManager;
    private string savePath;
    private string fileName;

    void Start()
    {
        cam = Camera.main;
        savePath = Application.dataPath + "/ScreenShots/";

        //ȭ�� �ػ� ����
        int setWidth = 1920;
        int setHeight = 1080;
        Screen.SetResolution(setWidth, setHeight, true);  //true:Ǯ��ũ��, false:â
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }

    public void OnColor(int color)
    {
        drawingManager.SetColor(color);
    }

    public void OnClickComplete()
    {
        Capture();
        Customer.satisfaction = 10; //���߿� �� ���� ������ ����
        drawingManager.SetClear();
    }

    private void Capture()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam.targetTexture = renderTexture;

        Texture2D screenShot = new Texture2D(750, 800, TextureFormat.RGB24, false);
        //cam.Render();
        RenderTexture.active = renderTexture;

        Rect area = new Rect(950, 540, 750, 800); //ĸ���� ���� ����
        //Rect area = new Rect(0f, 0f, Screen.width, Screen.height);
        screenShot.ReadPixels(area, 0, 0);
        screenShot.Apply();

        try
        {
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }
            fileName = savePath + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

            File.WriteAllBytes(fileName, screenShot.EncodeToPNG()); //����

        }
        catch (Exception e)
        {
            Debug.Log("capture error");
            Debug.Log(e);
        }

        //Destroy(screenShot);
    }

    private IEnumerator ScreenShotRoutine()
    {
        yield return new WaitForEndOfFrame();
    }
}