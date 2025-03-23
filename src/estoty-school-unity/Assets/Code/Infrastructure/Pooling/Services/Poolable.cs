using UnityEngine;

namespace Code.Infrastructure.Pooling.Services
{
	public class Poolable : MonoBehaviour
	{
		public bool IsPooled { get; set; }
		public string AssetPath { get; set; }
	}
}