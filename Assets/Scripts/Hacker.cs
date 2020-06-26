using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    string admin = "Simon";
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void  ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("######### RESTRICTED ACCESS ##########\n");
        Terminal.WriteLine("Defense Networks Core\n");
        Terminal.WriteLine($"User: {admin}\n");
        Terminal.WriteLine("Select Dept. you wish to access:");
        Terminal.WriteLine("Enter '1' to enter Police Network.");
        Terminal.WriteLine("Enter '2' to enter Military Network.");
        Terminal.WriteLine("Enter '3' to enter Deep Space Network.\n");
    }


    void OnUserInput(string inputString)
    {
        if (inputString == "menu") // can always go direct to main menu
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else
        {
            RunMainMenu(inputString);
        }
}

    void RunMainMenu(string inputString)
    {
        if (inputString == "1")
        {
            level = 1;
            StartGame(1);
        }
        else if (inputString == "2")
        {
            level = 2;
            StartGame(2);
        }
        else if (inputString == "3")
        {
            level = 3;
            StartGame(3);
        }
        else if (inputString == "007")
        {
            Terminal.WriteLine("Welcome back Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Unrecognized network level.\nPlease enter the correct level.\n");
        }
    }

    void StartGame(int level)
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine($"You have chosen level {level}.\n");
        Terminal.WriteLine("Please enter password.\n");
    }

}

