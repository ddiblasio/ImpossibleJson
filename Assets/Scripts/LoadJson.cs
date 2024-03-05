using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class LoadJson : MonoBehaviour
{ 
    // From GIT JSON
    [Header("From GIT Data")]
    
    public DataClass dataGit;
    public string gitLetters;
    public string gitContains;
    public int playerLevel;
    
    
    //Reference to LoadLetter C# script
    [Header("All Data")]
    [SerializeField]
    public MyDataClass data;
    public string jsonResponse;
    [Header("GameObject References")]
    public TMP_Text potentialWords;
    public TMP_Text centerLetter;
    public TMP_Text[] letter;
    public TMP_Text level;
  
  
    public string filePath;
    
    

    
    void Awake()
    {
        // This will come from the WEB
        filePath = "https://raw.githubusercontent.com/ddiblasio/ImpossibleJson/main/db.json";
        StartCoroutine(GetInitialRequest());

        Debug.Log("FROM GIT " + gitLetters +" And " + gitContains);
 
        
    }
    
    void Start()
    {

        StartCoroutine(GetRequest());
      
    
       Debug.Log("FROM GIT " + gitLetters +" And " + gitContains);

       filePath = "https://fly.wordfinderapi.com/api/search?letters="+ gitLetters + "&contains="+ gitContains +"&word_sorting=points&group_by_length=true&page_size=20&dictionary=all_en";
        
        Debug.Log(""+filePath);    

        StartCoroutine(GetRequest());
        filePath = Application.persistentDataPath + "/WordList.json";
        jsonResponse = System.IO.File.ReadAllText(filePath);
        data = JsonUtility.FromJson<MyDataClass>(jsonResponse);
        
        // Populate the circles with the letters from the letter search
        potentialWords.text = data.returned_results.ToString();
        centerLetter.text = gitContains.ToUpper();
        
        for (int counter = 0; counter < gitLetters.Length; counter++)
        {
            Debug.Log("Actual Letter "+ gitLetters[counter].ToString().ToUpper());
            letter[counter].text = gitLetters[counter].ToString().ToUpper();
            
        }
        
    
    }
    void Update()
    {


    }

    IEnumerator GetInitialRequest()
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(filePath))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();
 
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                //testing player level
                playerLevel = 1;
                jsonResponse = webRequest.downloadHandler.text;
                dataGit = JsonUtility.FromJson<DataClass>(jsonResponse);
                Debug.Log("From GIT Letters " + dataGit.info[playerLevel].letters + " And Contains " + dataGit.info[playerLevel].contains);
                gitLetters = dataGit.info[playerLevel].letters;
                gitContains = dataGit.info[playerLevel].contains;
                level.text = "Level: " + dataGit.info[playerLevel].level.ToString();
                
            }
            else
            {
                // Handle the error or non-successful response
                Debug.LogError("Error: " + webRequest.result + " - " + webRequest.error);
            }
        }
    }
    // this is from LoadLetters and can be reverted.
    IEnumerator GetRequest()
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(filePath))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                
                // jsonResponse = webRequest.downloadHandler.text;
                // data = JsonUtility.FromJson<MyDataClass>(jsonResponse);
                // potentialWords.text = data.returned_results.ToString();
                // centerLetter.text = gitContains.ToUpper();
         
            
                




                //Read and parse the JSON response
                jsonResponse = webRequest.downloadHandler.text;
                string filePath = Application.persistentDataPath + "/WordList.json";
                System.IO.File.WriteAllText(filePath, jsonResponse);

                
                
            }
            else
            {
                // Handle the error or non-successful response
                Debug.LogError("Error: " + webRequest.result + " - " + webRequest.error);
            }
        }
    }
}

[System.Serializable]
public class DataClass
{
    public List<Info> info;
}
[System.Serializable]
public class Info
{

    public string letters;
    public string contains;
    public int level;
        
}

[System.Serializable]
public class MyDataClass
{
    public Request request;
    //public string letters_for_search;
    [SerializeField]
    public List<WordPage> word_pages;
    public int returned_results;
    //public string letters;
    //public string contains;
        
}
[System.Serializable]
public class Request
{
    //public string letters;
   // public string contains;
    //public string letters_for_search;
}

[System.Serializable]
public class WordPage
{
    public List<WordList> word_list;
    public int length { get; set; }
    public int num_words { get; set; }
    public int num_pages { get; set; }
    public int current_page { get; set; }
}

[System.Serializable]
public class WordList
{
    public string word;
    public int points;
    
}