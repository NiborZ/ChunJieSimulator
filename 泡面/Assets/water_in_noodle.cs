using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_in_noodle : MonoBehaviour
{
    private int HP = 4;
    private Transform[] children;
    public float protect_interval = 1.5f;
    private int protected_mode = 0;
    private float clock = 0.0f;
    private float water_clock = 0.0f;
    public GameObject splashed_water;
    public float water_lifespan = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        water_clock += Time.deltaTime;
        if (water_clock >= water_lifespan)
        {
            GameObject.Find("Splashed_water").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Splashed_water (1)").GetComponent<Renderer>().enabled = false;
            water_clock = 0.0f;
        }
        if (protected_mode == 1)
        {
            clock += Time.deltaTime;
            if(clock >= protect_interval)
            {
                protected_mode = 0;
                clock = 0.0f;
            }
        }
        int index = 0;
        Transform child;
        if (Mathf.Abs(this.gameObject.transform.position.x - GameObject.Find("Instant_noodle").transform.position.x) >= 20.5f && protected_mode == 0) // Water Splashed
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Hot_water_long").GetComponent<Renderer>().enabled = true;

            for (index = 0; index < 4; index++)
            {
                child = this.gameObject.transform.GetChild(index);
                //Debug.Log(child.position.x);
                if (child.gameObject.GetComponent<Renderer>().isVisible == false)
                {
                    //Instantiate(splashed_water, new Vector3(this.gameObject.transform.position.x, -68.0f, 0), new Quaternion(0, 0, 0, 0));
                    //Destroy(splashed_water, water_lifespan);
                    //splashed_water.GetComponent<Renderer>().enabled = false;
                    child.gameObject.GetComponent<Renderer>().enabled = true;
                    protected_mode = 1;

                    break;
                }
            }
        }
        else
        {
            ;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;
        GameObject.Find("Hot_water_long").GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(this.gameObject.transform.position.x < GameObject.Find("Instant_noodle").transform.position.x) 
        {
            GameObject.Find("Splashed_water").GetComponent<Renderer>().enabled = true;

        }
        else
        {
            GameObject.Find("Splashed_water (1)").GetComponent<Renderer>().enabled = true;

        }
    }

}
