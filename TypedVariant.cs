
//Based on the StackOverflow question  from
//http://stackoverflow.com/questions/1649264/how-to-make-a-type-safe-wrapper-around-variant-values

// The idea is to but non-type safe Objects into a type-safe class so that their actual values can be used.
//OPC Data tags stored values as objects.

//USAGE
//object opcDataTag = (object)"testing"; //this would be returned from an OPC Data Tag, not created this way!!
//var typedVariant = new TypedVariant<string>(opcDataTag);
//.....
//string actualString = typedVariant; //using implicit cast
//int actualInt = typedVariant; //COMPILE time fail as "typedVariant" only contains a string value
namespace OPC_Client
{       
	using System;
	using System.Collections.Generic;
	using System.Text;

    class TypedVariant<T> where T : class
    {        
        public TypedVariant(object variant)
        {
            Value = variant as T;
        }

        public T Value { private set; get; }
        
        public static implicit operator TypedVariant<T> (T m)
        {
            // code to convert from TypedVariant<T> to T
            return new TypedVariant<T>(m);
        }
        
        public static implicit operator T (TypedVariant<T> m)
        {
            // code to convert from T to TypedVariant<T>
            return m.Value;
        }  
    }
}
