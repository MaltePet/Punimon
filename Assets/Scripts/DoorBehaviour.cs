using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private string _houseSceneId = "House_1";
    
    public void OpenScene()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync(_houseSceneId, LoadSceneMode.Additive);
    }
}
