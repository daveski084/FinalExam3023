using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour, ITimeObserver
{

    public enum season
    {
       SPRING,
       SUMMER,
       AUTUMN,
       WINTER
    }

    public season currSeason;
    public Text seasonText;
    public GameObject springPrefab;
    public GameObject summerPrefab;
    public GameObject autumnPrefab;
    public GameObject winterPrefab;
    public AudioSource click;


    void Start()
    {
        currSeason = 0;
        click = GetComponent<AudioSource>();
        DeactivatePrefab(summerPrefab);
        DeactivatePrefab(autumnPrefab);
        DeactivatePrefab(winterPrefab);
    }
    public void ClockUpdate(TimeManager timeStamp)
    {
        ClockManager.timeInstance.ResgisterListener(this); 
    }


    public void OnLeftArrowClicked()
    {
        click.Play();
        currSeason -= 1;
        if (currSeason < 0)
            currSeason = (season)3;

        if(currSeason == 0)
        {
            ActivateSpring();
        }
        if(currSeason == (season)1)
        {
            ActivateSummer();
        }
        if(currSeason == (season)2)
        {
            ActivateAutumn();
        }
        if(currSeason == (season)3)
        {
            ActivateWinter();
        }


    }

    public void OnRightArrowClicked()
    {
        click.Play(); 
        currSeason += 1;
        if (currSeason > (season)3)
            currSeason = (season)0;

        if (currSeason == 0)
        {
            ActivateSpring();
        }
        if (currSeason == (season)1)
        {
            ActivateSummer();
        }
        if (currSeason == (season)2)
        {
            ActivateAutumn();
        }
        if (currSeason == (season)3)
        {
            ActivateWinter();
        }

    }

    void Update ()
    {
        seasonText.text = currSeason.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); 
        }
    }


    public void ActivatePrefab(GameObject prefab)
    {
        prefab.SetActive(true);
    }

    public void DeactivatePrefab(GameObject prefab)
    {
        prefab.SetActive(false);
    }

    public void ActivateSpring()
    {
        ActivatePrefab(springPrefab);
        DeactivatePrefab(summerPrefab);
        DeactivatePrefab(autumnPrefab);
        DeactivatePrefab(winterPrefab);
    }

    public void ActivateSummer()
    {
        ActivatePrefab(summerPrefab);
        DeactivatePrefab(springPrefab);
        DeactivatePrefab(autumnPrefab);
        DeactivatePrefab(winterPrefab);
    }

    public void ActivateAutumn()
    {
        ActivatePrefab(autumnPrefab);
        DeactivatePrefab(springPrefab);
        DeactivatePrefab(summerPrefab);
        DeactivatePrefab(winterPrefab);
    }

    public void ActivateWinter()
    {
        ActivatePrefab(winterPrefab);
        DeactivatePrefab(springPrefab);
        DeactivatePrefab(autumnPrefab);
        DeactivatePrefab(autumnPrefab);
    }

}
