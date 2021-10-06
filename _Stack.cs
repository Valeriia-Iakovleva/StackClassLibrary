using System;
using System.Linq;
using System.Text;


namespace MyStack
{

    public class element<U> where U : struct
    {
        public U data { get; private set; }
        public element<U> next { get; protected set; }

        public element(U number)
        {
            this.data = number;
        }

        public element(U number, element<U> item)
        {
            this.data = number;
            next = item;
        }

        public override bool Equals(object obj)
        {
            if (obj is element<U>)
            {
                var other = obj as element<U>;
                if (this.data.Equals(other.data))
                {
                    if (this.next == null && other.next == null || this.next.data.Equals(other.next.data))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }

    public class _Stack<T> where T : struct
    {
        private element<T> head;
        public int Count { get; private set; }

        public _Stack() {  }

        public void Add(T number)
        {
            if (head == null)
            {
                head = new element<T>(number);
                Count++;
            }
            else
            {
                head = new element<T>(number, head);
                Count++;
            }
        }

        public element<T> GetHead()
        {
            if (this.head == null)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                return head;
            }
        }

        public T GetHeadValue()
        {
            if (this.head == null)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                return head.data;
            }
        }

        public T ReturnHeadValue()
        {
            if (this.head == null)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                var r = head;
                head = head.next;
                return r.data;
            }
        }

        public element<T> ReturnHead()
        {
            if (this.head == null)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                var r = head;
                head = head.next;
                Count--;
                return r;
            }
        }

        public static _Stack<int> GetSteckofIntFromConsole()
        {
            var result = new _Stack<int>();
            int[] mas = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < mas.Length; i++)
            {
                result.Add(mas[i]);
            }
            return result;
        }

        public static _Stack<double> GetSteckofDoubleFromConsole()
        {
            var result = new _Stack<double>();
            double[] mas = Console.ReadLine().Split().Select(x => double.Parse(x)).ToArray();
            for (int i = 0; i < mas.Length; i++)
            {
                result.Add(mas[i]);
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.head != null)
            {
                var temphead = this.GetHead();
                for (int i = 0; i < Count; i++)
                {
                    result.Append(temphead.data.ToString() + " ");
                    temphead = temphead.next;
                }
            }
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is _Stack<T>)
            {
                var other = obj as _Stack<T>;

                var temphead = this.GetHead();
                var tempotherhead = other.GetHead();
                for (int i = 0; i < Count - 1; i++)
                {
                    if (temphead.next.data.Equals(tempotherhead.next.data))
                    {
                        temphead = temphead.next;
                        tempotherhead = tempotherhead.next;
                    }
                    else
                        return false;
                }
                return true;
            }
            return false;
        }
    }

}
