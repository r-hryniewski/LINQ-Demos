using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_Demos
{
    public class Yield
    {
        private static IEnumerable<Item> yieldItemsCollection{
            get
            {
                yield return new Item(1);
                yield return new Item(2);
                yield return new Item(3);
            }
        }

        public static void Run()
        {
            var yieldResult = string.Empty;
            var enumeratorResult = string.Empty;

            foreach (var item in yieldItemsCollection)
            {
                yieldResult += $"Item id: {item.Id}; ";
            }

            var enumeratorItemsCollection = new ItemsCollection();
            foreach (var item in enumeratorItemsCollection)
            {
                enumeratorResult += $"Item id: {item.Id}; ";
            }

            WriteLine($"YIELD: {yieldResult}");
            WriteLine($"ENUMERATOR: {enumeratorResult}");
        }
    }

    //Trivial, useless implementation of IEnumerable and IEnumerator
    public class ItemsCollection : IEnumerable<Item>
    {
        public IEnumerator<Item> GetEnumerator()
        {
            return new ItemEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ItemEnumerator();
        }

        private class ItemEnumerator : IEnumerator<Item>
        {
            int n = 1;
            public Item Current
            {
                get
                {
                    return new Item(n++);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                return n <= 3;
            }

            public void Reset()
            {
                n = 1;
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~ItemEnumerator() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}
