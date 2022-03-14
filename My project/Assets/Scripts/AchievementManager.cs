using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public static AchievementManager instance;
    public static List<Achievement> Achievements;

    public float LevelTime = 1000f;

    public bool AchievementUnlocked(string achievementName)
    {
        bool result = false;

        if (Achievements == null)
            return false;

        Achievement[] achievementsArray = Achievements.ToArray();
        Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.title);

        if (a == null)
            return false;

        result = a.achieved;

        return result;
    }

    private void Start()
    {
         if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (Achievements != null)
            return;

        Achievements = new List<Achievement>();
        Achievements.Add(new Achievement("Son Of Thunder", "Complete level in less than 10 seconds. ", (object o) => LevelTime <= 10f));
        Achievements.Add(new Achievement("Impossible", "Complete level in less than 5 seconds.", (object o) => LevelTime <= 5f));
        Achievements.Add(new Achievement("God or Cheater", "Complete level in less than 1 second.", (object o) => LevelTime <= 1f));
    }

    private void Update()
    {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (Achievements == null)
            return;

        foreach (var achievement in Achievements)
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
            Debug.Log($"{title}: {description}");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}