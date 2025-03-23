using UnityEngine;

namespace Code.Gameplay.Teams.Components
{
  public class Team : MonoBehaviour
  {
    [SerializeField] private TeamTypeId _teamTypeId;
    
    public TeamTypeId TeamTypeId => _teamTypeId;

    public void SetTeam(TeamTypeId teamTypeId)
    {
      _teamTypeId = teamTypeId;
    }
    
    public bool IsSameTeam(GameObject other)
    {
      return other.TryGetComponent(out Team team) && team.TeamTypeId == TeamTypeId;
    }
  }
}