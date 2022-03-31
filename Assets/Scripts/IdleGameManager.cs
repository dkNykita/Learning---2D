using UnityEngine;
using UnityEngine.UI;


// Time.deltaTime - Fix update on different framerates
// .ToString("F0") - convert value to string with FX decimals

public class IdleGameManager : MonoBehaviour
{
    
    /// Base

    // Text for coin counter
    public Text coinsText;
    // Text for Click Button
    public Text clickText;
    // Owned coins value
    public double coins;
    // How much you get per click on game start
    public double coinsClickValueInitial;
    // How much you get per click
    public double coinsClickValue;
    // Text for CPS
    public Text coinsPerSecondText;
    // Total CPS value      
    public double coinsPerSecond;

    /// Click Upgrade 1

    // Text for Click Upgrade 1
    public Text upgradeClick1Text;
    // Click Upgrade 1 cost
    public double upgradeClick1Cost;
    // Click Upgrade 1 power (how much it does)
    public int upgradeClick1Power;
    // Click Upgrade 1 Prestige 1 Power (P1 multiplier)
    public int upgradeClick1Prestige1Power;
    // Click Upgrade 1 level
    public int upgradeClick1Level;
    // Click Upgrade 1 total coin generation
    public double upgradeClick1Generation;


    /// Upgrade Click 2
    public Text upgradeClick2Text;
    public double upgradeClick2Cost;
    public int upgradeClick2Power;
    public int upgradeClick2Prestige1Power;
    public int upgradeClick2Level;
    public double upgradeClick2Generation;

    /// Production Upgrade 1

    // Text for Production Upgrade 1
    public Text upgradeProduction1Text;
    public double upgradeProduction1Cost;
    public int upgradeProduction1Power;
    public int upgradeProduction1Prestige1Power;
    public int upgradeProduction1Level;
    public double upgradeProduction1Generation;

    /// Production Upgrade 2

    public Text upgradeProduction2Text;
    public double upgradeProduction2Cost;
    public int upgradeProduction2Power;
    public int upgradeProduction2Prestige1Power;
    public int upgradeProduction2Level;
    public double upgradeProduction2Generation;
    
    /// Other







    
    
    
    
    // Start is called before the first frame update
    public void Start()
    {
        // Core
        coins = 10;
        coinsClickValueInitial = 1;

        // Upgrades

        /// Click Upgrades
        upgradeClick1Cost = 10;
        upgradeClick1Power = 1;
        upgradeClick1Prestige1Power = 1;
        upgradeClick2Cost = 100;
        upgradeClick2Power = 10;
        upgradeClick2Prestige1Power = 1;
        /// Production Upgrades
        upgradeProduction1Cost = 25;
        upgradeProduction1Power = 1;
        upgradeProduction1Prestige1Power = 1;
        upgradeProduction2Cost = 250;
        upgradeProduction2Power = 10;
        upgradeProduction2Prestige1Power = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        // Values
        coinsPerSecond = upgradeProduction1Generation+upgradeProduction2Generation;
        coinsClickValue = coinsClickValueInitial + upgradeClick1Generation + upgradeClick2Generation;
        coins += (coinsPerSecond * Time.deltaTime);
        // Text
        clickText.text = "Click\n+" + coinsClickValue + " Coins";
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecondText.text = coinsPerSecond.ToString("F0") + " Coins /s";
        upgradeClick1Text.text = "Click Upgrade 1\n" + "Cost: " + upgradeClick1Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeClick1Power.ToString("F0") + " Clicks\n" + "Level: " + upgradeClick1Level.ToString("F0");
        upgradeClick2Text.text = "Click Upgrade 2\n" + "Cost: " + upgradeClick2Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeClick2Power.ToString("F0") + " Clicks\n" + "Level: " + upgradeClick2Level.ToString("F0");
        upgradeProduction1Text.text = "Production Upgrade 1\n" + "Cost: " + upgradeProduction1Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeProduction1Power.ToString("F0") + " Coins/s\n" + "Level: " + upgradeProduction1Level.ToString("F0");
        upgradeProduction2Text.text = "Production Upgrade 2\n" + "Cost: " + upgradeProduction2Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeProduction2Power.ToString("F0") + " Coins/s\n" + "Level: " + upgradeProduction2Level.ToString("F0");
        
        // Errors

        /// Click Upgrade Errors

        if (coins < upgradeClick1Cost)
        {
            upgradeClick1Text.color = Color.red;
        }
        else
        {
            upgradeClick1Text.color = Color.black;
        }
        if (coins < upgradeClick2Cost)
        {
            upgradeClick2Text.color = Color.red;
        }
        else
        {
            upgradeClick2Text.color = Color.black;
        }

        /// Production Upgrade Errors

        if (coins < upgradeProduction1Cost)
        {
            upgradeProduction1Text.color = Color.red;
        }
        else
        {
            upgradeProduction1Text.color = Color.black;
        }  
        if (coins < upgradeProduction2Cost)
        {
            upgradeProduction2Text.color = Color.red;
        }
        else
        {
            upgradeProduction2Text.color = Color.black;
        }

        /// Other errors        

        if(coins < 0)
        {
            coins = 0;
            coinsText.text = "Error: Negative Coins";
        }
        if(coinsPerSecond < 0)
        {
            coinsPerSecondText.text = "Error: Negative Coins /s";
        }        

    }

    // Functions

    /// Buttons
    public void Click()
    {
        coins += coinsClickValue;
    }    

    public void BuyUpgradeClick1()
    {
        if (coins >= upgradeClick1Cost)
        {
            coins -= upgradeClick1Cost;
            upgradeClick1Level += 1;
            upgradeClick1Cost *= 1.07;             
            upgradeClick1Generation = upgradeClick1Level * (upgradeClick1Power * upgradeClick1Prestige1Power);          
        }
        else
        {

        }
    }

    public void BuyUpgradeClick2()
    {
        if (coins>= upgradeClick2Cost)
        {
            coins -= upgradeClick2Cost;
            upgradeClick2Level += 1;
            upgradeClick2Cost *= 1.09;
            upgradeClick2Generation = upgradeClick2Level * (upgradeClick2Power * upgradeClick2Prestige1Power);
        }
        else
        {
            
        }
    }

    public void BuyUpgradeProduction1()
    {
        if (coins >= upgradeProduction1Cost)
        {
            coins -= upgradeProduction1Cost;
            upgradeProduction1Level += 1;
            upgradeProduction1Cost *= 1.14;
            upgradeProduction1Generation = upgradeProduction1Level * (upgradeProduction1Power * upgradeProduction1Prestige1Power);
        }
        else
        {

        }
    }
    public void BuyUpgradeProduction2()
    {
        if (coins >= upgradeProduction2Cost)
        {
            coins -= upgradeProduction2Cost;
            upgradeProduction2Level += 1;
            upgradeProduction2Cost *= 1.17;
            upgradeProduction2Generation = upgradeProduction2Level * (upgradeProduction2Power * upgradeProduction2Prestige1Power);
        }
        else
        {
            
        }
    }
    
    /// Other functions
    public void errorLowCoins()
    {
        
    }

}
