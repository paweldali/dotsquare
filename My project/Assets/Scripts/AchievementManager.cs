using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public static AchievementManager instance;
    public static List<Achievement> achievements;

    public static float LevelTime;

    public bool AchievementUnlocked(string achievementName)
    {
        bool result = false;

        if (achievements == null)
            return false;

        Achievement[] achievementsArray = achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.title);

        if (a == null)
            return false;

        result = a.achieved;

        return result;
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeAchievements();

        foreach(var achievement in achievements){
            Debug.Log(achievement.title + " ; " + AchievementUnlocked(achievement.title));
        }
    }

    private void InitializeAchievements()
    {
        if (achievements != null)
            return;

        achievements = new List<Achievement>();
        achievements.Add(new Achievement("Turtle", "Complete level in above than 100 seconds. ", (object o) => LevelTime >= 100f));
        achievements.Add(new Achievement("Bunny", "Complete level in less than 30 seconds. ", (object o) => LevelTime <= 30f));
        achievements.Add(new Achievement("Son Of Thunder", "Complete level in less than 10 seconds. ", (object o) => LevelTime <= 10f));
        achievements.Add(new Achievement("Impossible", "Complete level in less than 5 seconds.", (object o) => LevelTime <= 5f));
        achievements.Add(new Achievement("God or Cheater", "Complete level in less than 1 second.", (object o) => LevelTime <= 1f));
    }

    // private void Update()
    // {
    //     CheckAchievementCompletion();
    // }

    public void SetLevelTime(float levelTime){
        LevelTime = levelTime;
    }

    public void CheckAchievementCompletion()
    {
        if (achievements == null)
            return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{title}: {description} COMPLETED!");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}