using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField]private Text Scoretext;

    private void Start()
    {
        
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit() 
    {
        Application.Quit();
    }

    private void Update()
    {
        SetScore();
    }
    void SetScore(){
        Scoretext.GetComponent<Text>().text = "Score: "+ player.score.ToString();
    }
}
