namespace Roguelike {
    public delegate void LiveDataListener<T>(T value);

    class LiveData<T> {
        protected T _data;
        protected HashSet<LiveDataListener<T>> listeners = new HashSet<LiveDataListener<T>>();

        public LiveData(T value) {
            _data = value;
        }

        public void observe(LiveDataListener<T> listener) {
            listeners.Add(listener);
        }
    }

    class MutableLiveData<T> : LiveData<T> {
        public T data {
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
