using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuInformation : MonoBehaviour
{

    public GameObject DifficultyToggles; 
    public GameObject colorToggles; 

    //Go to Play Game of Main Menu
    public void startButton()
	{
        
        
        if(GameValues.Difficulty == GameValues.Difficulties.Easy && GameValues.color == GameValues.SpawnColors.Red)
        {
            SceneManager.LoadScene("GamePlay_EasyRed");
        }
        else if(GameValues.Difficulty == GameValues.Difficulties.Easy && GameValues.color == GameValues.SpawnColors.Green)
        {
            SceneManager.LoadScene("GamePlay_EasyGreen");
        }
        else if(GameValues.Difficulty == GameValues.Difficulties.Easy && GameValues.color == GameValues.SpawnColors.Blue)
        {
            SceneManager.LoadScene("GamePlay_EasyBlue");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Medium && GameValues.color == GameValues.SpawnColors.Red)
        {
            SceneManager.LoadScene("GamePlay_MediumRed");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Medium && GameValues.color == GameValues.SpawnColors.Green)
        {
            SceneManager.LoadScene("GamePlay_MediumGreen");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Medium && GameValues.color == GameValues.SpawnColors.Blue)
        {
            SceneManager.LoadScene("GamePlay_MediumBlue");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Hard && GameValues.color == GameValues.SpawnColors.Red)
        {
            SceneManager.LoadScene("GamePlay_HardRed");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Hard && GameValues.color == GameValues.SpawnColors.Green)
        {
            SceneManager.LoadScene("GamePlay_HardGreen");
        }
        else if (GameValues.Difficulty == GameValues.Difficulties.Hard && GameValues.color == GameValues.SpawnColors.Blue)
        {
            SceneManager.LoadScene("GamePlay_HardBlue");
        }
        else
        {
            SceneManager.LoadScene("GamePlay_EasyRed"); //By Default just play Easy with a Red Spawn Point then. 
        }
        //SceneManager.LoadScene("GamePlay_Easy");

        DifficultyToggles.transform.GetChild((int)GameValues.Difficulty).GetComponent<Toggle>().isOn = true;
        colorToggles.transform.GetChild((int)GameValues.color).GetComponent<Toggle>().isOn = true;
        
        
	}

    //Go to Scene Roll Character of Main Menu
    public void createCharButton()
	{
        SceneManager.LoadScene("Scene_Roll_Character");

	}
    //Go to About Section of Main Menu
    public void aboutButton()
    {
        SceneManager.LoadScene("AboutScene");

    }

    public void settingsButton()
    {
        SceneManager.LoadScene("SettingsScene");

    }

    public void instructionsButton()
    {
        SceneManager.LoadScene("Instructions");

    }

    //Quits the Game. 
    public void quitButton()
	{
#if UNITY_EDITOR 
    UnityEditor.EditorApplication.ExitPlaymode();
#else
    Debug.Log("QUIT");
    Application.Quit();
#endif
	}

    //Back button 
    public void backButton()
    {
        SceneManager.LoadScene("MainMenu");
            
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu"); 

    }

    //For the Difficulty Levels. 
    public void SetEasyDifficulty(bool isOn)
    {
        if (isOn)
        {
            GameValues.Difficulty = GameValues.Difficulties.Easy;
        }
    }

    public void SetMediumDifficulty(bool isOn)
    {
        if (isOn)
        {
            GameValues.Difficulty = GameValues.Difficulties.Medium;
        }
    }

    public void SetHardDifficulty(bool isOn)
    {
        if (isOn)
        {
            GameValues.Difficulty = GameValues.Difficulties.Hard;
        }
    }



    //For the Spawning Point Colors
    public void SetRedSpawn(bool isOn)
    {
        if (isOn)
        {
            GameValues.color = GameValues.SpawnColors.Red;
        }
    }

    public void SetGreenSpawn(bool isOn)
    {
        if (isOn)
        {
            GameValues.color = GameValues.SpawnColors.Green;
        }
    }

    public void SetBlueSpawn(bool isOn)
    {
        if (isOn)
        {
            GameValues.color = GameValues.SpawnColors.Blue;
        }
    }



}
