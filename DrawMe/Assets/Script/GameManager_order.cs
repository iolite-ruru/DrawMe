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

    public Text moneyText;
    public static int money = 0;

    private void Update()
    {

        if (customer==null && orderbox==null) // ���� ���� | �� �� �Ϸ� �Ǹ� ��ü ����
        {           
            int random = Random.Range(0, customers.Length); //customer �����̱�
            customer = Instantiate(customers[random], spawnPoint_customer, Quaternion.identity); //ĳ���� ����
            orderbox = Instantiate(orderbox_prefab, spawnPoint_orderbox, Quaternion.identity); //��ȭ���� ����
            Instantiate(okButton_prefab, spawnPoint_okbutton, Quaternion.identity, GameObject.Find("Canvas").transform); //������ư ����
            Customer.object_is_destory = false;
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

    private void Awake()
    {
        Time.watch.Start();
    }
    private void DisappearOrderbox()
    {
        orderbox.SetActive(false);
        Customer.object_is_destory = true;
    }

}