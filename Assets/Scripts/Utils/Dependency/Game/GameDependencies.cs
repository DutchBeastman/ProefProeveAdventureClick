using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	/// <summary>
	/// The GameDependencies handler.
	/// 
	/// All created GameDependencies are available here via <seealso cref="GameDependencies.Get{T}"/>.
	/// GameDependencies get created the first time they are retrieved.
	/// </summary>
	public class GameDependencies
	{
		private static Dictionary<Type , IGameDependency> dependencies;
		private static Dictionary<Type , IGameDependency> Dependencies
		{
			get
			{
				if (dependencies == null)
				{
					dependencies = new Dictionary<Type , IGameDependency>();
				}

				return dependencies;
			}
		}

		public static void Dispose()
		{
			foreach (KeyValuePair<Type , IGameDependency> kvp in dependencies)
			{
				kvp.Value.Dispose();
			}
		}

		/// <summary>
		/// Attempt to retrieve a GameDependency.
		/// </summary>
		/// <typeparam name="T">The GameDependency to retrieve.</typeparam>
		/// <returns>The GameDependency or <code>default(T)</code>.</returns>
		public static T Get<T>() where T : IGameDependency, new()
		{
			Type type = typeof(T);

			if (Dependencies.ContainsKey(type))
			{
				return (T)Dependencies[type];
			}

			IGameDependency dependency = Activator.CreateInstance<T>();
			Dependencies.Add(type , dependency);

			return (T)dependency;
		}
	}
}
