using UnityEngine;
using UnityEngine.UI;

public class GameManager_order : MonoBehaviour
{
    public GameObject[] customers;
<<<<<<< HEAD
    public GameObject orderbox_prefab;
    public Button okButton_prefab;
=======
    public Transform spawnPoint;
    private GameObject obj;
>>>>>>> 927c0af (commit reset to e68490d)

    public Vector2 spawnPoint_customer;
    public Vector2 spawnPoint_orderbox;
    public Vector2 spawnPoint_okbutton;

    private GameObject customer; //�� ��ü
    private GameObject orderbox; //��ȭ ����
    private Button okButton;     //���� ��ư



    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow)) //���� ���� ȭ��ǥ ���� ���� ���� | �� �� �Ϸ� �Ǹ� ��ü ����
        {
<<<<<<< HEAD
            //customer �����̱� �ֱ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            customer = Instantiate(customers[0], spawnPoint_customer, Quaternion.identity); //ĳ���� ����
            orderbox = Instantiate(orderbox_prefab, spawnPoint_orderbox, Quaternion.identity); //��ȭ���� ����
            okButton = Instantiate(okButton_prefab, spawnPoint_okbutton, Quaternion.identity, GameObject.Find("Canvas").transform); //������ư ����

            orderbox.GetComponent<Orderbox>().setText(customer.GetComponent<Customer>().comment[0]); //��ȭ���� �ֹ� �ؽ�Ʈ
            
=======
            //customer �����̱� �ֱ�
            obj = Instantiate(customers[0], spawnPoint.position, spawnPoint.rotation);
            orderText.text = obj.GetComponent<Customer>().comment[0];
            textBox.transform.position = new Vector2(textBox.transform.position.x, textBox.transform.position.y + 1000);
            okButton.transform.position = new Vector2(okButton.transform.position.x, okButton.transform.position.y + 1000);
>>>>>>> 927c0af (commit reset to e68490d)

        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //�Ʒ��� ȭ��ǥ ���� �������� -1�� �ƴϸ� ���׼� �� ��ü ����
        {
            //�����ʸ��� ���� ��� ���
            GameObject.Find("��(Clone)").GetComponent<Customer>().Reaction(10);

            GameObject.Find("��ȭ����(Clone)").GetComponent<Orderbox>().setText(GameObject.Find("��(Clone)").GetComponent<Customer>().getNowComment());
            Invoke("DestroyOderbox", 1.1f);
            
        }
    }

    void DestroyOderbox()
    {
        Destroy(GameObject.Find("��ȭ����(Clone)"));
        
    }


}