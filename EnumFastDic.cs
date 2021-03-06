using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumFastDic
{
//Todo:Remove の実装
    public class EnumFastDic<TKey, TValue> : IEnumerable<TValue>
        where TKey : Enum, IConvertible
    {
        TValue[] values;

        public EnumFastDic()
        {
            values = new TValue[Enum.GetValues(typeof(TKey)).Length];
        }

        public TValue this[TKey key]
        {
            get { return values[key.ToInt32(null)]; }
            set
            {
                Add(key, value);
            }
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return ((IEnumerable<TValue>)values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }

        public void Add(TKey key,TValue value)
        {
            this.values[key.ToInt32(null)] = value;
        }
    }
}
