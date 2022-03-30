using UnityEngine;
using UnityEngine.UI;

public class IdleGameManager : MonoBehaviour
{
    
    // Text for coin counter
    public Text coinsText;
    // Owned coins value
    public double coins;
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

    
    
    
    
    // Start is called before the first frame update
    public void Start()
    {
        coins = 10;
        coinsClickValue = 1;
        clickUpgrade1Cost = 10;
        clickUpgrade1Power = 1;
        productionUpgrade1Cost = 25;
        productionUpgrade1Power = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        coinsPerSecond = productionUpgrade1Generation;
        clickUpgrade1Generation = clickUpgrade1Level * clickUpgrade1Power;
        coinsClickValue = (clickUpgrade1Generation);
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecondText.text = coinsPerSecond.ToString("F0") + " Coins /s";
        upgradeClick1Text.text = "Click Upgrade 1\n" + "Cost: " + clickUpgrade1Cost.ToString("F0") + " Coins\n" + "Power: +" + clickUpgrade1Power.ToString("F0") + " Click\n" + "Level: " + clickUpgrade1Level.ToString("F0");
        upgradeProduction1Text.text = "Production Upgrade 1\n" + "Cost: " + productionUpgrade1Cost.ToString("F0") + " Coins\n" + "Power: +" + productionUpgrade1Power.ToString("F0") + "Coins/s\n" + "Level: " + productionUpgrade1Level.ToString("F0");
        coins += (coinsPerSecond * Time.deltaTime);

    }

    // Buttons
    public void Click()
    {
        coins += coinsClickValue+clickUpgrade1Generation;
    }

    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            coins -= clickUpgrade1Cost;
            clickUpgrade1Level += 1;
            clickUpgrade1Cost *= 1.07;            
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
