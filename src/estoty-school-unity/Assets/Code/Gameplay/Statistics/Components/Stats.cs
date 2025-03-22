using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Statistics.Components
{
  public class Stats : MonoBehaviour
  {
    private readonly Dictionary<StatTypeId, float> _stats = new();

    private void Awake()
    {
      Initialize();
    }

    private void Initialize()
    {
      foreach (StatTypeId statTypeId in Enum.GetValues(typeof(StatTypeId)))
      {
        if (statTypeId == StatTypeId.Unknown)
          continue;
        
        _stats.Add(statTypeId, 0);
      }
    }

    public void AddStat(StatTypeId statTypeId, float value)
    {
      if (!_stats.TryAdd(statTypeId, value))
      {
        _stats[statTypeId] += value;
      }
    }
    
    public void SetStat(StatTypeId statTypeId, float value)
    {
      _stats[statTypeId] = value;
    }

    public float GetStat(StatTypeId statTypeId)
    {
      return _stats.GetValueOrDefault(statTypeId, 0);
    }
  }
}