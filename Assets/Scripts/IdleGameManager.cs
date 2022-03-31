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
    // Click Upgrade 1 power (multiplier)
    public int upgradeClick1Power;
    // Click Upgrade 1 level
    public int upgradeClick1Level;
    // Click Upgrade 1 total coin generation
    public double upgradeClick1Generation;


    /// Upgrade Click 2
    public Text upgradeClick2Text;
    public double upgradeClick2Cost;
    public int upgradeClick2Power;
    public int upgradeClick2Level;
    public double upgradeClick2Generation;

    /// Production Upgrade 1

    // Text for Production Upgrade 1
    public Text upgradeProduction1Text;
    // Production Upgrade 1 cost
    public double upgradeProduction1Cost;
    // Production Upgrade 1 power (multiplier)
    public int upgradeProduction1Power;
    // Production Upgrade 1 level
    public int upgradeProduction1Level;
    // Production Upgrade 1 total coin generation
    public double upgradeProduction1Generation;

    /// Production Upgrade 2

    public Text upgradeProduction2Text;
    public double upgradeProduction2Cost;
    public int upgradeProduction2Power;
    public int upgradeProduction2Level;
    public double upgradeProduction2Generation;
    
    /// Other







    
    
    
    
    // Start is called before the first frame update
    public void Start()
    {
        coins = 10;
        coinsClickValueInitial = 1;
        upgradeClick1Cost = 10;
        upgradeClick1Level = 0;
        upgradeClick1Power = 1;
        upgradeProduction1Cost = 25;
        upgradeProduction1Level = 0;
        upgradeProduction1Power = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        // Values
        coinsPerSecond = upgradeProduction1Generation;
        coinsClickValue = coinsClickValueInitial + upgradeClick1Generation;
        coins += (coinsPerSecond * Time.deltaTime);
        // Text
        clickText.text = "Click\n+" + coinsClickValue + " Coins";
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecondText.text = coinsPerSecond.ToString("F0") + " Coins /s";
        upgradeClick1Text.text = "Click Upgrade 1\n" + "Cost: " + upgradeClick1Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeClick1Power.ToString("F0") + " Click\n" + "Level: " + upgradeClick1Level.ToString("F0");
        upgradeProduction1Text.text = "Production Upgrade 1\n" + "Cost: " + upgradeProduction1Cost.ToString("F0") + " Coins\n" + "Power: +" + upgradeProduction1Power.ToString("F0") + "Coins/s\n" + "Level: " + upgradeProduction1Level.ToString("F0");
        
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

        /// Weird errors        

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

    // Buttons
    public void Click()
    {
        coins += coinsClickValue;
    }
    
    public void errorLowCoins()
    {
        
    }

    public void BuyUpgradeClick1()
    {
        if (coins >= upgradeClick1Cost)
        {
            coins -= upgradeClick1Cost;
            upgradeClick1Level += 1;
            upgradeClick1Cost *= 1.07;             
            upgradeClick1Generation = upgradeClick1Level * upgradeClick1Power;          
        }
        else
        {

        }
    }

    public void BuyUpgradeClick2()
    {
        if (true)
        {
            
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
            upgradeProduction1Generation = upgradeProduction1Level * upgradeProduction1Power;
        }
        else
        {

        }
    }
    public void BuyUpgradeProduction2()
    {
        if (true)
        {
            
        }
        else
        {
            
        }
    }

}
