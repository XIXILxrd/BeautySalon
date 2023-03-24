using System.Collections;

namespace BeautySalon.Collection
{
    [Serializable]

    public class ListEnumerator<T> : IEnumerator<T>
    {
        private LList<T> collection;
        private Node<T>? currentNode;
        private bool onFirst = true;

        public ListEnumerator(LList<T> list)
        {
            this.collection = list;
            currentNode = collection.GetHead();
        }

        public Node<T>? Current => currentNode;

        object IEnumerator.Current => Current.value;

        T IEnumerator<T>.Current => Current.value;

        public bool MoveNext()
        {
            if (onFirst)
            {
                onFirst = false;
            }
            else if (currentNode != null)
            {
                currentNode = currentNode.next;
            }

            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
        }

        void IDisposable.Dispose() { }
    }
}