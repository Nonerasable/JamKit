using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace JamKit {
    public static class ServiceLocator {
        
        private static bool _isInitialized;
        private static readonly Dictionary<Type, object> _services = new();
        private static readonly List<IUpdatableService> _updatables = new();

        public static void EnsureInitialized(AudioMixer audioMixer) {
            if (_isInitialized) return;
            _isInitialized = true;

            Register(new GameData());
            Register(new SceneLoader());
            Register(new SoundSettingsManager(audioMixer));
            Register(new UIManager());
            Register(new InputMapController());
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

        public static void Unregister<T>(T service) where T : class, IService {
            var type = typeof(T);
            if (!_services.ContainsKey(type)) return;

            if (service is IUpdatableService updatable) {
                _updatables.Remove(updatable);
            }
            _services.Remove(type);
        }

        public static T TryGet<T>() where T : class, IService {
            if (_services.TryGetValue(typeof(T), out var service)) {
                return service as T;
            }
            return null;
        }
        
        public static T Get<T>() where T : class, IService, new() {
            if (_services.TryGetValue(typeof(T), out var service)) {
                return service as T;
            }
            T newService = new T();
            Register(newService);
            return newService;
        }

        public static void TickAll(float deltaTime) {
            foreach (var updatableService in _updatables) {
                updatableService.Tick(deltaTime);
            }
        }
    }
}