using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "Type 'menu' to return to main menu.";
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome back Mr. Bond.");
            Terminal.WriteLine(menuHint);
        }
        else
        {
            Terminal.WriteLine("Unrecognized network level.\n");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        int passIndex;

        switch (level)
        {
            case 1:
                passIndex = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[passIndex];
                break;
            case 2:
                passIndex = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[passIndex];
                break;
            case 3:
                passIndex = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[passIndex];
                break;
            default:
                Debug.LogError("Invalid Level Number!");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
            Terminal.WriteLine("Sorry, wrong password. Try again.");
        }
    }

    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Suspect Identified!");
                Terminal.WriteLine(@"
      ////^\\\\
      | ^   ^ |
     @ (o) (o) @
      |   <   |
      |  ___  |
       \_____/"
                );
                break;
            case 2:
                Terminal.WriteLine("Fighter Jets Deployed!");
                Terminal.WriteLine(@"
      \   /            \   /
 .____-/.\-____.  .____-/.\-____.
      ~`-'~            ~`-'~
                           
                ");
                break;
            case 3:
                Terminal.WriteLine("Blast Off!");
                Terminal.WriteLine(@" 
   /\
  |N |
  |A |
  |S |
  |A |
 |____|
  '-`'
 '-`'-;' 
;'.;' .;"
                );
                break;
        }
    }

}

