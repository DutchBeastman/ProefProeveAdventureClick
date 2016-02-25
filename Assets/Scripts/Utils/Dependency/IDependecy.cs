using System;

namespace Utils
{
	/// <summary>
	/// The base of all dependencies in the game, it implements IDisposable to allow dependencies to clean up after themselves.
	/// </summary>
	public interface IDependency : IDisposable
	{
	}
}