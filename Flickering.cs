using UnityEngine;
using System.Collections;

public class Flickering : MonoBehaviour
{
    [SerializeField] GameObject flicker1;
    [SerializeField] GameObject flicker2;
    [SerializeField] GameObject flicker3;
    [SerializeField] GameObject flicker4;
    [SerializeField] GameObject flicker5;
    // Update is called once per frame
    void Start()
    {
        if (flicker1 != null && flicker2 != null && flicker3 != null && flicker4 != null && flicker5 != null)
        {
            StartCoroutine(Flicker());
        }
        else
        {
            Debug.LogError("Flicker Target is not assigned in the Inspector!");
        }
    }
    IEnumerator Flicker()
    {
        while (true) 
        {
            flicker1.SetActive(false);
            flicker2.SetActive(false);
            flicker3.SetActive(false);
            flicker4.SetActive(false);
            flicker5.SetActive(true);
            yield return new WaitForSeconds(2f);
            flicker1.SetActive(true);
            flicker2.SetActive(true);
            flicker3.SetActive(true);
            flicker4.SetActive(true);
            flicker5.SetActive(false);
            yield return new WaitForSeconds(2f);
        }
    }
}
