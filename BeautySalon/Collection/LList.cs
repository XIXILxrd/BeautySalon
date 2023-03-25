using BeautySalon.Exceptions;
using BeautySalon.Logger;
using BeautySalon.Services;
using System.Collections;

namespace BeautySalon.Collection
{
    delegate void SortType<T>(Func<T, T, int> compare);

    [Serializable]
    public class LList<T> : ICollection<T>
    {
        public Logging<T> log = new Logging<T>();

        private LList<T> list;

        private Node<T>? head;
        private Node<T>? tail;
        private int length;

        SortType<T>? type;

        public LList()
        {
            type = DefaultSort;
            list = new LList<T>();
        }

        public Node<T>? GetHead() => head;

        public LList<T> GetLinkList()
        {
            log.LogInformation("GetLinkList() was started...");

            return list;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public Node<T>? this[int index]
        {
            get
            {
                if (index < 0)
                {
                    log.LogError("Argument Out Of Range Exception");
                    throw new ArgumentOutOfRangeException();
                }

                Node<T>? current = head;

                for (int i = 0; i < index; i++)
                {
                    if (current.next == null)
                    {
                        log.LogError("Argument Out Of Range Exception");
                        throw new ArgumentOutOfRangeException();
                    }

                    current = current.next;
                }

                return current;
            }
        }

        public int Count => length;

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (head is null)
            {
                log.LogInformation($"Value was added as head.");

                head = newNode;

                tail = head;

                length++;

                return;
            }

            log.LogInformation($"Value was added.");

            tail.next = newNode;
            tail = newNode;

            length++;
        }

        public void Add(Object value)
        {
            if (!(value is T))
            {
                log.LogError("Argument Exception");
                throw new ArgumentException();
            }

            Node<T> newNode = new Node<T>((T)value);

            if (head is null)
            {
                log.LogInformation($"Value was added as head.");

                head = newNode;

                tail = head;

                length++;

                return;
            }

            log.LogInformation($"Value was added.");

            tail.next = newNode;
            tail = newNode;

            length++;
        }

        private bool RemoveHead()
        {
            if (head is null)
            {
                log.LogError("Head is null");

                return false;
            }

            Node<T>? temp = head;

            head = head.next;

            temp = null;

            length--;

            log.LogInformation("Head was removed.");

            return true;
        }

        private bool RemoveTail()
        {
            if (tail is null)
            {
                log.LogError("Tail is null");

                return false;
            }

            Node<T>? previous = head;

            Node<T>? temp = head?.next;

            while (temp.next != null)
            {
                previous = previous.next;
                temp = temp.next;
            }

            previous.next = null;

            tail = previous;

            length--;

            log.LogInformation("Tail was removed.");

            return true;
        }

        private bool RemoveSpecify(T item)
        {
            if (head is null)
            {
                log.LogError("Head is null");

                return false;
            }

            bool isRemoved = false;

            Node<T> previous = head;

            while (previous != null && !isRemoved)
            {
                if (previous.next.value.Equals(item))
                {
                    isRemoved = true;
                    break;
                }

                previous = previous.next;
            }

            Node<T> del = previous.next;
            Node<T> temp = del.next;

            previous.next = temp;

            length--;

            log.LogInformation($"Value was removed");

            return isRemoved;
        }

        public bool Remove(T value)
        {
            if (head.value.Equals(value))
            {
                log.LogInformation("Head was removed");

                return RemoveHead();
            }
            else if (tail.value.Equals(value))
            {
                log.LogInformation("Tail was removed");

                return RemoveTail();
            }
            else
            {
                log.LogInformation($"Value was removed");

                return RemoveSpecify(value);
            }
        }

        public bool Contains(T item)
        {
            log.LogInformation($"Cotains() was started");

            bool found = false;

            Node<T>? currentNode = head;

            while (currentNode != null && !found)
            {
                if (currentNode.value.Equals(item))
                {
                    found = true;
                }

                currentNode = currentNode.next;
            }

            return found;
        }

        public void Clear()
        {
            if (head is null)
            {
                log.LogError("Head is null");

                throw new CustomException("Head is null", -1);
            }

            while (head != null)
            {
                RemoveHead();
            }

            log.LogInformation("List was cleared.");
        }

        public void Display()
        {
            log.LogInformation("Display() was started.");

            Node<T> currentNode = head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.value);

                currentNode = currentNode.next;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (head is null)
            {
                log.LogError("Head is null.");

                throw new CustomException("Head is null", -1);
            }

            Node<T> current = head;

            int i = arrayIndex;

            while (current != null && i <= length)
            {
                array[i] = current.value;

                i++;

                current = current.next;
            }

            log.LogInformation("List was copied.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        public LList<T>? Sort()
        {
            if (head is null)
            {
                log.LogError("Head is null.");

                throw new CustomException("Head is null", -1);
            }

            log.LogInformation("Sort() was started.");

            return type?.Invoke(CompareByPrice);
        }

        private async Task BubbleSortAsync(Func<T, T, int> compare)
        {
            log.LogInformation("Sort() was started using BubbleSort().");

            T[] tempArray = new T[list.Count];
            list.CopyTo(tempArray, 0);

            list.Clear();

            T temp;

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = 0; j < tempArray.Length - i - 1; j++)
                {
                    if (compare(tempArray[j], tempArray[j + 1]) > 0)
                    {
                        temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }

            foreach (var item in tempArray)
            {
                list.Add(item);
            }
        }

        private async Task DefaultSort(Func<T, T, int> compare)
        {
            log.LogInformation("Sort() was started using DefaultSort().");

            T[] tempArray = new T[list.Count];

            list.CopyTo(tempArray, 0);

            list.Clear();

            Array.Sort(tempArray, (x, y) => compare(x, y));

            foreach (var item in tempArray)
            {
                list.Add(item);
            }
        }

        private int CompareByPrice(T a, T b)
        {
            log.LogInformation($"CompareByPrice({a}, {b}) was started.");

            if (a is Service && b is Service)
            {
                return (a as Service).Price  >= ((b as Service).Price) ? 1 : -1;
            }

            log.LogError("It can't be compared, because it doesn't correspond to the class Service");

            return 0;
        }

        private int CompareByName(T a, T b)
        {
            log.LogInformation($"CompareByName({a}, {b}) was started.");

            if (a is Service && b is Service)
            {
                return (a as Service).Name.CompareTo((b as Service).Name);
            }

            log.LogError("It can't be compared, because it doesn't correspond to the class Service");

            return 0;
        }
    }
}