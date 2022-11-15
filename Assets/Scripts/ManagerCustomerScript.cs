using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerCustomerScript : MonoBehaviour
{
    public SpriteRenderer[] customer;
    public Sprite[] sprite;
    private SpriteRenderer[] Table;
    public SpriteRenderer[] Table1;
    public SpriteRenderer[] Table2;
    public SpriteRenderer[] Table3;
    public SpriteRenderer[] Table4;

    private int numberFood;
    public SpriteRenderer[] FoodOnTable;
    public Sprite[] foodServed;

    private int numberPeople;
    private int spriteCustomer;
    public bool[] customerTable;
    private bool standCustomer;
    private float timeManage = 0f;
    private float timeFoods = 6f;
    public GameObject BtnCustomer;
    public GameObject[] BtnTable;

    public GameObject BtnFood;
    
    public TextMeshProUGUI moneyTxt;
    private int moneyValue;
    private int value;

    public SpriteRenderer rank;
    public Sprite[] upRank;
    private int thisRank;
    public TextMeshProUGUI rankLevelTxt;

    private float speedCustomer;

    private int lastTable = -1;

    //Setting
    private int nextMoneyRanking = 500;
    private int disCount = 20;
    void Start()
    {
        thisRank = PlayerPrefs.GetInt("Ranking", 1);
        rankLevelTxt.text = thisRank.ToString();
        rank.sprite = upRank[thisRank-1];
        moneyTxt.text = PlayerPrefs.GetInt("Money", 0).ToString();
        moneyValue = PlayerPrefs.GetInt("Money", 0);
        BtnFood.SetActive(false);
        for(int i=0; i<4; i++)
        {
            FoodOnTable[i].sprite = null;
        }
        BtnCustomer.SetActive(false);
        for(int i=0; i<4; i++)
        {
            BtnTable[i].SetActive(false);
        }
        SetCustomer();
        SpeedCustomerUp();
    }

    void Update()
    {
        timeManage+=Time.deltaTime;
        if(timeManage >= speedCustomer)
        {
            SetCustomer();
            timeManage = 0f;
            moneyValue -= disCount;        
            moneyTxt.text = moneyValue.ToString();            
        }
        /*for(int j=0; j<4; j++)
        {            
            if(customerTable[j])
            {
                if(timeManage >= speedCustomer)
                {
                    SetCustomer();
                    timeManage = 0f;
                }
            }
        }*/
        
    }

    public void Income()
    {
        for(int j=0; j<4; j++)
        {            
            if(customerTable[j])
            {
                if(j == 0) Table = Table1;
                else if(j == 1) Table = Table2;
                else if(j == 2) Table = Table3;
                else if(j == 3) Table = Table4;
                for(int i = 0; i< numberPeople; i++)
                {
                    spriteCustomer =  Random.Range(0,15);
                    Table[i].sprite = customer[i].sprite;
                    customer[i].sprite = null;
                }                
                customerTable[j] = false;
                BtnFood.SetActive(true);
                BtnCustomer.SetActive(false);
                lastTable = j;
                break;
            }
        }  
    }

    public void SetCustomer()
    {
        numberPeople = Random.Range(1,5);
        for(int i = 0; i< numberPeople; i++)
        {
            spriteCustomer =  Random.Range(0,15);
            customer[i].sprite = sprite[spriteCustomer];
        }
        BtnCustomer.SetActive(true);
    }

    public void SetTable(int nTable)
    {
        if(nTable == 0) Table = Table1;
        else if(nTable == 1) Table = Table2;
        else if(nTable == 2) Table = Table3;
        else if(nTable == 3) Table = Table4;
        for(int i=0; i<4; i++)
        {
            Table[i].sprite = null;            
        }
        //Calculate Money
        value = Random.Range(10,80);        
        moneyValue += value;        
        moneyTxt.text = moneyValue.ToString();
        PlayerPrefs.SetInt("Money", moneyValue);
        FoodOnTable[nTable].sprite = null;

        //SetRanking
        if(moneyValue >= nextMoneyRanking)
        {
            if(thisRank < 12)
            {
                moneyValue -= nextMoneyRanking;
                thisRank+=1;
            }                
            Debug.Log(thisRank);
            rank.sprite = upRank[thisRank-1];
            
            moneyTxt.text = moneyValue.ToString();
            SpeedCustomerUp();
            PlayerPrefs.SetInt("Ranking", thisRank);
            rankLevelTxt.text = thisRank.ToString();            
        }        
        customerTable[nTable] = true;
        BtnTable[nTable].SetActive(false);
    }

    public void FoodServed()
    {
        numberFood = Random.Range(0,6);
        for(int i=0; i<4; i++)
        {
            if(FoodOnTable[i].sprite == null && !customerTable[i])
            {
                FoodOnTable[i].sprite = foodServed[numberFood];
                BtnTable[i].SetActive(true);
                break;
            }
        }
    }

    public void SpeedCustomerUp()
    {
        if(thisRank == 0) speedCustomer = 2;
        else if(thisRank == 1) speedCustomer = 2;
        else if(thisRank == 2) speedCustomer = 2;
        else if(thisRank == 3) speedCustomer = 1;
        else if(thisRank == 4) speedCustomer = 1;
        else if(thisRank == 5) speedCustomer = 1;
        else if(thisRank == 6) speedCustomer = 1f;
        else if(thisRank == 7) speedCustomer = 0.75f;
        else if(thisRank == 8) speedCustomer = 0.75f;
        else speedCustomer = 0.5f;
        Debug.Log("Speed = " + speedCustomer);
    }
}
