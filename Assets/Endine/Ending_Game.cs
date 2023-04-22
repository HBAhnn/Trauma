using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Game : MonoBehaviour
{

    public GameObject FadeSystem;
    public GameObject subtitle_bar;

    GameObject[] Screens = new GameObject[4];

    GameObject ending_title;
    GameObject ending_narration;
    GameObject[] titles = new GameObject[6];
    GameObject[] narrations = new GameObject[27];

    public GameObject ending_message;

    // Start is called before the first frame update
    void Start()
    {
        ending_title = GameObject.Find("Ending_titles");
        ending_narration = GameObject.Find("Ending_narrations");
        for (int i = 0; i < 6; i++)
            titles[i] = ending_title.transform.GetChild(i).gameObject;
        for (int i = 0; i < 27; i++)
            narrations[i] = ending_narration.transform.GetChild(i).gameObject;

        for(int i = 0; i < 4; i++)
            Screens[i] = transform.GetChild(i).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Ending());
    }

    IEnumerator Ending()
    {
        //FadeSystem.GetComponent<Fade>().DoFade(2f);
        FadeSystem.GetComponent<Fade>().StopFade(2f);
        yield return new WaitForSeconds(2f);

        subtitle_bar.SetActive(true);
        titles[0].SetActive(true);

        //0 ~ 5
        narrations[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);

        narrations[1].SetActive(true);
        yield return new WaitForSeconds(2.9f);

        narrations[2].SetActive(true);
        yield return new WaitForSeconds(3.5f);
        
        narrations[3].SetActive(true);
        yield return new WaitForSeconds(7.5f);

        narrations[4].SetActive(true);
        yield return new WaitForSeconds(5.3f);

        narrations[5].SetActive(true);
        yield return new WaitForSeconds(3.5f);

        //change screen
        subtitle_bar.SetActive(false);
        titles[0].SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(1f);
        yield return new WaitForSeconds(1f);

        Screens[0].SetActive(false);
        Screens[1].SetActive(true);

        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(1f);

        subtitle_bar.SetActive(true);
        titles[1].SetActive(true);

        //6 ~ 10

        narrations[6].SetActive(true);
        yield return new WaitForSeconds(3.0f);

        narrations[7].SetActive(true);
        yield return new WaitForSeconds(3.7f);

        narrations[8].SetActive(true);
        yield return new WaitForSeconds(2.5f);

        narrations[9].SetActive(true);
        yield return new WaitForSeconds(5.5f);

        narrations[10].SetActive(true);
        yield return new WaitForSeconds(4.5f);

        //change screen
        subtitle_bar.SetActive(false);
        titles[1].SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(1f);
        yield return new WaitForSeconds(1f);

        Screens[1].SetActive(false);
        Screens[2].SetActive(true);

        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(1f);

        subtitle_bar.SetActive(true);
        titles[2].SetActive(true);

        //11 ~ 13

        narrations[11].SetActive(true);
        yield return new WaitForSeconds(4.8f);
        narrations[12].SetActive(true);
        yield return new WaitForSeconds(6.6f);
        narrations[13].SetActive(true);
        yield return new WaitForSeconds(9.5f);

        //change screen
        subtitle_bar.SetActive(false);
        titles[2].SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(1f);
        yield return new WaitForSeconds(1f);

        Screens[2].SetActive(false);
        Screens[3].SetActive(true);

        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(1f);

        subtitle_bar.SetActive(true);
        titles[3].SetActive(true);

        //14 ~ 18
        narrations[14].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        narrations[15].SetActive(true);
        yield return new WaitForSeconds(4.5f);
        narrations[16].SetActive(true);
        yield return new WaitForSeconds(3.5f);
        narrations[17].SetActive(true);
        yield return new WaitForSeconds(5.5f);
        narrations[18].SetActive(true);
        yield return new WaitForSeconds(5.5f);

        //change Screen
        subtitle_bar.SetActive(false);
        titles[3].SetActive(false);
        FadeSystem.GetComponent<Fade>().DoFade(1f);
        yield return new WaitForSeconds(1f);

        Screens[3].SetActive(false);
        Screens[0].SetActive(true);

        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(1f);

        subtitle_bar.SetActive(true);
        titles[4].SetActive(true);

        //19 ~ 22
        narrations[19].SetActive(true);
        yield return new WaitForSeconds(5.5f);
        narrations[20].SetActive(true);
        yield return new WaitForSeconds(4.5f);
        narrations[21].SetActive(true);
        yield return new WaitForSeconds(3.5f);
        narrations[22].SetActive(true);
        yield return new WaitForSeconds(4.5f);

        //change titles
        subtitle_bar.SetActive(false);
        titles[4].SetActive(false);
        yield return new WaitForSeconds(1f);

        subtitle_bar.SetActive(true);
        titles[5].SetActive(true);
        yield return new WaitForSeconds(1f);

        //23 ~ 26
        narrations[23].SetActive(true);
        yield return new WaitForSeconds(4.5f);
        narrations[24].SetActive(true);
        yield return new WaitForSeconds(3.5f);
        narrations[25].SetActive(true);
        yield return new WaitForSeconds(6.5f);
        narrations[26].SetActive(true);
        yield return new WaitForSeconds(5.5f);

        subtitle_bar.SetActive(false);
        titles[5].SetActive(false);

        FadeSystem.GetComponent<Fade>().DoFade(1f);
        yield return new WaitForSeconds(1f);

        ending_message.SetActive(true);

        FadeSystem.GetComponent<Fade>().StopFade(1f);
        yield return new WaitForSeconds(1f);

    }
}
