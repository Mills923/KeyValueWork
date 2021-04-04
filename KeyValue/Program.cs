using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KeyValueWork
{
    struct KeyValue
    {
        public string key { get; }
        public object value { get; }

        public KeyValue(string _key, object _value)
        {
            key = _key;
            value = _value;
        }


    }



    
    class MyDictionary
    {
        KeyValue[] myArray = new KeyValue[10];
        int holder = 0;

        public object this[string key]
        {
            get
            {
                foreach (var item in myArray)
                {
                    if (key==item.key)
                    {
                        return item.value;
                    }

                }
                throw new Exception("KeyNotFoundException");
            }

            set
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (key == myArray[i].key)
                    {
                        myArray[i] = new KeyValue(key, value);
                        return;
                    }


                }
                myArray[holder] = new KeyValue(key, value) ;
                holder++;
                
                //myArray.Concat(new KeyValue[] { new KeyValue() }).ToArray();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
}
