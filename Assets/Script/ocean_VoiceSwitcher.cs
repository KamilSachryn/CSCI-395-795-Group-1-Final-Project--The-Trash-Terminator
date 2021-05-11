using UnityEngine;
using Google.XR.Cardboard;
using System.Collections.Generic;
using System;
using System.Linq;
using static SpeechRecognizerPlugin;
using UnityEngine.UI;

public class ocean_VoiceSwitcher : MonoBehaviour, ISpeechRecognizerPlugin
{
    private SpeechRecognizerPlugin speechPlugin = null;
   // public Text scoreText = null;

    private bool listening = false;

    bool continious = false;
    String[] blueList = { "Blue", "recycle", "recycling" , "steel", "metal", "barrel", "barrels", "plastic", "plastics", "bottle", "bottles"};
    String[] blackList = { "black", "trash", "garbage", "organic", "organics" };
    String[] greenList = { "green", "paper" , "cardboard", "papers"};
    public AudioSource pingSound;
    public AudioSource pongSound;




    private int selectedBin = 0;
    // Start is called before the first frame update
    void Start()
    {
        blueList = blueList.Select(x => x.ToLower()).ToArray();
        blackList = blackList.Select(x => x.ToLower()).ToArray();
        greenList = greenList.Select(x => x.ToLower()).ToArray();

                speechPlugin = SpeechRecognizerPlugin.GetPlatformPluginVersion("SpeechRecognizer");
                speechPlugin.SetContinuousListening(continious);
                speechPlugin.SetLanguageForNextRecognition("en-US");
                speechPlugin.SetMaxResultsForNextRecognition(10);
              //  speechPlugin.StartListening();


        SelectBin();

        Debug.Log("Started voice switcher");

    }

    void Update()
    {

        if (Input.touchCount > 0)
        {

            speechPlugin.StartListening();
            pingSound.Play();





        }
    }

    private void Green()
    {
        selectedBin = 1;
        SelectBin();
    }
    private void Blue()
    {
        selectedBin = 2;
        SelectBin();
    }

    private void Black()
    {
        selectedBin = 0;
        SelectBin();
    }



    void SelectBin()
    {
        int i = 0;
        foreach (Transform bin in transform)
        {
            if (i == selectedBin)
                bin.gameObject.SetActive(true);
            else
                bin.gameObject.SetActive(false);
            i++;
        }
    }

    public void OnResult(string recognizedResult)
    {
        char[] delimiterChars = { '~' };
        string[] result = recognizedResult.Split(delimiterChars);

        result = result.Select(x => x.ToLower()).ToArray();
        //scoreText.text = result[0];



        //if (result.Contains<string>("blue"))
        if(result.Intersect(blueList).Any())
        {
            Blue();
        }
        else if (result.Intersect(blackList).Any())
        {
            Black();
        }
        else if (result.Intersect(greenList).Any())
        {
            Green();
        }

        pongSound.Play();
    }

    public void OnError(string recognizedError)
    {
        ERROR error = (ERROR)int.Parse(recognizedError);
        switch (error)
        {
            case ERROR.UNKNOWN:
                Debug.Log("<b>ERROR: </b> Unknown");
                break;
            case ERROR.INVALID_LANGUAGE_FORMAT:
                Debug.Log("<b>ERROR: </b> Language format is not valid");
                break;
            default:
                break;
        }
    }
}
