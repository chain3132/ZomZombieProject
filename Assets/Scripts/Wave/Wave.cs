
using System;
using UnityEngine;

[System.Serializable]
public enum enemyTags
{
    Dog1,
    Dog2,
    Dog3,
    Zombie1,
    Zombie2,
    ZombieBoss1,
    ZombieBoss2,
    ZombieBoss3,
}
[Serializable]
public class Wave
{
    
    public enemyTags[] enemyTags;     
    public int enemyCount;
    public float spawnInterval = 1.5f;
    public float waveInterval = 5f;
}