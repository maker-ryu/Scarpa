namespace TextRPG._Common;

public enum SceneState
{
    LoadingScene,
    MainScene,
    GameScene,
    GameOver,
}

public enum MainSceneState
{
    Idle,
    상태_보기,
    전투_시작,
}

public enum BattleState
{
    Idle = 0,
    공격 = 1,
    스킬 = 2,
    공격_결과 = 3,
    스킬_결과 = 4,
    EnemyPhase = 10,
    Result = 11,
}