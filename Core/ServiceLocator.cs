using System;
using System.Collections.Generic;
using UnityEngine;

namespace JamKit {
    
    public static class ServiceLocator {
        private static bool _isInitialized;
        private static readonly Dictionary<Type, object> _services = new();
        private static readonly List<IUpdatableService> _updatables = new();

        public static void EnsureInitialized() {
            if (_isInitialized) return;
            _isInitialized = true;

            Register(new SceneLoader());
        }

        public static void Register<T>(T service) where T : class, IService {
            var type = typeof(T);
            if (_services.ContainsKey(type)) return;

            _services[type] = service;
            service.Initialize();

            if (service is IUpdatableService updatable) {
                _updatables.Add(updatable);
            }
        }

        public static T Get<T>() where T : class, IService {
            if (_services.TryGetValue(typeof(T), out var service)) {
                return service as T;
            }
            
            Debug.LogError($"Service not found: {typeof(T)}");
            return null;
        }

        public static void TickAll(float deltaTime) {
            foreach (var updatableService in _updatables) {
                updatableService.Tick(deltaTime);
            }
        }
    }
}