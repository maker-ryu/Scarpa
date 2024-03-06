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
        DataManager dataManager = new DataManager();
    }

    static void Start()
    {
        GameManager gameManager = new GameManager();
    }

    static void Update()
    {
        
    }
}