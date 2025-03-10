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
  }
}