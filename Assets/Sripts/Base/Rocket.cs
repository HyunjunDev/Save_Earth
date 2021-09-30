using System.Collections.Generic;
[System.Serializable]
public class Rocket
{
    public string name;
    public int imageNumber;
    public int amount;
    public double price;
    public double ePs;
    public float autoStar;
    public bool Locked
    {
        get
        {
            return (GameManager.Instance.CurrentUser.star < price) && (amount < 1);
        }
    }
}
