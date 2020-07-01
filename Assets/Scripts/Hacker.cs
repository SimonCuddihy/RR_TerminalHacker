using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "password1", "password2", "password3" };
    string[] level2Passwords = { "harderPassword1", "harderPassword2", "harderPassword3" };
    string[] level3Passwords = { "hardestPassword1", "hardestPassword2", "hardestPassword3" };

    // Game state
    int level;
    string admin = "Simon";
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    

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


    void OnUserInput(string input)
    {
        if (input == "menu") // can always go direct to main menu
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ShowWinScreen();
        }
    }


    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            currentScreen = Screen.Password;
            password = level1Passwords[0];
            StartGame(level, password);
        }
        else if (input == "2")
        {
            level = 2;
            currentScreen = Screen.Password;
            password = level2Passwords[0];
            StartGame(level, password);
        }
        else if (input == "3")
        {
            level = 3;
            currentScreen = Screen.Password;
            password = level3Passwords[0];
            StartGame(level, password);
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome back Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Unrecognized network level.\n");
        }
    }

    void StartGame(int level, string password)
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine($"You have chosen level {level}.\n");
        Terminal.WriteLine("Please enter password:\n");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Please try again:");
            currentScreen = Screen.Password;
        }
    }

    void ShowWinScreen()
    {
        Terminal.WriteLine("Welcome!");
        currentScreen = Screen.Win;
    }
    //void ShowWinScreen()
    //{
    //    currentScreen = Screen.Win;
    //    Terminal.WriteLine("ACCESS GRANTED");
    //}
}

