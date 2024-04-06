using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float passedTime;
    public float timer;
    public float maxTimer;
    public float i;
    public float lastI;
    public bool gameOver;

    [Header("FoodCourt")]
    public int foodCourt;
    public bool playerFood;
    public float foodCourtTimer;

    [Header("TruckLoading")]
    public int truckLoad;
    public bool playerTruck;
    public float truckTimer;

    [Header("Hospital")]
    public int Hospital;
    public bool playerHospital;
    public float hospitalTimer;

    [Header("References")]
    public TextMeshProUGUI m_Object;
    public TextMeshProUGUI help;
    public GameObject foodCircle;
    public GameObject truckCircle;
    public GameObject hospitalCircle;

    // Start is called before the first frame update
    void Start()
    {
        timer = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            passedTime += Time.deltaTime;
        }

        m_Object.text = passedTime.ToString("F0");
        //main
        timer += Time.deltaTime;

        if (timer > maxTimer)
        {
            if(maxTimer > 2)
            {
                maxTimer--;
            }

            timer = 0;

            lastI = i;
            i = Random.Range(1, 4);

            while(lastI == i)
                i = Random.Range(1, 4);

            Debug.Log("Random event" + i);
        }

        if (!gameOver)
        {
            //foodCourt
            if (i == foodCourt && !playerFood)
            {
                foodCourtTimer -= Time.deltaTime * 1.5f;
            }

            if (playerFood && foodCourtTimer <= 20)
            {
                foodCourtTimer += Time.deltaTime;
            }

            //Truck
            if (i == truckLoad && !playerTruck)
            {
                truckTimer -= Time.deltaTime * 1.5f;
            }

            if (playerTruck && truckTimer <= 20)
            {
                truckTimer += Time.deltaTime;
            }

            //Hospital
            if (i == Hospital && !playerHospital)
            {
                hospitalTimer -= Time.deltaTime * 1.5f;
            }

            if (playerHospital && hospitalTimer <= 20)
            {
                hospitalTimer += Time.deltaTime;
            }
        }

        //Cicles
        if (truckTimer < 5)
        {
            truckCircle.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (truckTimer > 10)
        {
            truckCircle.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (truckTimer < 10 && foodCourtTimer > 5)
        {
            truckCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (hospitalTimer < 5)
        {
            hospitalCircle.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (hospitalTimer > 10)
        {
            hospitalCircle.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (hospitalTimer < 10 && foodCourtTimer > 5)
        {
            hospitalCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (foodCourtTimer < 5)
        {
            foodCircle.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (foodCourtTimer > 10)
        {
            foodCircle.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (foodCourtTimer < 10 && foodCourtTimer > 5)
        {
            foodCircle.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        //Death
        if (hospitalTimer <= 0 || truckTimer <= 0 || foodCourtTimer <= 0)
        {
            gameOver = true;
            SceneManager.LoadScene("GameOver");
        }

        if(i == 1)
        {
            help.text = "Need Help on the Kitchen";
        }
        if (i == 2)
        {
            help.text = "Need Help on the delivery trucks";
        }
        if (i == 3)
        {
            help.text = "Need Help on the Clinic";
        }
    }
}
