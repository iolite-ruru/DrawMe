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

    public static GameObject customer; //�� ��ü
    public static GameObject orderbox; //��ȭ ����
    private Button okButton;     //���� ��ư

    public static int money;
    public static int time;

    private void Update()
    {

        if (customer==null && orderbox==null) // ���� ���� | �� �� �Ϸ� �Ǹ� ��ü ����
        {           
            int random = Random.Range(0, customers.Length); //customer �����̱�
            customer = Instantiate(customers[random], spawnPoint_customer, Quaternion.identity); //ĳ���� ����
            orderbox = Instantiate(orderbox_prefab, spawnPoint_orderbox, Quaternion.identity); //��ȭ���� ����
            okButton = Instantiate(okButton_prefab, spawnPoint_okbutton, Quaternion.identity, GameObject.Find("Canvas").transform); //������ư ����

            orderbox.GetComponent<Orderbox>().setText(customer.GetComponent<Customer>().comment[0]); //��ȭ���� �ֹ� �ؽ�Ʈ

        }
        else if (orderbox != null && Customer.satisfaction != -1) //-1�� �ƴϸ� ���׼� �� ��ü ����
        {

            customer.GetComponent<Customer>().Reaction(Customer.satisfaction);
            orderbox.GetComponent<Orderbox>().setText(customer.GetComponent<Customer>().getNowComment());
            Customer.satisfaction = -1;
            Invoke("DisappearOrderbox", 1.5f);
            Destroy(orderbox, 2f);
            
        }        
    }
    
    private void DisappearOrderbox()
    {
        orderbox.SetActive(false);
    }

}