using UnityEngine;
using UnityEngine.UI;

public class GameManager_order : MonoBehaviour
{
    public GameObject[] customers;
    public GameObject orderbox_prefab;
    public Button okButton_prefab;

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
            //customer �����̱� �ֱ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            customer = Instantiate(customers[0], spawnPoint_customer, Quaternion.identity); //ĳ���� ����
            orderbox = Instantiate(orderbox_prefab, spawnPoint_orderbox, Quaternion.identity); //��ȭ���� ����
            okButton = Instantiate(okButton_prefab, spawnPoint_okbutton, Quaternion.identity, GameObject.Find("Canvas").transform); //������ư ����

            orderbox.GetComponent<Orderbox>().setText(customer.GetComponent<Customer>().comment[0]); //��ȭ���� �ֹ� �ؽ�Ʈ
            

        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //�Ʒ��� ȭ��ǥ ���� �������� -1�� �ƴϸ� ���׼� �� ��ü ����
        {
            customer.GetComponent<Customer>().Reaction(10);

            orderbox.GetComponent<Orderbox>().setText(customer.GetComponent<Customer>().getNowComment());
            Invoke("DestroyOderbox", 1.1f);
            
        }
    }

    void DestroyOderbox()
    {
        Destroy(orderbox);
        
    }


}