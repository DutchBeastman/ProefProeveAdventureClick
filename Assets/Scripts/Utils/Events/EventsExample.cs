using UnityEngine;
using Utils;

namespace Examples
{
	// The example event to fire
	public class ExampleEvent : IEvent
	{
		public KeyCode Key { private set; get; }

		public ExampleEvent(KeyCode key)
		{
			Key = key;
		}
	}

	// An example using GlobalEvents
	public class GlobalEventsExample : MonoBehaviour
	{
		[SerializeField] private KeyCode key = KeyCode.Space;

		protected void OnEnable()
		{
			// Subscribe to the ExampleEvent, using OnExampleEvent as a callback
			GlobalEvents.AddListener<ExampleEvent>(OnExampleEvent);
		}

		protected void OnDisable()
		{
			// Unsubscribe from the event (IMPORTANT)
			GlobalEvents.RemoveListener<ExampleEvent>(OnExampleEvent);
		}

		protected void Update()
		{
			// Send an ExampleEvent if the specified key has been pressed (this can be done from any script, hence the GlobalEvents)
			if(Input.GetKeyDown(key))
			{
				GlobalEvents.Invoke(new ExampleEvent(key));
			}
		}

		// Called when the event has been received
		private void OnExampleEvent(ExampleEvent evt)
		{
			Debug.Log(evt.Key + " pressed!");
		}
	}

	// An example using an LocalEvents component
	public class LocalEventsExample : MonoBehaviour
	{
		[SerializeField] private LocalEvents eventSystem;
		[SerializeField] private KeyCode key;

		protected void OnEnable()
		{
			// Subscribe to the ExampleEvent, using OnExampleEvent as a callback
			eventSystem.AddListener<ExampleEvent>(OnExampleEvent);
		}

		protected void OnDisable()
		{
			// Unsubscribe from the event (IMPORTANT)
			eventSystem.RemoveListener<ExampleEvent>(OnExampleEvent);
		}

		protected void Update()
		{
			// Send an ExampleEvent if the specified key has been pressed (this can be done from any script which has access to this LocalEvents component)
			if(Input.GetKeyDown(key))
			{
				eventSystem.Invoke(new ExampleEvent(key));
			}
		}

		// Called when the event has been received
		private void OnExampleEvent(ExampleEvent evt)
		{
			Debug.Log(evt.Key + " pressed!");
		}
	}

	// An example creating a custom event dispatcher
	public class EventDispatcherExample : MonoBehaviour
	{
		[SerializeField] private KeyCode key;

		private IEventDispatcher eventDispatcher;

		protected void Awake()
		{
			eventDispatcher = new EventDispatcher();
		}

		protected void OnEnable()
		{
			// Subscribe to the ExampleEvent, using OnExampleEvent as a callback
			eventDispatcher.AddListener<ExampleEvent>(OnExampleEvent);
		}

		protected void OnDisable()
		{
			// Unsubscribe from the event (IMPORTANT)
			eventDispatcher.RemoveListener<ExampleEvent>(OnExampleEvent);
		}

		protected void Update()
		{
			// Send an ExampleEvent if the specified key has been pressed (this can be done from any script which has access to this event dispatcher)
			if(Input.GetKeyDown(key))
			{
				eventDispatcher.Invoke(new ExampleEvent(key));
			}
		}

		// Called when the event has been received
		private void OnExampleEvent(ExampleEvent evt)
		{
			Debug.Log(evt.Key + " pressed!");
		}
	}
}