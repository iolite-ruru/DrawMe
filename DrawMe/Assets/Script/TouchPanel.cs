using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchPanel : MonoBehaviour
{
    public Text text;

    string[] storys = { 
                "�������� �������� ��� �ִ��� ��� 5��°...",
                "�� ������ �ʹ� ������ �����ϴ�..",
                "���� �̺��� ���� ������ �����ϰ� ��� �ʹ�!",
                "���� ������ �ִ°� �׸��׸��� ��ɻ�...",
                "�׸��� �ȾƼ� �� �� ���� ��ƾ߰ھ�!"
                        };
    int i;

    private void Start()
    {
        i = 0;
        text.text = storys[i++];
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (i >= storys.Length)
                SceneManager.LoadScene("SceneGameCustomer");
            else
                text.text = storys[i++];
        }
    }
}
