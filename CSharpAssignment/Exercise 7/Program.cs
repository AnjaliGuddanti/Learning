using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exersice_7
{ 
    public class Duck
    { 
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int WingsCount { get; private set; }
        public Duck(string name, int weight, int wings) 
        { 
            Name = name;
            Weight = weight;
            WingsCount = wings; 
        } 
    } 
    public class DuckCollection
    { 
        private class DuckNestedIteratorByWeight : IEnumerable<Duck>, IEnumerator<Duck> 
        {
            private Duck[] ducks;
            private int currentPos = -1; 
            public DuckNestedIteratorByWeight(Duck[] duckArray) 
            { 
                ducks = duckArray; Duck minDuck = ducks[0];
                for (int i = 0; i < ducks.Length - 1; i++)
                { 
                    for (int j = i + 1; j < ducks.Length; j++)
                    { 
                        if (ducks[i].Weight > ducks[j].Weight)
                        { 
                            minDuck = ducks[i]; ducks[i] = ducks[j]; ducks[j] = minDuck; 
                        }
                    } 
                } 
            }
            public Duck Current => ducks[currentPos];
            object IEnumerator.Current => this.Current;
            public void Dispose() 
            { 
                ducks = null;
            }
            public IEnumerator<Duck> GetEnumerator()
            { 
                return this; 
            } 
            public bool MoveNext()
            { 
                currentPos += 1; 
                return currentPos < ducks.Length;
            }
            public void Reset() 
            { 
                currentPos = -1; 
            } 
            IEnumerator IEnumerable.GetEnumerator()
            { return this.GetEnumerator(); }
        }
        private class DuckNestedIteratorByWings : IEnumerable<Duck>, IEnumerator<Duck> 
        { 
            private Duck[] ducks; 
            private int currentPos = -1;
            public DuckNestedIteratorByWings(Duck[] duckArray)
            {
                ducks = duckArray; Duck minDuck = ducks[0];
                for (int i = 0; i < ducks.Length - 1; i++)
                { 
                    for (int j = i + 1; j < ducks.Length; j++) 
                    { 
                        if (ducks[i].WingsCount > ducks[j].WingsCount)
                        { 
                            minDuck = ducks[i]; 
                            ducks[i] = ducks[j]; ducks[j] = minDuck; 
                        }
                    }
                }
            }
            public Duck Current => ducks[currentPos]; 
            object IEnumerator.Current => this.Current; 
            public void Dispose() 
            { 
                ducks = null; 
            }
            public IEnumerator<Duck> GetEnumerator()
            {
                return this;
            } 
            public bool MoveNext() 
            { 
                currentPos += 1;
                return currentPos < ducks.Length;
            } 
            public void Reset() 
            {
                currentPos = -1; 
            } 
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
        private Duck[] _internalDuckStorage;
        private int actualDuckCount = 0; 
        public DuckCollection()
        { 
            _internalDuckStorage = new Duck[1];
        }
        public DuckCollection(int count) 
        { 
            _internalDuckStorage = new Duck[count]; 
        }
        public void AddDuck(Duck d) 
        { 
            actualDuckCount += 1; 
            if (_internalDuckStorage.Length >= actualDuckCount)
            { 
                _internalDuckStorage[actualDuckCount - 1] = d; 
            } 
            else
            {
                Duck[] extendedCollection = new Duck[_internalDuckStorage.Length + 1];
                for (int i = 0; i < _internalDuckStorage.Length; i++) 
                { 
                    extendedCollection[i] = _internalDuckStorage[i]; 
                } 
                extendedCollection[extendedCollection.Length - 1] = d;
                _internalDuckStorage = extendedCollection;
            } 
        }
        public void RemoveDuck(Duck d)
        { 
            int duckIndex = -1;
            for (int i = 0; i < _internalDuckStorage.Length; i++) 
            { 
                if (_internalDuckStorage[i] == d) { duckIndex = i; 
                } 
            }
            if (duckIndex > 0) 
            {
                Duck[] newDuckCollection = new Duck[_internalDuckStorage.Length - 1];
                for (int i = 0; i < newDuckCollection.Length; i++) 
                { 
                    if (i >= duckIndex)
                    { 
                        newDuckCollection[i] = _internalDuckStorage[i + 1]; 
                    }
                    else
                    {
                        newDuckCollection[i] = _internalDuckStorage[i]; 
                    }
                } 
                _internalDuckStorage = newDuckCollection; 
            }
        }
        public void RemoveAllDucks() 
        { 
            _internalDuckStorage = new Duck[1]; 
        }
        public IEnumerable<Duck> GetIteratorByWeight() 
        { 
            return new DuckNestedIteratorByWeight(_internalDuckStorage);
        }
        public IEnumerable<Duck> GetIteratorByWings() 
        { 
            return new DuckNestedIteratorByWings(_internalDuckStorage);
        }
    }
}