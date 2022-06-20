using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum COLOR : int
{
    BLACK = 0,
    RED = 1,
    GREEN = 2,
    BLUE = 3
};*/

public class Drawing : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    public Material defaultMaterial; //���� �������� Material -> �⺻

    private List<LineRenderer> lines;
    private LineRenderer curLine; //���� �׸����ִ� ����
    private int positionCount = 2; //ó�� �����ϴ� ���� �������� �ڳ� �� ���� ����
    private Vector2 prevPos = Vector2.zero;


    [SerializeField]
    private Color lineColor;

    private float lineThickness;

    int sort=0; //���� ����

    void Start()
    {
        cam = Camera.main;
        SetColor(0);
        lineThickness = 0.1f;
        Debug.Log("����");
    }

    void Update()
    {

            Draw();
    }

    void Draw()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Camera.main.transform.forward);
        if (hit.collider == null)
             return;

        if (Input.GetMouseButtonDown(0))
        {
            //if (CheckClick(mousePos))
                CreateLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
                ConnectLine(mousePos);
        }
    }

    void CreateLine(Vector2 mousePos)
    {
        GameObject line = new GameObject("Line");
        //line.name = "Line";
        LineRenderer lineRend = line.AddComponent<LineRenderer>();
        positionCount = 2;

        line.transform.parent = cam.transform;
        line.transform.position = mousePos;

        lineRend.material = new Material(defaultMaterial);//defaultMaterial;

        //color error
        lineRend.material.color = lineColor;

        lineRend.startWidth = lineThickness;
        lineRend.endWidth = lineThickness;
        lineRend.numCornerVertices = 10;

        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
        line.GetComponent<LineRenderer>().sortingOrder = sort++;
    }

    void ConnectLine(Vector2 mousePos)
    {
        //�������� �ִٸ�
        if (prevPos != null && Mathf.Abs(Vector2.Distance(prevPos, mousePos)) >= 0.001f)
        {
            prevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }
    }

    public void SetColor(int color)
    {
        //new Color(0.5f, 0.1f, 0.8f, 1f);
        Debug.Log("SetColor: " + color);
        switch (color)
        {
            case -1:
                lineColor = Color.white;
                break;
            case 0://(int)COLOR.BLACK:
                lineColor = Color.black;
                break;
            case 1://(int)COLOR.RED:
                lineColor = new Color(0.8f, 0.25f, 0.0f, 1f);
                break;
            case 2://(int)COLOR.GREEN:
                lineColor = new Color(0.5f, 0.7f, 0.03f, 1f);
                break;
            case 3://(int)COLOR.BLUE:
                lineColor = new Color(0f, 0.4f, 1f, 1f);
                break;
            case 4://���
                lineColor = Color.yellow;
                break;
            case 5://����
                lineColor = new Color(0.7f, 0.4f, 1f, 1f);
                break;
            case 6://ȸ��
                lineColor = new Color(0.5f, 0.5f, 0.5f, 1f);
                break;
            case 7://����
                lineColor = new Color(0.6f, 0.5f, 0.3f, 1f);
                break;

        }
    }

    public void SetClear()
    {
        //lines.Clear();
        Debug.Log("SetClear ȣ��");
        LineRenderer[] temm = Transform.FindObjectsOfType<LineRenderer>();
        foreach (LineRenderer line in temm)
        {
            Destroy(line.gameObject);
        }
        //Destroy();
    }

    /// <summary>
    /// Ŭ���� ���� ĵ�������� Ȯ��
    /// </summary>
    /// <returns></returns>
    bool CheckClick(Vector2 mousePos)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos, cam.transform.forward);
        if (hit.collider != null)
        {
            GameObject obj = hit.transform.gameObject;
            Debug.Log(obj.name);
            return true;
        }
        Debug.Log("NULL");
        return false;
    }


}