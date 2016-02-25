namespace Utils
{
	/// <summary>
	/// Every GameDependency should inherit from this interface.
	/// It allows for seperation between GameDependencies and StateDependencies.
	/// </summary>
	public interface IGameDependency : IDependency
	{
	}
}