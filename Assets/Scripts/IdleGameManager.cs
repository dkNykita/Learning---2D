using UnityEngine;
using UnityEngine.UI;


// Time.deltaTime - Fix update on different framerates
// .ToString("F0") - convert value to string with FX decimals

public class IdleGameManager : MonoBehaviour
{
    
    // Text for coin counter
    public Text coinsText;
    // Owned coins value
    public double coins;
    // How much you get per click on game start
    public double coinsClickValueInitial;
    // How much you get per click
    public double coinsClickValue;
    // Text for CPS
    public Text coinsPerSecondText;
    // Text for Click Upgrade 1
    public Text upgradeClick1Text;
    // Text for Production Upgrade 1
    public Text upgradeProduction1Text;
    // Total CPS value    
    public double coinsPerSecond;
    // Click Upgrade 1 cost
    public double clickUpgrade1Cost;
    // Click Upgrade 1 level
    public int clickUpgrade1Level;
    // Click Upgrade 1 power (multiplier)
    public int clickUpgrade1Power;
    // Production Upgrade 1 cost
    public double productionUpgrade1Cost;
    // Production Upgrade 1 level
    public int productionUpgrade1Level;
    // Production Upgrade 1 power (multiplier)
    public int productionUpgrade1Power;
    // Production Upgrade 1 total coin generation
    public double productionUpgrade1Generation;
    // Click Upgrade 1 total coin generation
    public double clickUpgrade1Generation;
    // Text for Click Button
    public Text clickText;

    
    
    
    
    // Start is called before the first frame update
    public void Start()
    {
        coins = 10;
        coinsClickValueInitial = 1;
        clickUpgrade1Cost = 10;
        clickUpgrade1Level = 0;
        clickUpgrade1Power = 1;
        productionUpgrade1Cost = 25;
        productionUpgrade1Level = 0;
        productionUpgrade1Power = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        coinsPerSecond = productionUpgrade1Generation;
        coinsClickValue = coinsClickValueInitial + clickUpgrade1Generation;
        clickText.text = "Click\n+" + coinsClickValue + " Coins";
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecondText.text = coinsPerSecond.ToString("F0") + " Coins /s";
        upgradeClick1Text.text = "Click Upgrade 1\n" + "Cost: " + clickUpgrade1Cost.ToString("F0") + " Coins\n" + "Power: +" + clickUpgrade1Power.ToString("F0") + " Click\n" + "Level: " + clickUpgrade1Level.ToString("F0");
        upgradeProduction1Text.text = "Production Upgrade 1\n" + "Cost: " + productionUpgrade1Cost.ToString("F0") + " Coins\n" + "Power: +" + productionUpgrade1Power.ToString("F0") + "Coins/s\n" + "Level: " + productionUpgrade1Level.ToString("F0");
        coins += (coinsPerSecond * Time.deltaTime);
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

    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            coins -= clickUpgrade1Cost;
            clickUpgrade1Level += 1;
            clickUpgrade1Cost *= 1.07;             
            clickUpgrade1Generation = clickUpgrade1Level * clickUpgrade1Power;          
        }
    }

    public void BuyProductionUpgrade1()
    {
        if (coins >= productionUpgrade1Cost)
        {
            coins -= productionUpgrade1Cost;
            productionUpgrade1Level += 1;
            productionUpgrade1Cost *= 1.14;
            productionUpgrade1Generation = productionUpgrade1Level * productionUpgrade1Power;
        }
    }

}
