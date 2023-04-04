namespace Roguelike {
    public delegate void LiveDataListener<T>(T value);

    class LiveData<T> {
        protected T _data;
        public T data {
            get { return _data; }
        }
        protected HashSet<LiveDataListener<T>> listeners = new HashSet<LiveDataListener<T>>();

        public LiveData(T value) {
            _data = value;
        }

        public void observe(LiveDataListener<T> listener) {
            listeners.Add(listener);
            listener.Invoke(_data);
        }
    }

    class MutableLiveData<T> : LiveData<T> {
        public new T data {
            get { return _data; }
            set {
                _data = value;
                foreach (LiveDataListener<T> listener in listeners) {
                    listener.Invoke(_data);
                }
            }
        }
        public MutableLiveData(T value) : base(value) {}
    }
}
