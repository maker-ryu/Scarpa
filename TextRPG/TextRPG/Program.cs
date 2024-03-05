using System;

namespace TextRPG;

class Program
{
    static void Main()
    {
        Awake();
        Start();
    }

    static void Awake()
    {
        GameManager gameManager = new GameManager();
        // DataManager dataManager = new DataManager();
    }

    static void Start()
    {
        while (true)
        {
            Update();
        }
    }

    static void Update()
    {
        
    }
}