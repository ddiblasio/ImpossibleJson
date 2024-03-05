using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoadLetters : MonoBehaviour
{
    
}
//     [Header("From GIT Data")]
//     [SerializeField]
//     public DataClass dataGit;
//     public string jsonResponse;
//     public string filePath;
//     public string gitLetters;
//     public string gitContains;


//     void Start()
//     {

//         // This will come from the WEB
//        filePath = "https://raw.githubusercontent.com/ddiblasio/ImpossibleJson/main/db.json";
//        StartCoroutine(GetRequest());
        
//     }

// IEnumerator GetRequest()
//     {
        
//         using (UnityWebRequest webRequest = UnityWebRequest.Get(filePath))
//         {
//             // Send the request and wait for a response
//             yield return webRequest.SendWebRequest();

//             if (webRequest.result == UnityWebRequest.Result.Success)
//             {
                
//                 // Read and parse the JSON response
//                 jsonResponse = webRequest.downloadHandler.text;
//                 data = JsonUtility.FromJson<DataClass>(jsonResponse);
//                 Debug.Log("From GIT Letters " + dataGit.letters + " And Contains " + dataGit.contains);
//                 gitLetters = dataGit.letters;
//                 gitContains = dataGit.contains;
                
//             }
//             else
//             {
//                 // Handle the error or non-successful response
//                 Debug.LogError("Error: " + webRequest.result + " - " + webRequest.error);
//             }
//         }
//     }
// }

// [System.Serializable]
// public class DataClass
// {

//         public string letters;
//         public string contains;
        
// }