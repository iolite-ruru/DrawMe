using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class imgClick : MonoBehaviour
{

    public void ImgClick()
    {
        //panel.SetActive(true);
        //Debug.Log("�̹��� Ŭ��");
        GameObject click= EventSystem.current.currentSelectedGameObject;
        //big.sprite=click.GetComponent<Image>().sprite;
    }
}
